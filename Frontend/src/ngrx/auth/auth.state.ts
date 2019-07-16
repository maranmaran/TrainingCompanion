import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';

export interface AuthState {
    currentUser: CurrentUser,
    error: string
}

export const initialAuthState: AuthState = {
    currentUser: undefined,
    error: undefined
};
