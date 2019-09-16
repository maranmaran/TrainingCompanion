import { Injectable, enableProdMode } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/operators';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { normalizeTrainingArray } from '../training-log.normalizer';
import * as ExerciseActions from './../exercise/exercise.actions';
import * as SetActions from './../set/set.actions';
import * as TrainingActions from '../training/training.actions';
import { CRUD } from 'src/business/shared/crud.enum';

@Injectable()
export class TrainingEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }

    trainingsNormalized$ = createEffect(() =>
        this.actions$.pipe(
            ofType(TrainingActions.normalizeTrainings),
            tap(payload => {

                var normalized = normalizeTrainingArray(payload.entities);

                
            switch(payload.action) {

                case CRUD.Read:
                        this.store.dispatch(TrainingActions.trainingsFetched({ entities: normalized.entities.trainings, ids: normalized.ids.trainingIds }))
                        this.store.dispatch(ExerciseActions.exercisesFetched({ entities: normalized.entities.exercises, ids: normalized.ids.exerciseIds }))
                        this.store.dispatch(SetActions.setsFetched({ entities: normalized.entities.sets, ids: normalized.ids.setIds }))
                    return;
            } 

               
            })
        )
        , { dispatch: false });

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
                ofType(ExerciseActions.setSelectedExercise),
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
