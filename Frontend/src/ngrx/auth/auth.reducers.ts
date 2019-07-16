import { initialAuthState, AuthState } from './auth.state';
import { AuthActions } from './auth.action-types';
import { on, createReducer } from '@ngrx/store';

export const authReducer = createReducer(
    initialAuthState,
    
    on(AuthActions.login, (state, action) => {
        return {
            currentUser: action.currentUser
        }
    }),

    on(AuthActions.logout, (state, action) => {
        return {
            currentUser: undefined
        }
    }),

    on(AuthActions.loginFailure, (state, action) => {
        return {
            currentUser: state.currentUser,
            error: action.payload.error
        }
    })
);