import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppState } from '../global-setup.ngrx';

@Injectable()
export class PersonalBestEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }


    }
