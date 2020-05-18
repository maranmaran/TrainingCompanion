import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import * as _ from 'lodash';
import { Observable } from 'rxjs';
import { debounceTime, distinct, filter, finalize, skip, switchMap, take, tap } from 'rxjs/operators';
import { ExerciseCreateEditComponent } from 'src/app/features/training-log/exercise/exercise-create-edit/exercise-create-edit.component';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { transformWeightToNumber } from 'src/business/services/shared/unit-system.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser, userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Set } from 'src/server-models/entities/set.model';
import { UserSetting } from 'src/server-models/entities/user-settings.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { PagedList } from 'src/server-models/shared/paged-list.model';
import { SubSink } from 'subsink';

//TODO: This will be duplicated template code from
// exercise-create-edit
// sets-create-edit
// these three components will probably need some refactoring so I don't duplicate stuff
// first step would be making separate dialog container with actions..save and close
// content would be special create edit component
// which only outputs it's events.. save close edit and all save logic should actually be in parent who called dialog
// but i can output callback function from content component into the dialog container with actions so it can call them on btn click.
@Component({
  selector: 'app-block-exercise-create-edit',
  templateUrl: './block-exercise-create-edit.component.html',
  styleUrls: ['./block-exercise-create-edit.component.scss']
})
export class BlockExerciseCreateEditComponent implements OnInit {

