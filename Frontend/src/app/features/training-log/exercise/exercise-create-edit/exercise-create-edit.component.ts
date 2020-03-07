import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { debounceTime, distinct, finalize, skip, switchMap, take, tap } from 'rxjs/operators';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training.actions';
import { selectedTraining } from 'src/ngrx/training-log/training.selectors';
import { CreateExerciseRequest } from 'src/server-models/cqrs/exercise/create-exercise.request';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Set } from 'src/server-models/entities/set.model';
import { Training } from 'src/server-models/entities/training.model';
import { PagedList } from 'src/server-models/shared/paged-list.model';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-exercise-create-edit',
  templateUrl: './exercise-create-edit.component.html',
  styleUrls: ['./exercise-create-edit.component.scss']
})
export class ExerciseCreateEditComponent implements OnInit {

  constructor(
    private exerciseTypeService: ExerciseTypeService,
    private store: Store<AppState>,
    private exerciseService: ExerciseService,
    private trainingService: TrainingService,
    private dialogRef: MatDialogRef<ExerciseCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD,
      exercise: Exercise,
      exerciseTypes: PagedList<ExerciseType>,
      pagingModel: PagingModel
    }) { }

  form: FormGroup;
  exercise: Exercise;

  private _subs = new SubSink();
  private _userId: string;

  isLoading = false;

  ngOnInit() {

    this.exercise = Object.assign(new Exercise(), this.data.exercise);

    this.createForm();

    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);
  }

  createForm() {
    this.form = new FormGroup({
      exerciseType: new FormControl(this.exercise.exerciseType, Validators.required),
      setsCount: new FormControl(this.exercise.sets ? this.exercise.sets.length : 0, [Validators.required, Validators.min(0), Validators.max(30)]),
    });

    this.addListeners();
  }

  get exerciseType(): AbstractControl { return this.form.get('exerciseType'); }
  get setsCount(): AbstractControl { return this.form.get('setsCount'); }
  displayFunction = (exerciseType: ExerciseType) => exerciseType ? exerciseType.name : null;

  addListeners = () => {
    this._subs.add(
      this.exerciseTypeChangeSubscription()
    );
  }

  exerciseTypeChangeSubscription = () => {
    return this.exerciseType.valueChanges
      .pipe(
        debounceTime(500),
        distinct(),
        skip(1),
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
          console.log(data);
          this.data.exerciseTypes = data;
        }
      )
  }

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
    request.order = this.exercise.order;

    // select training for id
    this.store.select(selectedTraining)
      .pipe(
        take(1),
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
