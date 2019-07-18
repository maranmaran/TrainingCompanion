import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { Theme } from 'src/business/models/theme.enum';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';

export interface UIState {
    theme: Theme,
    showErrorSnackbar: boolean,
    httpRequestLoading: boolean,
    httpErrorMessage: string,
    activeProgressBar: UIProgressBar
}

export const initialUIState: UIState = {
    theme: Theme.Light,
    showErrorSnackbar: true,
    httpRequestLoading: false,
    httpErrorMessage: undefined,
    activeProgressBar: UIProgressBar.MainApp
};
