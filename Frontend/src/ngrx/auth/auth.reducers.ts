import { ApplicationUser } from './../../server-models/entities/application-user.model';
import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { UserSetting } from 'src/server-models/entities/user-settings.model';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import * as AuthActions from './auth.actions';
import { AuthState, initialAuthState } from './auth.state';
import * as _ from 'lodash';
import { AccountType } from 'src/server-models/enums/account-type.enum';

export const authReducer: ActionReducer<AuthState, Action> = createReducer(
    initialAuthState,

    on(AuthActions.loginSuccess, (state: AuthState, currentUser: CurrentUser) => {
        return {
            ...state,
            currentUser: currentUser
        }
    }),

    on(AuthActions.loginFailure, (state: AuthState, error: Error) => {
        return {
            ...state,
            loginError: error
        }
    }),

    on(AuthActions.updateUserSetting, (state: AuthState, userSetting: UserSetting) => {
        return {
            ...state,
            currentUser: {
                ...state.currentUser,
                userSetting: userSetting
            }
        }
    }),

    on(AuthActions.cancelSubscription, (state: AuthState) => {
        return {
            ...state,
            currentUser: {
                ...state.currentUser,
                subscriptionInfo: undefined,
                subscriptionStatus: SubscriptionStatus.canceled
            }
        };
    }),

    on(AuthActions.addSubscription, (state: AuthState, subscriptionInfo: Subscription) => {
        return {
            ...state,
            currentUser: {
                ...state.currentUser,
                subscriptionInfo: subscriptionInfo,
                subscriptionStatus: SubscriptionStatus[subscriptionInfo.status]
            }
        };
    }),

    on(AuthActions.updateCurrentUser, (state: AuthState, currentUser: CurrentUser) => {
        return {
            ...state,
            currentUser: currentUser
        };
    }),

    on(AuthActions.setViewAs, (state: AuthState, payload: { entity: ApplicationUser }) => {

        // let currentUser = _.cloneDeep(state.currentUser);
        // if (payload.entity) {
        //     currentUser.id = payload.entity.id;
        // }

        return {
            ...state,
            // currentUser,
            viewAsMode: !!payload.entity,
            viewAs: payload.entity
        }
    }),

);
