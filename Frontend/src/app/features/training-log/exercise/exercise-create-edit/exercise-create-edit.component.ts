import { UpdateExerciseRequest } from './../../../../../server-models/cqrs/exercise/requests/update-exercise.request';
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
import { selectedTrainingId } from './../../../../../ngrx/training-log/training2/training.selectors';

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

    // make new sets
    let sets = [];
    for (var i = 0; i < this.setsCount.value; i++) {
      sets.push(new Set());
    };

    // create request
    var request = new CreateExerciseRequest();
    request.exerciseTypeId = this.exerciseType.value.id;
    request.sets = [...sets];

    // select training for id
    this.store.select(selectedTraining)
      .pipe(
        switchMap(
          (training: Training) => {
            // finish and send request
            request.trainingId = training.id as string;
            return this.exerciseService.create<CreateExerciseRequest>(request);
          },
          // result selector so we can have inner and outer variables from switchmap
          (training, exercise) => ({ training, exercise }),
        ),
        take(1)
      )
      .subscribe(
        (response: { training: Training, exercise: Exercise }) => {

          // create upsert command
          const trainingUpdate: Update<Training> = {
            id: response.training.id,
            changes: {
              exercises: [...response.training.exercises, response.exercise]
            }
          };

          // update and close
          this.store.dispatch(trainingUpdated({ entity: trainingUpdate }));
          this.onClose(response.exercise);
        },
        err => console.log(err)
      )
  }

}