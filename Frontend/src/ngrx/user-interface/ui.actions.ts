import { HttpErrorResponse } from '@angular/common/http';
import { createAction, props } from '@ngrx/store';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';

export const httpErrorOccured = createAction('[Http request] Error', (errorMessage: string = 'Something went wrong') => ({ errorMessage }));

export const httpRequestStartLoading = createAction('[Http request] Start Loading');
export const httpRequestStopLoading = createAction('[Http request] Stop Loading');

export const enableErrorSnackbar = createAction('[Error snackbar] Enable')
export const disableErrorSnackbar = createAction('[Error snackbar] Disable')

export const setActiveProgressBar = createAction('[Progress bar] Set Active', props<{ progressBar: UIProgressBar}>())

export const switchTheme = createAction('[Theme] Change theme', props<{theme: Theme}>() )

export const setMobileScreenFlag = createAction('[Screen width] Set mobile', props<{ isMobile: boolean}>());
export const setWebScreenFlag = createAction('[Screen width] Set web', props<{ isWeb: boolean}>());