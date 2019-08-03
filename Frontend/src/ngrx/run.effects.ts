import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, Effect, EffectNotification, ofType, OnRunEffects, createEffect } from '@ngrx/effects';
import { createAction, Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { catchError, exhaustMap, map, switchMap, take, takeUntil, mergeMap, tap, concatMap, finalize } from 'rxjs/operators';
import { AuthService } from 'src/business/services/auth.service';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { updateCurrentUser, currentUserFetched } from './auth/auth.actions';
import { AppState } from './global-setup.ngrx';
import { disableErrorSnackbar, setActiveProgressBar } from './user-interface/ui.actions';


export const startAppInitializer = createAction('[App initializer] START')
export const stopAppInitializer = createAction('[App initializer] STOP')
export const loadCurrentUser = createAction('[Auth API] Load current user')

@Injectable()
export class RunEffects implements OnRunEffects {

    constructor(
        private router: Router,
        private authService: AuthService,
        private actions$: Actions,
        private store: Store<AppState>) { }

    onRun$ = createEffect(() =>
        this.actions$.pipe(
            ofType(loadCurrentUser),
            concatMap(() => {

                this.store.dispatch(disableErrorSnackbar());
                this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.SplashScreen }));

                return this.authService.getCurrentUserInfo()
                    .pipe(
                        take(1),
                        catchError((error) => {
                            this.router.navigate(['/auth/login']);
                            return of(null);
                        }),
                        map(((currentUser: CurrentUser) => {
                            this.store.dispatch(updateCurrentUser(currentUser));
                            this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.MainAppScreen }));
                        })));

            }))
        , { dispatch: false });


    ngrxOnRunEffects(resolvedEffects$: Observable<EffectNotification>) {
        return this.actions$
            .pipe(
                ofType(startAppInitializer),
                exhaustMap(() =>
                    resolvedEffects$
                        .pipe(
                            takeUntil(this.actions$.pipe(ofType(stopAppInitializer)))
                        )
                )
            );
    }
}
