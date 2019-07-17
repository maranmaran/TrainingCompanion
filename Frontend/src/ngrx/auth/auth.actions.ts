import { createAction, props } from '@ngrx/store';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { AuthState } from './auth.state';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { Subscription } from 'src/server-models/stripe/subscription.model';

export const login = createAction(
    '[Auth API] Login',
    props<CurrentUser>()
)

export const logout = createAction(
    '[Auth API] Logout'
)

export const updateUserSettings = createAction(
    '[User API] Update user settings',
    props<UserSettings>()
)

export const cancelSubscription = createAction(
    '[Billing API] Cancel subscription'
)

export const addSubscription = createAction(
    '[Billing API] Add subscription',
    props<Subscription>()
)

export const updateCurrentUser = createAction(
    '[Auth API] Refresh current user',
    props<CurrentUser>()
)