import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/operators';
import { setSelectedTrainingBlock } from 'src/ngrx/training-program/training-block/training-block.actions';
import { AppState } from '../../global-setup.ngrx';
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
            this.store.dispatch(setSelectedTrainingBlock({entity: null}))
          }),
        )
    , { dispatch: false });


}
