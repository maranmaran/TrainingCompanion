import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { tap } from 'rxjs/operators';
import * as UIActions from './ui.actions';
import { Store } from '@ngrx/store';
import { AppState } from '../global-setup.ngrx';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';


@Injectable()
export class UIEffects {

    constructor(
        private store: Store<AppState>,
        private actions$: Actions,
    ) { }

    httpStopLoading$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(UIActions.httpRequestStopLoading),
                tap(() => {
                    this.store.dispatch(UIActions.enableErrorSnackbar());
                })
            )
        , { dispatch: false });

  

}
