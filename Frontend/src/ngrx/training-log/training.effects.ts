import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { concatMap, map, switchMap, take, tap } from 'rxjs/operators';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Training } from 'src/server-models/entities/training.model';
import { ExerciseService } from './../../business/services/feature-services/exercise.service';
import * as TrainingActions from './training.actions';
import { selectedTraining } from './training.selectors';

@Injectable()
export class TrainingEffects {

  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private exerciseService: ExerciseService
  ) { }

  trainingSelected$ = createEffect(() =>
    this.actions$
      .pipe(
        ofType(TrainingActions.setSelectedTraining),
        tap((payload) => {
          if (payload.entity) {
            localStorage.setItem(LocalStorageKeys.trainingId, payload.entity.id);
          } else {
            localStorage.removeItem(LocalStorageKeys.trainingId);
          }
        })
      )
    , { dispatch: false });

  trainingAdded$ = createEffect(() =>
    this.actions$
      .pipe(
        ofType(TrainingActions.trainingCreated),
        tap((payload) => {
          if (payload.entity) {
            localStorage.setItem(LocalStorageKeys.trainingId, payload.entity.id);
          } else {
            localStorage.removeItem(LocalStorageKeys.trainingId);
          }
        })
      )
    , { dispatch: false });

  exerciseSelected$ = createEffect(() =>
    this.actions$
      .pipe(
        ofType(TrainingActions.setSelectedExercise),
        tap((payload) => {
          if (payload.entity) {
            localStorage.setItem(LocalStorageKeys.exerciseId, payload.entity.id);
          } else {
            localStorage.removeItem(LocalStorageKeys.exerciseId);
          }
        })
      )
    , { dispatch: false });

  reorderExercise$ = createEffect(() =>
    this.actions$
      .pipe(
        ofType(TrainingActions.reorderExercises),
        concatMap(_ => this.store.select(selectedTraining).pipe(take(1))),
        switchMap(training => {
          return this.exerciseService.updateMany(training.exercises)
            .pipe(
              take(1),
              map(_ => {

                let updateStatement: Update<Training>;
                updateStatement = { id: training.id, changes: { exercises: training.exercises } }

                return this.store.dispatch(TrainingActions.trainingUpdated({ entity: updateStatement }))
              }))
        })
      )
    , { dispatch: false });

}
