import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import * as _ from "lodash";
import { switchMap, take } from 'rxjs/operators';
import { SetService } from 'src/business/services/feature-services/set.service';
import { transformWeightToNumber } from 'src/business/services/shared/unit-system.service';
import { currentUser, userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training.actions';
import { selectedExercise, selectedTraining } from 'src/ngrx/training-log/training.selectors';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Set } from 'src/server-models/entities/set.model';
import { Training } from 'src/server-models/entities/training.model';
import { UserSetting } from 'src/server-models/entities/user-settings.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { UpdateManySetsRequest } from './../../../../../server-models/cqrs/set/update-many-sets.request';
import { Exercise } from './../../../../../server-models/entities/exercise.model';

@Component({
  selector: 'app-set-create-edit',
  templateUrl: './set-create-edit.component.html',
  styleUrls: ['./set-create-edit.component.scss']
})
export class SetCreateEditComponent implements OnInit {


  constructor(
    private store: Store<AppState>,
    private formBuilder: FormBuilder,
    private setService: SetService,
    private dialogRef: MatDialogRef<SetCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { action, title: string, sets: Set[] }) { }

  setFormGroups: FormGroup[] = [];
  // get formControls() { return (<FormArray>this.form.get('sets')).controls; }
  sets: Set[] = [];

  coachId: string;
  settings: UserSetting;
  exerciseType: ExerciseType;
  exerciseId: string;

  ngOnInit() {
    this.sets = [...this.data.sets];
    this.store.select(userSetting).pipe(take(1)).subscribe(settings => this.settings = settings);
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this.coachId = user.id);
    this.store.select(selectedExercise).pipe(take(1)).subscribe(exercise => {
      this.exerciseId = exercise.id;
      this.exerciseType = exercise.exerciseType
    });

    this.createForms();
  }

  createForms() {
    this.sets.forEach(set => {
      this.setFormGroups.push(
        new FormGroup(this.getControls(set))
      )
    });

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

  getControls(set: Set): { [key: string]: AbstractControl } {
    const controls = {};

    controls["id"] = new FormControl(set.id);

    // todo.. add weight attribute to application user
    if (this.exerciseType.requiresBodyweight)
      controls["weight"] = new FormControl(set.weight, [Validators.min(0), Validators.max(200)]);

    if (this.exerciseType.requiresReps)
      controls["reps"] = new FormControl(set.reps, [Validators.min(0), Validators.max(100)]);

    if (this.exerciseType.requiresTime)
      controls["time"] = new FormControl(set.time, [Validators.required]);

    if (this.exerciseType.requiresWeight) {
      let upperLimit = 600;
      if (this.settings.unitSystem == UnitSystem.Imperial) {
        upperLimit = 1200;
      }

      controls["weight"] = new FormControl(set.weight, [Validators.min(0), Validators.max(upperLimit)]);
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

  onSubmit() {
    // are all forms valid
    if (!this.isFormValid) return;

    let sets = <Set[]>(this.getSets(this.setFormGroups));

    var request = new UpdateManySetsRequest();
    request.sets = sets;
    request.exerciseId = this.exerciseId;

    this.setService.updateMany<UpdateManySetsRequest>(request)
      .pipe(
        switchMap(
          (sets: Set[]) => {
            return this.store.select(selectedTraining)
          },
          (sets, training) => ({ sets, training })
        ),
        take(1))
      .subscribe(
        (response: { sets: Set[], training: Training }) => {

          var index = response.training.exercises.findIndex(x => x.id == this.exerciseId);
          var exercises: Exercise[] = _.cloneDeep(response.training.exercises);
          exercises[index].sets = response.sets;

          var updatedTraining: Update<Training> = {
            id: response.training.id,
            changes: {
              exercises: exercises
            }
          };

          this.store.dispatch(trainingUpdated({ entity: updatedTraining }));
          this.onClose(response.sets);
        },
        err => console.log(err)
      )
  }

  get isFormValid() {
    return this.setFormGroups.reduce((prev, curr) => prev && curr.valid, true);
  }

  onClose(sets?: Set[]) {
    this.dialogRef.close(sets);
  }

}
