import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, switchMap, tap } from 'rxjs/operators';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import * as TrainingActions from './training.actions';
import { of } from 'rxjs'

@Injectable()
export class TrainingEffects {

  constructor(
    private actions$: Actions,
  ) { }

  trainingSelected$ = createEffect(() =>
    this.actions$
      .pipe(
        ofType(TrainingActions.setSelectedTraining),
        map(payload => payload?.id),
        tap((id) => {
          if (id) {
            localStorage.setItem(LocalStorageKeys.trainingId, id);
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


}
