import { UIService } from './../../../../../../../../business/services/shared/ui.service';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import * as _ from 'lodash-es';
import { Observable } from 'rxjs';
import { debounceTime, distinct, filter, finalize, skip, switchMap, take, tap } from 'rxjs/operators';
import { ExerciseCreateEditComponent } from 'src/app/features/training-log/exercise/exercise-create-edit/exercise-create-edit.component';
import { ChooseMaxDialogComponent } from 'src/app/features/training-log/set/set-create-edit/choose-max-dialog/choose-max-dialog.component';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { transformWeightToNumber } from 'src/business/services/shared/unit-system.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser, userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CreateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/create-exercise-type.request';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { PersonalBest } from 'src/server-models/entities/personal-best.model';
import { Set } from 'src/server-models/entities/set.model';
import { UserSetting } from 'src/server-models/entities/user-settings.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { UnitSystem, UnitSystemUnitOfMeasurement } from 'src/server-models/enums/unit-system.enum';
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
    private UIService: UIService,
    private dialogRef: MatDialogRef<ExerciseCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      titleExercise: string,
      titleSets: string,
      action: CRUD,
      exercise: Exercise,
      exerciseTypes: PagedList<ExerciseType>,
      pagingModel: PagingModel,
      prs: PersonalBest[] 
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
  quickAddMode = false;

  ngOnInit() {
    this.exercise = Object.assign(new Exercise(), this.data.exercise);
    this.exerciseId = this.exercise.id;

    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);
    this.store.select(userSetting).pipe(take(1)).subscribe(settings => this.settings = settings);

    this.createExerciseTypeForm();
  }

  //#region Exercise type form 
  createExerciseTypeForm() {
    this.exerciseForm = new FormGroup({
      exerciseTypeSearchInput: new FormControl(this.exercise.exerciseType, [Validators.required, isExerciseTypeValidator]),
      selectedExerciseType: new FormControl(this.exercise.exerciseType, [Validators.required, isExerciseTypeValidator]),
      name: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(50)
      ]),
      requiresWeight: new FormControl(true),
      requiresReps: new FormControl(true),
      requiresSets: new FormControl(true),
      requiresTime: new FormControl(false),
      requiresBodyweight: new FormControl(false),
    });

    // listeners
    this._subs.add(
      this.onSearchExerciseTypes(),
    );
  }

  get exerciseTypeSearchInput(): AbstractControl { return this.exerciseForm.get('exerciseTypeSearchInput'); }
  get selectedExerciseType(): AbstractControl { return this.exerciseForm.get('selectedExerciseType'); }
  get exerciseType(): ExerciseType { return this.exerciseForm.get('selectedExerciseType').value as ExerciseType; }
  get name(): AbstractControl { return this.exerciseForm.get("name"); }
  get requiresWeightCheckbox(): AbstractControl { return this.exerciseForm.get("requiresWeight"); }
  get requiresBodyweightCheckbox(): AbstractControl { return this.exerciseForm.get("requiresBodyweight"); }
  get requiresRepsCheckbox(): AbstractControl { return this.exerciseForm.get("requiresReps"); }
  get requiresSetsCheckbox(): AbstractControl { return this.exerciseForm.get("requiresSets"); }
  get requiresTimeCheckbox(): AbstractControl { return this.exerciseForm.get("requiresTime"); }
  
  get requiresWeight():boolean { return !this.quickAddMode && this.exerciseType.requiresWeight || this.quickAddMode && this.requiresWeightCheckbox.value }
  get requiresBodyweight():boolean { return !this.quickAddMode && this.exerciseType.requiresBodyweight || this.quickAddMode && this.requiresBodyweightCheckbox.value }
  get requiresReps():boolean { return !this.quickAddMode && this.exerciseType.requiresReps || this.quickAddMode && this.requiresRepsCheckbox.value }
  get requiresSets():boolean { return !this.quickAddMode && this.exerciseType.requiresSets || this.quickAddMode && this.requiresSetsCheckbox.value }
  get requiresTime():boolean { return !this.quickAddMode && this.exerciseType.requiresTime || this.quickAddMode && this.requiresTimeCheckbox.value }
  
  get unitSystemUnitofMeasurement() {
    if (this.settings.unitSystem == UnitSystem.Metric)
      return UnitSystemUnitOfMeasurement.Metric;

    return UnitSystemUnitOfMeasurement.Imperial;
  }

  displayFunction = (exerciseType: ExerciseType) => exerciseType ? exerciseType.name : null;

  onExerciseTypeSelected(event: MatAutocompleteSelectedEvent) {
    this.selectedExerciseType.setValue(event.option.value);
    this.createSetForms();
  }

  onQuickAddModeActivated() {
    this.createSetForms();
  }
  onQuickModeDisabled() {
    if(!this.exerciseType) {
      this.setFormGroups = [];
      this.sets = []
    } else{
      this.createSetForms();
    }
  }

  onQuickAddCheckboxChange(change: MatCheckboxChange) {
    switch (change.source.name) {
      case 'time':
        this.requiresRepsCheckbox.value && change.checked && this.requiresRepsCheckbox.setValue(false);
        break;
      case 'weight':
        this.requiresBodyweightCheckbox.value && change.checked && this.requiresBodyweightCheckbox.setValue(false);
        break;
      case 'bodyweight':
        this.requiresWeightCheckbox.value && change.checked && this.requiresWeightCheckbox.setValue(false);
        break;
      case 'reps':
        this.requiresTimeCheckbox.value && change.checked && this.requiresTimeCheckbox.setValue(false);
        break;
      default:
        throw new Error('No checkbox like that defined ' + change.source);
    }
  }

  createExerciseType() {
    if (this.name.valid == false)
      return;

    const request = new CreateExerciseTypeRequest({
      name: this.name.value,
      applicationUserId: this._userId,
      requiresWeight: this.requiresWeightCheckbox.value,
      requiresBodyweight: this.requiresBodyweightCheckbox.value,
      requiresReps: this.requiresRepsCheckbox.value,
      requiresSets: this.requiresSetsCheckbox.value,
      requiresTime: this.requiresTimeCheckbox.value,
    });

    return this.exerciseTypeService.create(request);
  }

  onSearchExerciseTypes = () => {
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
    if (this.requiresBodyweight)
      controls["weight"] = new FormControl(set.weight, [Validators.required, Validators.min(0), Validators.max(200)]);

    if (this.requiresReps)
      controls["reps"] = new FormControl(set.reps, [Validators.required, Validators.min(0), Validators.max(100)]);

    if (this.requiresTime)
      controls["time"] = new FormControl(set.time, [Validators.required]);

    if (this.requiresWeight) {
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
    if (this.requiresBodyweight)
      set.weight = controls["weight"].value || 0;

    if (this.requiresReps)
      set.reps = controls["reps"].value || 0;

    if (this.requiresTime)
      set.time = controls["time"].value || 0;

    //handle weight transformations.. everything is system is in metric
    if (this.requiresWeight)
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

  onSetRpeControl(event: MatSlideToggleChange, index: number) {
    if (!event.checked) {
      this.setFormGroups[index].removeControl('rpe');
      this.setFormGroups[index].removeControl('rir');
    } else {
      if (this.settings.rpeSystem == RpeSystem.Rpe) {
        this.setFormGroups[index].addControl('rpe', new FormControl("5", [Validators.min(0), Validators.max(100)]));
      } else {
        this.setFormGroups[index].addControl('rir', new FormControl("5", [Validators.min(0), Validators.max(100)]));
      }

      this.setFormGroups[index].disable();
    }
  }

  onUsePercentage(event: MatSlideToggleChange, index: number) {

    if (event.checked) {

      let setPercentageControl = (response) => {
        if (response) {
          this.setFormGroups[index].removeControl('weight');
          this.setFormGroups[index].addControl('percentage', new FormControl(0, [Validators.required, Validators.min(0), Validators.max(100)]));
          this.setFormGroups[index].disable();
        } else {
          event.source.checked = false;
        }
      }

      // check for one rep max...
      if (this.userMaxControl == null) {
        this.setUserMax().subscribe(setPercentageControl);
      } else {
        setPercentageControl(true);
      }

    } else {
      this.setFormGroups[index].addControl('weight', new FormControl(0, [Validators.required, Validators.min(0), Validators.max(200)]));
      this.setFormGroups[index].removeControl('percentage');
      this.setFormGroups[index].disable();

      if (!this.checkForPercentageControls()) {
        this.userMaxControl = null;
      }
    }

  }

  checkForPercentageControls() {
    let result = false;
    this.setFormGroups.forEach(group => {
      result = !!group['percentage']
    });

    return result;
  }

  //#region USER MAX
  userMaxControl: FormControl;

  /** User can't use percentages if he doesn't have at least one PR defined..
   * He can either use HIS PR or opt to using projected max from us
   * But if none of those exist he must manually give us PR or he can't use percentages
   * He should be able to opt out of percentages and use weight for example in case he doesn't know max
   */
  setUserMax() {
    let userPR = this.data.prs[0];
    let systemPR = this.data.prs[1];

    if (!userPR) {
      return this.onSetMaxDialog(systemPR);
    } else {
      this.setUserMaxControl(userPR.value);
    }
  }


  setUserMaxControl(value: number) {
    value = transformWeightToNumber(value, this.settings.unitSystem);
    let validators = [Validators.required, Validators.min(0), Validators.max(this.weightUpperLimit)]

    this.userMaxControl = new FormControl(value, validators);
  }

  get weightUpperLimit() {
    let upperLimit = 600;

    if (this.settings.unitSystem == UnitSystem.Imperial) {
      upperLimit = 1200;
    }

    return upperLimit;
  }

  onSetMaxDialog(systemPR: PersonalBest) {

    const dialogRef = this.UIService.openDialogFromComponent(ChooseMaxDialogComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      disableClose: true,
      data: {
        title: 'PERSONAL_BEST.SET_MAX',
        systemPR
      },
      panelClass: ['choose-max-dialog-container', "dialog-container"],
    })

    return dialogRef.afterClosed().pipe(
      take(1),
      tap(response => {
        if (!response) {
          this.userMaxControl = null;
          this.settings.usePercentages = false;
        } else {
          this.setUserMaxControl(response.value);
        }
      }))

  }
  //#endregion

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
