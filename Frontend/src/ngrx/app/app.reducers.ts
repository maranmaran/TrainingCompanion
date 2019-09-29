import * as AppActions from './app.actions';
import { Action, createReducer, on, ActionReducer } from '@ngrx/store';
import { appInitialState, AppState } from './app.state';

export const appReducer: ActionReducer<AppState, Action> = createReducer(
    appInitialState,

    // CREATE
    on(AppActions.tagsChanged, (state: AppState) => {
        return {
            ...state,
            tagsChanged: true
        }
    })

)
