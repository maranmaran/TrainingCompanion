import { Action, ActionReducer } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { logoutClearState } from './auth/auth.actions';

export const clearState = (reducer: ActionReducer<AppState>): ActionReducer<AppState> => {
    return (state: AppState, action: Action): AppState => {

        if (action.type === logoutClearState().type) {
            state = undefined;
        }

        return reducer(state, action);
    };
}
