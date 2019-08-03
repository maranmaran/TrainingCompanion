import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AuthState } from './auth.state';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { AccountType } from 'src/server-models/enums/account-type.enum';

export const selectAuthState = createFeatureSelector<AuthState>("auth");

export const currentUser = createSelector(
    selectAuthState,
    (authState: AuthState) => authState.currentUser
);

export const userSettings = createSelector(
    currentUser,
    (currentUser: CurrentUser) => currentUser.userSettings
);

export const isLoggedIn = createSelector(
    selectAuthState,
    (authState: AuthState) =>  !!authState.currentUser
);

export const isLoggedOut = createSelector(
    isLoggedIn,
    (loggedIn: boolean) => !loggedIn
);

export const trialDaysRemaining = createSelector(
    currentUser,
    (currentUser: CurrentUser) => currentUser.trialDaysRemaining
);

export const subscriptionStatus = createSelector(
    currentUser,
    (currentUser: CurrentUser) => currentUser.subscriptionStatus
);

export const isSubscribed = createSelector(
    subscriptionStatus,
    (subStatus: SubscriptionStatus) => {
  
        switch (subStatus.toString().toLowerCase()) {
            case SubscriptionStatus.active:
                return true;
            default:
                return false;
        }
    }
);

export const isTrialing = createSelector(
    trialDaysRemaining,
    (daysRemaining: number) => daysRemaining > 0 ? true : false
);

export const isUser = createSelector(
    currentUser,
    (user: CurrentUser) => {
        const accountType = AccountType[user.accountType];
        return accountType == AccountType.User || accountType == AccountType.Admin;
    }
);
