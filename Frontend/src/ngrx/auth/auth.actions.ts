import { SignInRequest } from 'src/server-models/cqrs/authorization/requests/sign-in.request';
import { createAction, props } from '@ngrx/store';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { Subscription } from 'src/server-models/stripe/subscription.model';

//#region Login actions

export const login = createAction(
    '[Auth API] Login',
    props<SignInRequest>()
)

export const loginSuccess = createAction(
    '[Auth API] Login Success',
    props<CurrentUser>()
)

export const loginFailure = createAction(
    '[Auth API] Login Failure',
    props<Error>()
)

export const logout = createAction(
    '[Auth API] Logout'
)

//#endregion

//#region Current user actions

export const fetchCurrentUser = createAction(
    '[Auth API] Fetch current user'
)

export const updateCurrentUser = createAction(
    '[Auth API] Update current user',
    props<CurrentUser>()
)

//#endregion 

//#region Current user modifier actions


export const updateUserSettings = createAction(
    '[User API] Update user settings',
    props<UserSettings>()
)

export const addSubscription = createAction(
    '[Billing API] Add subscription',
    props<Subscription>()
)

export const cancelSubscription = createAction(
    '[Billing API] Cancel subscription'
)

//#endregion

