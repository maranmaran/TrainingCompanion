import { createAction, props } from '@ngrx/store';
import { Theme } from 'src/app/core/ng-chat/core/theme.enum';

export const httpErrorOccured = createAction('[Http request] Error', (error = 'Something went wrong') => ({ error }));

export const httpRequestStartLoading = createAction('[Http request] Start Loading');
export const httpRequestStopLoading = createAction('[Http request] Stop Loading');

export const enableErrorSnackbar = createAction('[Error snackbar] Enable')
export const disableErrorSnackbar = createAction('[Error snackbar] Disable')

export const enableMainProgressBar = createAction('[Main progress bar] Enable')
export const disableMainProgressBar = createAction('[Main progress bar] Disable')

export const enableSettingsProgressCircle = createAction('[Settings progress bar] Enable')
export const disableSettingsProgressCircle = createAction('[Settings progress bar] Disable')

export const enableLoginProgressCircle = createAction('[Login progress bar] Enable')
export const disableLoginProgressCircle = createAction('[Login progress bar] Disable')

export const toggleSettingsSidenav = createAction('[Settings sidenav] Toggle')
export const closeSettingsSidenav = createAction('[Settings sidenav] Close')
export const openSettingsSidenav = createAction('[Settings sidenav] Open')

export const toggleAppSidenav = createAction('[Settings sidenav] Toggle')
export const closeAppSidenav = createAction('[Settings sidenav] Close')
export const openAppSidenav = createAction('[Settings sidenav] Open')

export const switchTheme = createAction('[Theme] Change theme', props<{theme: Theme}>() )
export const mobileScreenWidthTriggered = createAction('[Screen] Mobile screen')
