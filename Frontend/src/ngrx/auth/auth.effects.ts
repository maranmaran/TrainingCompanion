import { AuthService } from './../../business/services/auth.service';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import * as AuthActions from './auth.actions';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { CookieService } from 'ngx-cookie-service';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';


@Injectable()
export class AuthEffects {

    constructor(
        private actions$: Actions,
        private router: Router,
        private cookieService: CookieService
    ) { }

    login$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.login),
                tap((currentUser: CurrentUser) => {
                    localStorage.setItem('id', currentUser.id);
                    this.router.navigate(['/']);
                })
            )
        , { dispatch: false });

    logout$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.logout),
                tap(() => {
                    localStorage.removeItem('id');
                    this.cookieService.delete('jwt');
                    this.router.navigate(['/auth/login']);
                })
            )
        , { dispatch: false });

}
