import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';

export interface AuthState {
    currentUser: CurrentUser,
    loginError: Error,
}

export const initialAuthState: AuthState = {
    currentUser: undefined,
    loginError: undefined,
};
