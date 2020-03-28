import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { TrainingLogTab, TrainingLogTabGroup1, TrainingLogTabGroup2 } from 'src/app/features/training-log/training-log-home/training-log-home.component';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { Theme } from '../../business/shared/theme.enum';
import * as UIActions from './ui.actions';
import { initialUIState, UIState } from './ui.state';

export const uiReducer: ActionReducer<UIState, Action> = createReducer(
    initialUIState,

    // error snackbar
    on(UIActions.disableErrorDialogs, (state: UIState) => {
        return {
            ...state,
            showErrorDialogs: false
        }
    }),
    on(UIActions.enableErrorDialogs, (state: UIState) => {
        return {
            ...state,
            showErrorDialogs: true
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
        }
    }),

    // set progress bar which is active
    on(UIActions.setActiveProgressBar, (state: UIState, payload: { progressBar: UIProgressBar }) => {
        return {
            ...state,
            activeProgressBar: payload.progressBar,
        }
    }),

    // theme switching
    on(UIActions.switchTheme, (state: UIState, payload: { theme: Theme }) => {
        return {
            ...state,
            theme: payload.theme,
        }
    }),

    on(UIActions.setMobileScreenFlag, (state: UIState, payload: { isMobile: boolean }) => {

        return {
            ...state,
            isMobile: payload.isMobile
        }
    }),

    on(UIActions.setWebScreenFlag, (state: UIState, payload: { isWeb: boolean }) => {

        return {
            ...state,
            isMobile: !payload.isWeb
        }
    }),

    on(UIActions.setTab, (state: UIState, payload: { index: TrainingLogTabGroup1 | TrainingLogTabGroup2, tab: TrainingLogTab}) => {
        return {
            ...state,
            trainingLogTabs: payload
        }
    }),

);
