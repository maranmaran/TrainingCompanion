import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/operators';
import { setSelectedExercise, setSelectedTraining } from 'src/ngrx/training-log/training.actions';
import { AppState } from '../../global-setup.ngrx';
import * as BlockDayActions from './training-block-day.actions';

@Injectable()
export class TrainingBlockDayEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }

    setSelected$ = createEffect(() =>
    this.actions$
      .pipe(
          ofType(BlockDayActions.setSelectedTrainingBlockDay),
          tap(_ => {
            this.store.dispatch(setSelectedTraining({entity:null}));
            this.store.dispatch(setSelectedExercise({entity:null}));
          }),
        )
    , { dispatch: false });
}
