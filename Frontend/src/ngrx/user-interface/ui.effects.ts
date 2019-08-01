import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap, withLatestFrom } from 'rxjs/operators';
import { AppState } from '../global-setup.ngrx';
import { UIService } from './../../business/services/shared/ui.service';
import * as UIActions from './ui.actions';
import { showErrorDialogs } from './ui.selectors';


@Injectable()
export class UIEffects {

    constructor(
        private store: Store<AppState>,
        private actions$: Actions,
        private uiService: UIService
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

  
    httpError$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(UIActions.httpErrorOccured),
                withLatestFrom(this.store.select(showErrorDialogs)),
                tap(([error, showErrorDialogs]) => { 
                    showErrorDialogs && this.uiService.fadeOutMessage(`Something went wrong.`, 2000) // only do this effect if showErrorDialogs flag is on
                })
            )
        , { dispatch: false });

  

}
