import { AppState } from 'src/ngrx/global-setup.ngrx';
import { logout, login } from './auth/auth.actions';
import { ActionReducer, Action } from '@ngrx/store';

export const clearState = (reducer: ActionReducer<AppState>): ActionReducer<AppState> => {
    return (state: AppState, action: Action): AppState => {

        if (action.type === logout().type) {
            state = undefined;
        }

        return reducer(state, action);
    };
}