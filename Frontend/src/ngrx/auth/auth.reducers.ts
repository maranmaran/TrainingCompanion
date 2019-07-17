import { initialAuthState, AuthState } from './auth.state';
import { AuthActions } from './auth.action-types';
import { on, createReducer } from '@ngrx/store';
import { TypedAction, Action, ActionReducer } from '@ngrx/store/src/models';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { currentUser } from './auth.selectors';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';

export const authReducer: ActionReducer<AuthState, Action> = createReducer(
    initialAuthState,

    on(AuthActions.login, (state: AuthState, action) => {
        return {
            ...state,
            currentUser: action.currentUser
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