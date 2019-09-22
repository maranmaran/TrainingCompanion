import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import * as TrainingActions from './training.actions';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import { tap } from 'rxjs/operators';

@Injectable()
export class TrainingEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
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

}
