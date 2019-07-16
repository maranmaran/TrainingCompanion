import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthActions } from './auth.action-types';
import { Actions, createEffect, ofType } from '@ngrx/effects';


@Injectable()
export class AuthEffects {

    login$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.login),
                tap(action =>
                    console.log('Logout effect')
                )
            )
        ,
        { dispatch: false });

    logout$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.logout),
                tap(action => {
                    console.log('Logout effect')
                })
            )
        , { dispatch: false });


    constructor(private actions$: Actions,
        private router: Router) {

    }

}
