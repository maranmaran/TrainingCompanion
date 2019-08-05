import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { CookieService } from 'ngx-cookie-service';
import { of } from 'rxjs';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { AppState } from '../global-setup.ngrx';
import { switchTheme } from '../user-interface/ui.actions';
import { AuthService } from './../../business/services/auth.service';
import { SignInRequest } from './../../server-models/cqrs/authorization/requests/sign-in.request';
import * as AuthActions from './auth.actions';


@Injectable()
export class AuthEffects {

    constructor(
        private actions$: Actions,
        private router: Router,
        private cookieService: CookieService,
        private store: Store<AppState>,
        private authService: AuthService
    ) { }

    login$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.login),
                switchMap((request: SignInRequest) => this.authService.signIn(request).pipe(
                    map((currentUser: CurrentUser) => this.store.dispatch(AuthActions.loginSuccess(currentUser))),
                    catchError((error: Error) => of(this.store.dispatch(AuthActions.loginFailure(error))))
                ))
            )
        , { dispatch: false });

    loginSuccess$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.loginSuccess),
                tap((currentUser: CurrentUser) => {
                    localStorage.setItem('id', currentUser.id);
                    this.router.navigate(['/']);
                    this.store.dispatch(switchTheme({ theme: currentUser.userSettings.theme }));
                })
            )
        , { dispatch: false });

    logout$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.logout),
                tap(() => {
                    this.authService.signOutEvent.next(true);
                    localStorage.removeItem('id');
                    this.cookieService.delete('jwt');
                    this.router.navigate(['/auth/login']);
                })
            )
        , { dispatch: false });

    updateUserSettings$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.updateUserSettings),
                tap((userSettings: UserSettings) => {
                    this.store.dispatch(switchTheme({ theme: userSettings.theme }));
                })
            )
        , { dispatch: false });

    updateCurrentUser$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.updateCurrentUser),
                tap((currentUser: CurrentUser) => {
                    this.store.dispatch(switchTheme({ theme: currentUser.userSettings.theme }));
                })
            )
        , { dispatch: false });
}
