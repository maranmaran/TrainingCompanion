import { MatSidenav } from '@angular/material/sidenav';
import { Theme } from 'src/business/models/theme.enum';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';
import { Dictionary } from 'src/business/utils/dictionary';

export interface UIState {
    theme: Theme,
    showErrorSnackbar: boolean,
    httpRequestLoading: boolean,
    httpErrorMessage: string,
    activeProgressBar: UIProgressBar,
    isMobile: boolean,
}

export const initialUIState: UIState = {
    theme: Theme.Light,
    showErrorSnackbar: true,
    httpRequestLoading: false,
    httpErrorMessage: undefined,
    activeProgressBar: UIProgressBar.MainAppScreen,
    isMobile: undefined
};
