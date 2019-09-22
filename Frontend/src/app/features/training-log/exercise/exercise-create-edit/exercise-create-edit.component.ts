import { UpdateTrainingRequest, UpdateTrainingRequestResponse } from './../../../../../server-models/cqrs/training/requests/update-training.request';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { switchMap, take, map, concatMap } from 'rxjs/operators';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CreateExerciseRequest } from 'src/server-models/cqrs/exercise/requests/create-exercise.request';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { selectedTraining } from 'src/ngrx/training-log/training2/training.selectors';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { Training } from 'src/server-models/entities/training.model';
import { Update } from '@ngrx/entity';
import { trainingUpdated } from 'src/ngrx/training-log/training2/training.actions';

@Component({
  selector: 'app-exercise-create-edit',
  templateUrl: './exercise-create-edit.component.html',
  styleUrls: ['./exercise-create-edit.component.scss']
})
export class ExerciseCreateEditComponent implements OnInit {

  constructor(
    private store: Store<AppState>,
    private exerciseService: ExerciseService,
    private trainingService: TrainingService,
    protected dialogRef: MatDialogRef<ExerciseCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, action: CRUD, exercise: Exercise, exerciseTypes: ExerciseType[] }) { }

  form: FormGroup;
  coachId: string;
  exercise = new Exercise();

  ngOnInit() {
    if (this.data.action == CRUD.Update) this.exercise = Object.assign(new Exercise(), this.data.exercise);

    this.createForm();

    this.store.select(currentUser).pipe(take(1)).subscribe(user => this.coachId = user.id);
  }

  createForm() {
    this.form = new FormGroup({
      exerciseType: new FormControl(this.exercise.exerciseType, Validators.required),
      setsCount: new FormControl(this.exercise.sets ? this.exercise.sets.length : 0, [Validators.required, Validators.min(0), Validators.max(30)]),
    });
  }

  get exerciseType(): AbstractControl { return this.form.get('exerciseType'); }
  get setsCount(): AbstractControl { return this.form.get('setsCount'); }
  displayFunction = (exerciseType: ExerciseType) => exerciseType ? exerciseType.name : null;


  onSubmit() {
    this.createExercise();
  }

  onClose(exercise?: Exercise) {
    this.dialogRef.close(exercise);
  }

  createExercise() {

    let sets = [];
    for (var i = 0; i < this.setsCount.value; i++) {
      sets.push(new Set());
    };

    this.exercise.sets = [...sets];
    this.exercise.exerciseTypeId = this.exerciseType.value.id;

    this.updateTraining(true, this.exercise);
  }

  // var request = new CreateExerciseRequest();
  // request.exerciseTypeId = this.exerciseType.value.id;
  // request.sets = sets;

  // this.store.select(selectedTraining).pipe(take(1), switchMap(
  //   training => {
  //     request.trainingId = training.id;
  //     return this.exerciseService.create<CreateExerciseRequest>(request)
  //   }
  // ), take(1))
  //   .subscribe(
  //     (exercise: Exercise) => {
  //       exercise.exerciseType = this.exerciseType.value;
  //       // this.store.dispatch(normalizeExercise({ exercise, action: CRUD.Create }));
  //       this.onClose(exercise);
  //     },
  //     err => console.log(err)
  //   );

  updateTraining(newExercise: boolean, exercise: Exercise) {

    this.store.select(selectedTraining).pipe(
      map(training => {
        exercise.trainingId = training.id;
        return Object.assign(new Training(), training);
      }),
      concatMap((training: Training) => {

        if (newExercise) {
          training.exercises = [...training.exercises, exercise];
        } else {
          //update
        }

        var request = new UpdateTrainingRequest();
        request.training = training;

        return this.trainingService.update<UpdateTrainingRequest, UpdateTrainingRequestResponse>(request);
      }),
      take(1)
    ).subscribe((response: UpdateTrainingRequestResponse) => {

      const trainingUpdate: Update<Training> = {
        id: response.training.id,
        changes: response.training
      };

      this.store.dispatch(trainingUpdated({ entity: trainingUpdate }));
      this.onClose(response.addedExercise);
    });
  }

}