import { UpdateTrainingRequest, UpdateTrainingRequestResponse } from './../../../../../server-models/cqrs/training/requests/update-training.request';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { concatMap, map, take } from 'rxjs/operators';
import { AthleteCreateEditComponent } from 'src/app/features/athlete-management/athletes-home/athlete-create-edit/athlete-create-edit.component';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import { ValidationErrors } from 'src/server-models/error/error-details.model';
import { selectedTraining } from 'src/ngrx/training/training.selectors';
import { trainingUpdated } from 'src/ngrx/training/training.actions';
import { Update } from '@ngrx/entity';

@Component({
  selector: 'app-exercise-create-edit',
  templateUrl: './exercise-create-edit.component.html',
  styleUrls: ['./exercise-create-edit.component.scss']
})
export class ExerciseCreateEditComponent implements OnInit {

  constructor(
    private store: Store<AppState>,
    private trainingService: TrainingService,
    protected dialogRef: MatDialogRef<AthleteCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, action: CRUD, exercise: Exercise, exerciseTypes: ExerciseType[] }) { }

  form: FormGroup;
  coachId: string;
  exercise = new Exercise();

  ngOnInit() {
    if (this.data.action == CRUD.Update) this.exercise = Object.assign({}, this.data.exercise);

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
    if (this.data.action == CRUD.Create) {
      this.createExercise();
    } else {
      this.updateExercise();
    }
  }

  onClose(exercise?: Exercise) {
    this.dialogRef.close(exercise);
  }

  handleError(validationErrors: ValidationErrors) {
    // if (validationErrors.status && validationErrors.status == ServerStatusCodes.ValidationError) {


    //   if(validationErrors.errors.username) {
    //     this.username.setErrors(validationErrors.errors.username)
    //   }

    //   if(validationErrors.errors.email) {
    //     this.email.setErrors(validationErrors.errors.email)
    //   }

    // }
  }

  createExercise() {
    this.exercise.exerciseTypeId = this.exerciseType.value.id;
    this.exercise.exerciseType = this.exerciseType.value;

    let sets = [];
    for(var i = 0; i < this.setsCount.value; i++) {
      sets.push(new Set());
    };
    this.exercise.sets = sets;

    this.updateTraining(true, this.exercise);
  }

  updateExercise() {
    this.exercise.exerciseTypeId = this.exerciseType.value.id;
    this.exercise.exerciseType = this.exerciseType.value;

    if (this.setsCount.value > this.exercise.sets.length) {// add
      let sets = [];

      for(var i = 0; i < (this.setsCount.value - this.exercise.sets.length); i++) {
        sets.push(new Set());
      };

      this.exercise.sets = [...this.exercise.sets, ...sets];
    } else if (this.setsCount.value < this.exercise.sets.length) { // delete 
      var sets = [...this.exercise.sets];
      for(var i = 0; i < this.setsCount.value; i++) {
        sets.pop();;
      };

      this.exercise.sets = [...sets];
    }

    this.updateTraining(false, this.exercise);
  }

  updateTraining(newExercise: boolean, exercise: Exercise) {
    this.store.select(selectedTraining).pipe(
      take(1),
      map(training => Object.assign({}, training)),
      concatMap((training: Training) => {
        var request = new UpdateTrainingRequest();
        request.training = training;
        request.exerciseAdd = exercise;
        return this.trainingService.update<UpdateTrainingRequest, UpdateTrainingRequestResponse>(request);
      }),
      take(1)
    ).subscribe((response: UpdateTrainingRequestResponse) => {

      const trainingUpdate: Update<Training> = {
        id: response.training.id,
        changes: response.training
      };

      this.store.dispatch(trainingUpdated({ training: trainingUpdate }));
      this.onClose(response.addedExercise);
    });
  }
}