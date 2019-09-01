import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';


@Injectable()
export class ExercisePropertyTypeEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }

}
