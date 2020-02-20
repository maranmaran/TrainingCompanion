import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, EffectNotification, ofType, OnRunEffects } from '@ngrx/effects';
import { Action, ActionReducer, createAction, createFeatureSelector, createReducer, createSelector, on, Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { catchError, exhaustMap, finalize, map, switchMap, take, takeUntil } from 'rxjs/operators';
import { AuthService } from 'src/business/services/feature-services/auth.service';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { fetchCurrentUser, updateCurrentUser } from './auth/auth.actions';
import { AppState } from './global-setup.ngrx';

// ACTIONS
export const startAppInitializer = createAction('[App initializer] START')
export const stopAppInitializer = createAction('[App initializer] STOP')
export const appInitialized = createAction('[App initializer] INITIALIZED')

// STATE
export const initialAppInitializeState = false;

//REDUCER
export const appInitializeReducer: ActionReducer<boolean, Action> = createReducer(
    initialAppInitializeState,
    on(appInitialized, () => true)
)

//SELECTORS
export const selectAppInitializedState = createFeatureSelector<boolean>("appInitialized");

export const isAppInitialized = createSelector(
    selectAppInitializedState,
    (state: boolean) => state
);

//EFFECT
@Injectable()
export class AppInitializeEffects implements OnRunEffects {

    constructor(
        private router: Router,
        private authService: AuthService,
        private actions$: Actions,
        private store: Store<AppState>) { }

    fetchCurrentUser$ = createEffect(() =>
        this.actions$.pipe(
            ofType(fetchCurrentUser),
            switchMap(() => {

                return this.authService.getCurrentUserInfo()
                    .pipe(
                        take(1),
                        catchError(() => {
                            this.router.navigate(['/auth/login']);
                            return of(null);
                        }),
                        map(((currentUser: CurrentUser) => {
                            currentUser && this.store.dispatch(updateCurrentUser(currentUser));
                        })),
                        finalize(() => this.store.dispatch(appInitialized()))
                    );

            }))
        , { dispatch: false, resubscribeOnError: false });


    ngrxOnRunEffects(resolvedEffects$: Observable<EffectNotification>) {
        return this.actions$
            .pipe(
                ofType(startAppInitializer),
                exhaustMap(() =>
                    resolvedEffects$.pipe(
                        takeUntil(this.actions$.pipe(ofType(stopAppInitializer)))
                    )
                )
            );
    }
}
