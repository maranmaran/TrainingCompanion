import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { map, switchMap, take } from 'rxjs/operators';
import { SetService } from 'src/business/services/feature-services/set.service';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UnitSystemService } from 'src/business/services/shared/unit-system.service';
import { currentUser, userSettings } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training2/training.actions';
import { selectedExercise, selectedTraining } from 'src/ngrx/training-log/training2/training.selectors';
import { UpdateTrainingRequest, UpdateTrainingRequestResponse } from 'src/server-models/cqrs/training/requests/update-training.request';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Set } from 'src/server-models/entities/set.model';
import { Training } from 'src/server-models/entities/training.model';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { UpdateManySetsRequest } from './../../../../../server-models/cqrs/set/requests/update-many-sets.request';
import { Exercise } from './../../../../../server-models/entities/exercise.model';
import * as _ from "lodash";
import { timeout } from 'q';
import { $ } from 'protractor';

@Component({
  selector: 'app-set-create-edit',
  templateUrl: './set-create-edit.component.html',
  styleUrls: ['./set-create-edit.component.scss']
})
export class SetCreateEditComponent implements OnInit {


  constructor(
    private store: Store<AppState>,
    private unitSystemService: UnitSystemService,
    private trainingService: TrainingService,
    private setService: SetService,
    protected dialogRef: MatDialogRef<SetCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, sets: Set[] }) { }

  form: FormGroup;
  get formControls() { return (<FormArray>this.form.get('sets')).controls; }
  sets: Set[] = [];

  coachId: string;
  settings: UserSettings;
  exerciseType: ExerciseType;
  exerciseId: string;

  ngOnInit() {
    this.sets = [...this.data.sets];
    this.store.select(userSettings).pipe(take(1)).subscribe(settings => this.settings = settings);
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this.coachId = user.id);
    this.store.select(selectedExercise).pipe(take(1)).subscribe(exercise => {
      this.exerciseId = exercise.id;
      this.exerciseType = exercise.exerciseType
    });

    this.createForm();
  }

  createForm() {
    const controls = [];
    this.sets.forEach(set => {
      controls.push(
        new FormGroup(this.getControls(set))
      )
    })

    this.form = new FormGroup({
      sets: new FormArray(controls)
    });
  }

  addControl() {
    let control = new FormGroup(this.getControls(new Set()));
    const array = (this.form.get('sets') as FormArray);
    array.push(control);
  }

  removeControl(index: number) {
    (<FormArray>this.form.get('sets')).removeAt(index);
  }

  getControls(set: Set): { [key: string]: AbstractControl } {
    const controls = {};

    controls["id"] = new FormControl({ value: set.id });

    // todo.. add weight attribute to application user
    if (this.exerciseType.requiresBodyweight)
      controls["weight"] = new FormControl({ value: set.weight, disabled: true }, [Validators.min(0), Validators.max(200)]);

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
      if (this.settings.rpeSystem == RpeSystem.Rir)
        controls["rpe"] = new FormControl((10 - set.rpe), [Validators.required, Validators.min(0), Validators.max(10)]);


      if (this.settings.rpeSystem == RpeSystem.Rpe)
        controls["rpe"] = new FormControl(set.rpe, [Validators.required, Validators.min(0), Validators.max(10)]);
    }

    return controls;
  }

  getSetsFromControls(): Set[] {
    const sets = [];

    this.form.get('sets').value.forEach(setControl => {

      let set = new Set();
      set.exerciseId = this.exerciseId;
      set.id = setControl["id"].value;

      // todo.. add weight attribute to application user
      if (this.exerciseType.requiresBodyweight)
        set.weight = setControl["weight"];

      if (this.exerciseType.requiresReps)
        set.reps = setControl["reps"];

      if (this.exerciseType.requiresTime)
        set.time = setControl["time"];

      //handle weight transformations.. everything is system is in metric
      if (this.exerciseType.requiresWeight)
        set.weight = setControl["weight"];

      if (this.settings.useRpeSystem) {

        if (this.settings.rpeSystem == RpeSystem.Rir)
          set.rpe = setControl["rpe"];

        if (this.settings.rpeSystem == RpeSystem.Rpe)
          set.rpe = setControl["rpe"];
      }

      sets.push(set);
    });

    return sets;
  }

  onSubmit() {
    if (!this.form.valid) return;

    let sets = this.getSetsFromControls();

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

  onClose(sets?: Set[]) {
    this.dialogRef.close(sets);
  }

}