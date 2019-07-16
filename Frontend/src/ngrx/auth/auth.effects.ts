import { AuthService } from './../../business/services/auth.service';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthActions } from './auth.action-types';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { CookieService } from 'ngx-cookie-service';


@Injectable()
export class AuthEffects {

    login$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.login),
                tap(action =>{
                    // this.router.navigate(['/']);
                })
            )
        ,
        { dispatch: false });

    logout$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.logout),
                tap(action => {
                    localStorage.removeItem('id');
                    this.cookieService.delete('jwt');
                    this.router.navigate(['/auth/login']);
                })
            )
        , { dispatch: false });


    constructor(
        private actions$: Actions,
        private router: Router,
        private cookieService: CookieService
       ) {

    }

}
