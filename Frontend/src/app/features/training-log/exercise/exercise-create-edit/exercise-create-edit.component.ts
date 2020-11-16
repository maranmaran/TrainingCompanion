import { CreateExerciseTypeRequest } from './../../../../../server-models/cqrs/exercise-type/create-exercise-type.request';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import * as _ from 'lodash-es';
import { debounceTime, distinct, filter, finalize, skip, switchMap, take, tap, map } from 'rxjs/operators';
import { isExerciseTypeValidator } from 'src/app/features/training-program/training-program-home/workout-filler/block-day/block-training/block-exercise-create-edit/block-exercise-create-edit.component';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training.actions';
import { selectedTraining } from 'src/ngrx/training-log/training.selectors';
import { CreateExerciseRequest } from 'src/server-models/cqrs/exercise/create-exercise.request';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Set } from 'src/server-models/entities/set.model';
import { Training } from 'src/server-models/entities/training.model';
import { PagedList } from 'src/server-models/shared/paged-list.model';
import { SubSink } from 'subsink';
import { ExerciseType } from './../../../../../server-models/entities/exercise-type.model';
import { MatCheckboxChange } from '@angular/material/checkbox';

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

  quickAddMode = false;

  ngOnInit() {

    this.exercise = Object.assign(new Exercise(), this.data.exercise);

    this.createForm();

    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);
  }

  createForm() {
    this.form = new FormGroup({
      exerciseType: new FormControl(this.exercise.exerciseType, [Validators.required, isExerciseTypeValidator]),
      setsCount: new FormControl(this.exercise.sets ? this.exercise.sets.length : 0, [Validators.required, Validators.min(0), Validators.max(30)]),
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
        filter(val => _.isString(val)),
        tap(() => {
          this.isLoading = true;
        }),
        switchMap(val => {
          console.log(val);
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
    if(this.quickAddMode == false) {
      this.createExercise(this.exerciseType.value.id);
    } else {
      this.createExerciseType()
      .pipe(take(1), map((type: ExerciseType) => type.id))
      .subscribe(typeId => {
        this.createExercise(typeId);
      })
    }
  }

  onClose(exercise?: Exercise) {
    this.dialogRef.close(exercise);
  }

  
  public get isValid() : boolean {

    const quickAddValid = this.name.valid;
    const typeAddValid = this.exerciseType.valid;

    return (quickAddValid || typeAddValid) && this.setsCount.valid;
  }

  //#region Create exercise type
  createExerciseType() {
    if(this.name.valid == false)
      return;
    
    const request = new CreateExerciseTypeRequest({
      name: this.name.value,
      applicationUserId: this._userId,
      requiresWeight: this.requiresWeight.value,
      requiresBodyweight: this.requiresBodyweight.value,
      requiresReps: this.requiresReps.value,
      requiresSets: this.requiresSets.value,
      requiresTime: this.requiresTime.value,
    });

    return this.exerciseTypeService.create(request);
  }

  get name(): AbstractControl {
    return this.form.get("name");
  }
  get requiresWeight(): AbstractControl {
    return this.form.get("requiresWeight");
  }
  get requiresBodyweight(): AbstractControl {
    return this.form.get("requiresBodyweight");
  }
  get requiresReps(): AbstractControl {
    return this.form.get("requiresReps");
  }
  get requiresSets(): AbstractControl {
    return this.form.get("requiresSets");
  }
  get requiresTime(): AbstractControl {
    return this.form.get("requiresTime");
  }

  onCheckboxChange(change: MatCheckboxChange) {
    switch (change.source.name) {
      case 'time':
        this.requiresReps.value && change.checked && this.requiresReps.setValue(false);
        break;
      case 'weight':
        this.requiresBodyweight.value && change.checked && this.requiresBodyweight.setValue(false);
        break;
      case 'bodyweight':
        this.requiresWeight.value && change.checked && this.requiresWeight.setValue(false);
        break;
      case 'reps':
        this.requiresTime.value && change.checked && this.requiresTime.setValue(false);
        break;
      default:
        throw new Error('No checkbox like that defined ' + change.source);
    }
  }
  //#endregion

  //#region Create exercise
  createExercise(typeId) {

    // make new sets
    let sets = [];
    for (var i = 0; i < this.setsCount.value; i++) {
      sets.push(new Set());
    };

    // create request
    var request = new CreateExerciseRequest();
    request.exerciseTypeId = typeId;
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
            return this.exerciseService.create<CreateExerciseRequest>(request)
            .pipe(map(exercise => ({ training, exercise })));
          },
          // result selector so we can have inner and outer variables from switchmap
          // (training, exercise) => ({ training, exercise }),
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
  //#endregion
  
}
