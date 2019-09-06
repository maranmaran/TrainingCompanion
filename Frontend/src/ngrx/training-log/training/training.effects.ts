import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import * as TrainingActions from './training.actions';
import { tap } from 'rxjs/operators';
import { Training } from 'src/server-models/entities/training.model';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';

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
                    if(payload.training) {
                        localStorage.setItem(LocalStorageKeys.trainingId, payload.training.id);
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
                    if(payload.exercise) {
                        localStorage.setItem(LocalStorageKeys.exerciseId, payload.exercise.id);
                    } else {
                        localStorage.removeItem(LocalStorageKeys.exerciseId);
                    }
                })
            )
        , { dispatch: false });

}
