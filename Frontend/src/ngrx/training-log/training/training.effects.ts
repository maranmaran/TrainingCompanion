import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import * as TrainingActions from './training.actions';
import * as ExerciseActions from './../exercise/exercise.actions';
import * as SetActions from './../set/set.actions';
import { tap } from 'rxjs/operators';
import { Training } from 'src/server-models/entities/training.model';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import { normalize } from 'normalizr';
import { trainingsSchema, normalizeTrainingArray } from '../training-log.normalizer';

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

                var normalized = normalizeTrainingArray(payload.trainings);

                this.store.dispatch(TrainingActions.trainingsFetched({ entities: normalized.entities.trainings, ids: normalized.ids.trainingIds }))
                this.store.dispatch(ExerciseActions.exercisesFetched({ entities: normalized.entities.exercises, ids: normalized.ids.exerciseIds }))
                this.store.dispatch(SetActions.setsFetched({ entities: normalized.entities.sets, ids: normalized.ids.setIds }))
            })
        )
        , { dispatch: false });

    trainingSelected$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(TrainingActions.setSelectedTraining),
                tap((payload) => {
                    if (payload.training) {
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
                    if (payload.exercise) {
                        localStorage.setItem(LocalStorageKeys.exerciseId, payload.exercise.id);
                    } else {
                        localStorage.removeItem(LocalStorageKeys.exerciseId);
                    }
                })
            )
        , { dispatch: false });

}
