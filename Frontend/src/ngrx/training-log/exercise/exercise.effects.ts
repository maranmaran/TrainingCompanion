import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import * as ExerciseActions from './exercise.actions';
import * as SetActions from './../set/set.actions';
import { tap } from 'rxjs/operators';
import { normalizeExercises } from '../training-log.normalizer';
import { CRUD } from 'src/business/shared/crud.enum';

@Injectable()
export class ExerciseEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }

    exercisesNormalized$ = createEffect(() =>
    this.actions$.pipe(
        ofType(ExerciseActions.normalizeExercise),
        tap(payload => {

            var normalized = normalizeExercises([payload.exercise]);

            switch(payload.action) {

                case CRUD.Create:
                    this.store.dispatch(
                        ExerciseActions.exerciseCreated(
                            { entity: normalized.entities.exercises, id: normalized.ids.exerciseIds[0] }));
                    this.store.dispatch(
                        SetActions.setsFetched(
                            { entities: normalized.entities.sets, ids: normalized.ids.setIds }));
                    return;

                case CRUD.Read:
                    this.store.dispatch(
                        ExerciseActions.exercisesFetched(
                            { entities: normalized.entities.exercises, ids: normalized.ids.exerciseIds }));
                    this.store.dispatch(
                        SetActions.setsFetched(
                            { entities: normalized.entities.sets, ids: normalized.ids.setIds }));
                    return;
            } 
        })
    )
    , { dispatch: false });
}
