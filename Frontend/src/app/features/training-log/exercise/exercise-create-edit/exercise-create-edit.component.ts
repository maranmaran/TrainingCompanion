import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/requests/update-training.request';
import { Component, OnInit, Inject } from '@angular/core';
import { ValidationErrors } from 'src/server-models/error/error-details.model';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { CRUD } from 'src/business/shared/crud.enum';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { take, concatMap, map } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UserService } from 'src/business/services/feature-services/user.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AthleteCreateEditComponent } from 'src/app/features/athlete-management/athletes-home/athlete-create-edit/athlete-create-edit.component';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { ServerStatusCodes } from 'src/server-models/error/status-codes/server.codes';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { selectedTraining } from 'src/ngrx/training/training.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { trainingUpdated } from 'src/ngrx/training/training.actions';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';

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

    if (this.setsCount.value > this.exercise.sets) {// add
      let sets = [];

      for(var i = 0; i < this.setsCount.value; i++) {
        sets.push(new Set());
      };

      this.exercise.sets.push(...sets);
    } else { // delete starting from last one
      for(var i = 0; i < this.setsCount.value; i++) {
        this.exercise.sets.pop();
      };
    }

    this.updateTraining(false, this.exercise);
  }

  updateTraining(newExercise: boolean, exercise: Exercise) {
    this.store.select(selectedTraining).pipe(
      take(1),
      map(training => Object.assign({}, training)),
      concatMap((training: Training) => {
        training.exercises = newExercise ? [...training.exercises, this.exercise] : training.exercises.map(exercise => exercise.id == this.exercise.id ? this.exercise : exercise);
        return this.trainingService.update(training);
      }),
      take(1)
    ).subscribe((training: Training) => {
      this.store.dispatch(trainingUpdated({ training }));
      this.onClose(exercise);
    });
  }
}