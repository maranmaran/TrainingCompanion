import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { UserService } from 'src/business/services/feature-services/user.service';
import { AppState } from '../global-setup.ngrx';

@Injectable()
export class NavigationsEffects {

    constructor(
        private actions$: Actions,
        private userService: UserService,
        private store: Store<AppState>
    ) { }
}