  constructor(
    private exerciseTypeService: ExerciseTypeService,
    private store: Store<AppState>,
    private exerciseService: ExerciseService,
    private trainingService: TrainingService,
    private dialogRef: MatDialogRef<ExerciseCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      titleExercise: string,
      titleSets: string,
      action: CRUD,
      exercise: Exercise,
      exerciseTypes: PagedList<ExerciseType>,
      pagingModel: PagingModel
    }) { }


  exerciseForm: FormGroup;
  setFormGroups: FormGroup[] = [];
  exercise: Exercise;

  sets: Set[];
  settings: UserSetting;
  exerciseId: string;

  private _subs = new SubSink();
  private _userId: string;

  isLoading = false;

  ngOnInit() {
    this.exercise = Object.assign(new Exercise(), this.data.exercise);
    this.exerciseId = this.exercise.id;

    this.store.select(userSetting).pipe(take(1)).subscribe(settings => this.settings = settings);

    this.createExerciseTypeForm();
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);
  }

  //#region Exercise type form 
  createExerciseTypeForm() {
    this.exerciseForm = new FormGroup({
      exerciseTypeSearchInput: new FormControl(this.exercise.exerciseType, [Validators.required, isExerciseTypeValidator]),
      selectedExerciseType: new FormControl(this.exercise.exerciseType, [Validators.required, isExerciseTypeValidator]),
    });

    this.addListeners();
  }

  get exerciseTypeSearchInput(): AbstractControl { return this.exerciseForm.get('exerciseTypeSearchInput'); }
  get selectedExerciseType(): AbstractControl { return this.exerciseForm.get('selectedExerciseType'); }
  get exerciseType(): ExerciseType { return this.exerciseForm.get('selectedExerciseType').value as ExerciseType; }
  displayFunction = (exerciseType: ExerciseType) => exerciseType ? exerciseType.name : null;

  addListeners = () => {
    this._subs.add(
      this.exerciseTypeChangeSubscription(),
    );
  }

  onExerciseTypeSelected(event: MatAutocompleteSelectedEvent) {
    this.selectedExerciseType.setValue(event.option.value);
    this.createSetForms();
  }

  exerciseTypeChangeSubscription = () => {
    return this.exerciseTypeSearchInput.valueChanges
      .pipe(
        debounceTime(500),
        distinct(),
        skip(1),
        filter(val => _.isString(val)),
        tap(() => {
          this.isLoading = true;
        }),
        switchMap(val => {
          this.data.pagingModel.filterQuery = val;
          return this.exerciseTypeService.getPaged(this._userId, this.data.pagingModel).pipe(finalize(() => this.isLoading = false));
        }
        )
      ).subscribe(
        (data: PagedList<ExerciseType>) => {
          this.selectedExerciseType.setValue(null);
          this.data.exerciseTypes = data;
        }
      )
  }
  //#endregion

  //#region Sets form
  createSetForms() {
    this.setFormGroups = [];
    this.sets = [this.getNewSet()]
    this.sets.forEach(set => {
      this.setFormGroups.push(
        new FormGroup(this.getControls(set))
      )
    });
  }

  getNewSet() {
    let set = new Set();
    set.exerciseId = this.exerciseId;

    return set;
  }

  getControls(set: Set): { [key: string]: AbstractControl } {
    const controls = {};

    controls["id"] = new FormControl(set.id);

    // todo.. add weight attribute to application user
    if (this.exerciseType.requiresBodyweight)
      controls["weight"] = new FormControl(set.weight, [Validators.required, Validators.min(0), Validators.max(200)]);

    if (this.exerciseType.requiresReps)
      controls["reps"] = new FormControl(set.reps, [Validators.required, Validators.min(0), Validators.max(100)]);

    if (this.exerciseType.requiresTime)
      controls["time"] = new FormControl(set.time, [Validators.required]);

    if (this.exerciseType.requiresWeight) {
      let upperLimit = 600;

      if (this.settings.unitSystem == UnitSystem.Imperial) {
        upperLimit = 1200;
      }

      controls["weight"] = new FormControl(set.weight, [Validators.required, Validators.min(0), Validators.max(upperLimit)]);
    }

    if (this.settings.useRpeSystem) {
      if (this.settings.rpeSystem == RpeSystem.Rir) {
        let val = set.rir ? set.rir : 10 - set.rpe;
        controls["rir"] = new FormControl(val.toString(), [Validators.required, Validators.min(0), Validators.max(10)]);
      }

      if (this.settings.rpeSystem == RpeSystem.Rpe) {
        let val = set.rpe ? set.rpe : 10 - set.rir;
        controls["rpe"] = new FormControl(val.toString(), [Validators.required, Validators.min(0), Validators.max(10)]);
      }
    }

    return controls;
  }

  getSets(formGroups: FormGroup[]): Set[] {

    const sets = [];
    var setFormGroups = formGroups;

    for (let i = 0; i < setFormGroups.length; i++) {

      const setFormGroup = setFormGroups[i];

      const set = this.getSet(setFormGroup);
      sets.push(set);
    }

    return sets;
  }

  getSet(group: FormGroup): Set {

    const controls = group.controls;

    let set = new Set();
    set.exerciseId = this.exerciseId;
    set.id = controls["id"].value;

    // todo.. add weight attribute to application user
    if (this.exerciseType.requiresBodyweight)
      set.weight = controls["weight"].value || 0;

    if (this.exerciseType.requiresReps)
      set.reps = controls["reps"].value || 0;

    if (this.exerciseType.requiresTime)
      set.time = controls["time"].value || 0;

    //handle weight transformations.. everything is system is in metric
    if (this.exerciseType.requiresWeight)
      set.weight = transformWeightToNumber(controls["weight"].value, this.settings.unitSystem) || 0;

    if (this.settings.useRpeSystem) {

      if (this.settings.rpeSystem == RpeSystem.Rpe)
        set.rpe = controls["rpe"].value;

      if (this.settings.rpeSystem == RpeSystem.Rir)
        set.rir = controls["rir"].value;
    }

    return set;
  }

  addGroup(set: Set = null) {

    set = set || new Set();

    const controls = this.getControls(set);
    const newSetFormGroup = new FormGroup(controls);

    this.setFormGroups.push(newSetFormGroup);
  }

  removeGroup(index: number) {
    this.setFormGroups.splice(index, 1);
  }

  copyDown(index: number) {
    const setGroup = this.setFormGroups[index];
    let nextGroup = this.setFormGroups[index + 1];

    const set = this.getSet(setGroup);
    if (nextGroup) {
      // update
      set.id = nextGroup.controls["id"].value;

      const groupControls = this.getControls(set);
      nextGroup = new FormGroup(groupControls);

      this.setFormGroups[index + 1] = nextGroup;

    } else {
      // add
      set.id = Guid.createEmpty().toString();
      this.addGroup(set);
    }
  }

  get areSetsValid() {
    return this.setFormGroups.length > 0 && this.setFormGroups.reduce((prev, curr) => prev && curr.valid, true);
  }


  //#endregion

  //#region Dialog controlls
  onSubmit() {
    let sets = <Set[]>(this.getSets(this.setFormGroups));
    this.exercise.sets = sets;
    this.exercise.exerciseType = this.exerciseType;
    this.exercise.exerciseTypeId = this.exerciseType.id;

    console.log(this.exercise);

    var result$: Observable<Exercise | Error>
    if (this.data.action == CRUD.Create) {
      result$ = this.exerciseService.createWithSets(this.exercise).pipe(take(1));
    }
    if (this.data.action == CRUD.Update) {
      result$ = this.exerciseService.updateWithSets(this.exercise).pipe(take(1));
    }

    if (!result$) return;
    result$.subscribe(
      exercise => this.onClose(exercise),
      err => (console.log(err), this.onClose())
    )
  }

  onClose(exercise = null) {
    this.dialogRef.close(exercise);
  }

  //#endregion
}

export function isExerciseTypeValidator(control: AbstractControl): { [key: string]: any } | null {
  const isOfType = (value): value is ExerciseType => {

    if ((value as ExerciseType)?.id) {
      return true;
    }

    return false;

  };

  return isOfType(control.value) ? null : { 'exerciseType': { value: control.value } }
};
