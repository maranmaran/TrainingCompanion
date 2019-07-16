import { createAction, props } from '@ngrx/store';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { AuthState } from './auth.state';

export const login = createAction(
    '[Auth API] Login',
    props<AuthState>()
)

export const logout = createAction(
    '[Auth API] Logout'
)

// export const loginFailure = createAction(
//     '[Auth API] Login Failure',
//     (error = 'Error logging in') => ({ payload: error})
//   );


