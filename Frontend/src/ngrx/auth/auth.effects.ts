import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { CookieService } from 'ngx-cookie-service';
import { of } from 'rxjs';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { AuthService } from '../../business/services/feature-services/auth.service';
import { AppState } from '../global-setup.ngrx';
import { enableErrorDialogs, setActiveProgressBar, switchTheme } from '../user-interface/ui.actions';
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
  ) {}

  login$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(AuthActions.login),
        switchMap((request: SignInRequest) =>
          this.authService.signIn(request).pipe(
            map((currentUser: CurrentUser) =>
              this.store.dispatch(AuthActions.loginSuccess(currentUser))
            ),
            catchError((error: Error) =>
              of(this.store.dispatch(AuthActions.loginFailure(error)))
            )
          )
        )
      ),
    { dispatch: false }
  );

  loginSuccess$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(AuthActions.loginSuccess),
        // TODO: Deprecated
        switchMap(
          (currentUser: CurrentUser) => {
            localStorage.setItem('id', currentUser.id);
            return this.router.navigate(['/app']);
          },
          (currentUser, navigationSuccess) => ({ currentUser, navigationSuccess })
        ),
        tap(
          (response: { currentUser: CurrentUser; navigationSuccess: boolean; }) => {
            if (response.navigationSuccess) {
              this.store.dispatch(switchTheme({ theme: response.currentUser.userSettings.theme }));
              this.store.dispatch(enableErrorDialogs());
            }
          }
        )
      ),
    { dispatch: false }
  );

  logout$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(AuthActions.logout),
        tap(() => {
          this.authService.signOutEvent.next(true);
          localStorage.removeItem('id');
          this.cookieService.delete('jwt');
          this.router.navigate(['/auth/login']);
        })
      ),
    { dispatch: false }
  );

  updateUserSettings$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(AuthActions.updateUserSettings),
        tap((userSettings: UserSettings) => {
          this.store.dispatch(switchTheme({ theme: userSettings.theme }));
        })
      ),
    { dispatch: false }
  );

  updateCurrentUser$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(AuthActions.updateCurrentUser),
        tap((currentUser: CurrentUser) => {
          this.store.dispatch(
            setActiveProgressBar({ progressBar: UIProgressBar.MainAppScreen })
          );
          this.store.dispatch(
            switchTheme({ theme: currentUser.userSettings.theme })
          );
        })
      ),
    { dispatch: false }
  );
}
