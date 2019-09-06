import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';

@Injectable()
export class ExerciseEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }

}
