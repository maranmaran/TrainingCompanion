import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { UIState, initialUIState } from './ui.state';
import * as UIActions from './ui.actions';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';

export const uiReducer: ActionReducer<UIState, Action> = createReducer(
    initialUIState,
    
    // error snackbar 
    on(UIActions.disableErrorSnackbar, (state: UIState) => {
        return {
            ...state,
            showErrorSnackbar: false
        }   
    }),
    on(UIActions.enableErrorSnackbar, (state: UIState) => {
        return {
            ...state,
            showErrorSnackbar: true
        }   
    }),

    // http requests loading
    on(UIActions.httpRequestStartLoading, (state: UIState) => {
        return {
            ...state,
            httpRequestLoading: true,
        }   
    }),
    on(UIActions.httpRequestStopLoading, (state: UIState) => {
        return {
            ...state,
            httpRequestLoading: false,
            activeProgressBar: UIProgressBar.MainApp // fallback to default progress bar
        }   
    }),

    // set progress bar which is active
    on(UIActions.setActiveProgressBar, (state: UIState, payload: { progressBar: UIProgressBar }) => {
        return {
            ...state,
            activeProgressBar: payload.progressBar,
        }   
    }),

);