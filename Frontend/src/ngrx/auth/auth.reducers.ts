import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import * as AuthActions from './auth.actions';
import { AuthState, initialAuthState } from './auth.state';

export const authReducer: ActionReducer<AuthState, Action> = createReducer(
    initialAuthState,

    on(AuthActions.login, (state: AuthState, currentUser: CurrentUser) => {
        return {
            ...state,
            currentUser: currentUser
        }
    }),

    on(AuthActions.logout, (state: AuthState) => {
        return {
            ...state,
            currentUser: undefined
        }
    }),

    on(AuthActions.updateUserSettings, (state: AuthState, userSettings: UserSettings) => {
        return {
            ...state,
            currentUser: { 
                ...state.currentUser,
                userSettings: userSettings 
            }
        }
    }),

    on(AuthActions.cancelSubscription, (state: AuthState) => {
        return {
            ...state,
            currentUser: {
                ...state.currentUser,
                subscriptionInfo: {
                    ...state.currentUser.subscriptionInfo,
                    status: SubscriptionStatus[SubscriptionStatus.canceled] 
                }
            }
        };
    }),

    on(AuthActions.addSubscription, (state: AuthState, subscriptionInfo: Subscription) => {
        return {
            ...state,
            currentUser: {
                ...state.currentUser,
                subscriptionInfo: subscriptionInfo
            }
        };
    }),

    on(AuthActions.updateCurrentUser, (state: AuthState, currentUser: CurrentUser) => {
        return {
            ...state,
            currentUser: currentUser
        };
    }),

);