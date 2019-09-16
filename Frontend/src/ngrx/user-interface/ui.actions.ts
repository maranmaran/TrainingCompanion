import { TrainingLogTabGroup1, TrainingLogTabGroup2, TrainingLogTab } from './../../app/features/training-log/training-log-home/training-log-home.component';
import { createAction, props } from '@ngrx/store';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';

export const httpErrorOccured = createAction('[Http request] Error', (errorMessage: string = 'Something went wrong') => ({ errorMessage }));

export const httpRequestStartLoading = createAction('[Http request] Start Loading');
export const httpRequestStopLoading = createAction('[Http request] Stop Loading');

export const enableErrorDialogs = createAction('[Error dialogs] Enable')
export const disableErrorDialogs = createAction('[Error dialogs] Disable')

export const setActiveProgressBar = createAction('[Progress bar] Set Active', props<{ progressBar: UIProgressBar}>())

export const switchTheme = createAction('[Theme] Change theme', props<{theme: Theme}>() )

export const setMobileScreenFlag = createAction('[Screen width] Set mobile', props<{ isMobile: boolean}>());
export const setWebScreenFlag = createAction('[Screen width] Set web', props<{ isWeb: boolean}>());

export const setTab = createAction('[Training Log Tab UI] Set Tab', props<{index: TrainingLogTabGroup1 | TrainingLogTabGroup2, tab: TrainingLogTab}>())