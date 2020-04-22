import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/operators';
import { setSelectedExercise, setSelectedTraining } from 'src/ngrx/training-log/training.actions';
import { setSelectedTrainingBlockDay } from 'src/ngrx/training-program/training-block-day/training-block-day.actions';
import { AppState } from '../../global-setup.ngrx';
import * as BlockActions from './training-block.actions';

@Injectable()
export class TrainingBlockEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }

    setSelectedBlock$ = createEffect(() =>
    this.actions$
      .pipe(
          ofType(BlockActions.setSelectedTrainingBlock),
          tap(_ => {
            this.store.dispatch(setSelectedTrainingBlockDay({entity: null}))
            this.store.dispatch(setSelectedTraining({entity:null}));
            this.store.dispatch(setSelectedExercise({entity:null}));
          }),
        )
    , { dispatch: false });

}
