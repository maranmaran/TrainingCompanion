import { initialAuthState, AuthState } from './auth.state';
import { AuthActions } from './auth.action-types';
import { on, createReducer } from '@ngrx/store';
import { TypedAction, Action, ActionReducer } from '@ngrx/store/src/models';

export const authReducer: ActionReducer<AuthState, Action> = createReducer(
    initialAuthState,
    
    on(AuthActions.login, (state: AuthState, action) => {
        return {
            currentUser: action.currentUser
        }
    }),

    on(AuthActions.logout, (state: AuthState, action) => {
        return {
            currentUser: undefined
        }
    }),

    // on(AuthActions.loginFailure, (state: AuthState, action) => {
    //     return {
    //         currentUser: state.currentUser,
    //         error: action.payload.error
    //     }
    // })
);