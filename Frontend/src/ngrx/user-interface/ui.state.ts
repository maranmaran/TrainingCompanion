import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';

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
