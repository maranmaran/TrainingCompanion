import { createReducer } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { UIState, initialUIState } from './ui.state';

export const uiReducer: ActionReducer<UIState, Action> = createReducer(
    initialUIState,
    

);