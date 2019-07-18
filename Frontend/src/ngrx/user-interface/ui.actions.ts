import { UISidenav } from './../../business/models/ui-sidenavs.enum';
import { MatSidenav } from '@angular/material/sidenav';
import { createAction, props } from '@ngrx/store';
import { Theme } from 'src/business/models/theme.enum';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';

export const httpErrorOccured = createAction('[Http request] Error', (error = 'Something went wrong') => ({ error }));

export const httpRequestStartLoading = createAction('[Http request] Start Loading');
export const httpRequestStopLoading = createAction('[Http request] Stop Loading');

export const enableErrorSnackbar = createAction('[Error snackbar] Enable')
export const disableErrorSnackbar = createAction('[Error snackbar] Disable')

export const setActiveProgressBar = createAction('[Progress bar] Set Active', props<{ progressBar: UIProgressBar}>())

export const switchTheme = createAction('[Theme] Change theme', props<{theme: Theme}>() )

export const setMobileScreenFlag = createAction('[Screen width] Set mobile', props<{ isMobile: boolean}>());
export const setWebScreenFlag = createAction('[Screen width] Set web', props<{ isWeb: boolean}>());