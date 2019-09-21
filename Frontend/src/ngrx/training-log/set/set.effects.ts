import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import * as SetActions from './set.actions';
import * as ExerciseActions from './../exercise/exercise.actions';
import { tap } from 'rxjs/operators';
import { CRUD } from 'src/business/shared/crud.enum';
import { normalize } from 'normalizr';
import { setsSchema } from '../training-log.normalizer';

@Injectable()
export class SetEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }

    setsNormalized$ = createEffect(() =>
        this.actions$.pipe(
            ofType(SetActions.normalizeSets),
            tap(payload => {
                var normalized = normalize(payload.sets, setsSchema);
                
                this.store.dispatch(
                    ExerciseActions.manySetsUpdated({exerciseId: payload.exerciseId, ids: normalized.result})
                );
                this.store.dispatch(
                    SetActions.manySetsUpdated(
                        { 
                            entities: normalized.entities.sets, 
                            ids: normalized.result,
                            idsToRemove: payload.originalIds.filter(x => !normalized.result.includes(x))
                        }));
            })
        )
        , { dispatch: false });
}
