import { createAction, props } from '@ngrx/store';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { TrainingLogTab, TrainingLogTabGroup1, TrainingLogTabGroup2 } from './../../app/features/training-log/training-log-home/training-log-home.component';
import { genericErrorMessage } from './../../business/utils/messages.utils';

export const httpErrorOccured = createAction('[Http request] Error', (errorMessage: string = genericErrorMessage()) => ({ errorMessage }));

export const httpRequestStartLoading = createAction('[Http request] Start Loading');
export const httpRequestStopLoading = createAction('[Http request] Stop Loading');

export const enableErrorDialogs = createAction('[Error dialogs] Enable')
export const disableErrorDialogs = createAction('[Error dialogs] Disable')

export const setActiveProgressBar = createAction('[Progress bar] Set Active', props<{ progressBar: UIProgressBar}>())

export const switchTheme = createAction('[Theme] Change theme', props<{theme: Theme}>() )

export const setMobileScreenFlag = createAction('[Screen width] Set mobile', props<{ isMobile: boolean}>());
export const setWebScreenFlag = createAction('[Screen width] Set web', props<{ isWeb: boolean}>());

export const setTab = createAction('[Training Log Tab UI] Set Tab', props<{index: TrainingLogTabGroup1 | TrainingLogTabGroup2, tab: TrainingLogTab}>())
export const setLanguage = createAction('[Language] Set language', props<{language: string}>())
