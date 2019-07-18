import { AuthService } from './../../business/services/auth.service';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import * as AuthActions from './auth.actions';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { CookieService } from 'ngx-cookie-service';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { Store } from '@ngrx/store';
import { AppState } from '../global-setup.ngrx';
import { switchTheme } from '../user-interface/ui.actions';
import { UserSettings } from 'src/server-models/entities/user-settings.model';


@Injectable()
export class AuthEffects {

    constructor(
        private actions$: Actions,
        private router: Router,
        private cookieService: CookieService,
        private store: Store<AppState>
    ) { }

    login$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.login),
                tap((currentUser: CurrentUser) => {
                    this.store.dispatch(switchTheme( { theme: currentUser.userSettings.theme } ));
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

    updateUserSettings$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.updateUserSettings),
                tap((userSettings: UserSettings) => {
                    this.store.dispatch(switchTheme( { theme: userSettings.theme } ));
                })
            )
        , { dispatch: false });

    updateCurrentUser$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(AuthActions.updateCurrentUser),
                tap((currentUser: CurrentUser) => {
                    this.store.dispatch(switchTheme( { theme: currentUser.userSettings.theme } ));
                })
            )
        , { dispatch: false });

}
