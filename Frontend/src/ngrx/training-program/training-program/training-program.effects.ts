import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/operators';
import { setSelectedTrainingBlock } from 'src/ngrx/training-program/training-block/training-block.actions';
import { AppState } from '../../global-setup.ngrx';
import { setSelectedTrainingBlockDay } from '../training-block-day/training-block-day.actions';
import { setSelectedExercise, setSelectedTraining } from './../../training-log/training.actions';
import * as ProgramActions from './training-program.actions';

@Injectable()
export class TrainingProgramEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }


    setSelectedProgram$ = createEffect(() =>
    this.actions$
      .pipe(
          ofType(ProgramActions.setSelectedTrainingProgram),
          tap(_ => {
            this.store.dispatch(setSelectedTrainingBlock({entity: null}));
            this.store.dispatch(setSelectedTrainingBlockDay({entity: null}));
            this.store.dispatch(setSelectedTraining({entity:null}));
            this.store.dispatch(setSelectedExercise({entity:null}));
          }),
        )
    , { dispatch: false });


}
