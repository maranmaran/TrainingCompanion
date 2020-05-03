import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

export interface AuthState {
    currentUser: CurrentUser,
    loginError: Error,
    viewAsMode: boolean,
    viewAs: ApplicationUser
}

export const initialAuthState: AuthState = {
    currentUser: undefined,
    loginError: undefined,
    viewAs: undefined,
    viewAsMode: false,
};
