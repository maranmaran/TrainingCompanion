import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { Theme } from 'src/app/core/ng-chat/core/theme.enum';

export interface UIState {
    theme: Theme,
    showErrorSnackbar: boolean,
    httpRequestLoading: boolean,
    httpErrorMessage: string,
    
}

export const initialUIState: UIState = {
    theme: Theme.Light,
    showErrorSnackbar: true,
    httpRequestLoading: false,
    httpErrorMessage: undefined,
};
