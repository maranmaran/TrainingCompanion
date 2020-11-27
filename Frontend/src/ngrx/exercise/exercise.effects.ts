import { AppState } from './../global-setup.ngrx';
import { LocalStorageKeys } from './../../business/shared/localstorage.keys.enum';
import { exercises } from './exercise.selectors';
import { tap, concatMap, switchMap, take } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import * as ExerciseActions from './exercise.actions';
import { ExerciseService } from './../../business/services/feature-services/exercise.service';

@Injectable()
export class ExerciseEffects {

  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private exerciseService: ExerciseService
  ) { }

  exerciseSelected$ = createEffect(() => this.actions$
    .pipe(
      ofType(ExerciseActions.setSelectedExercise),
      tap((payload) => {
        if (payload.entity) {
          localStorage.setItem(LocalStorageKeys.exerciseId, payload.entity.id);
        } else {
          localStorage.removeItem(LocalStorageKeys.exerciseId);
        }
      })
    ),
    { dispatch: false });

  reorderExercise$ = createEffect(() => this.actions$
    .pipe(
      ofType(ExerciseActions.reorderExercises),
      concatMap(_ => this.store.select(exercises).pipe(take(1))),
      switchMap(exercises => {
        return this.exerciseService.updateMany(exercises)
          .pipe(
            take(1)
          );
      })
    ),
    { dispatch: false });

}
