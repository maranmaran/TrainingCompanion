import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AuthState } from './auth.state';

export const selectAuthState =
    createFeatureSelector<AuthState>("auth");

export const isLoggedIn = createSelector(
    selectAuthState,
    auth =>  !!auth.currentUser
);

export const isLoggedOut = createSelector(
    isLoggedIn,
    loggedIn => !loggedIn
);
