import { createAction, props } from '@ngrx/store';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';

export const currentUserLoaded = createAction(
    '[Auth API] Current User Loaded',
    props<{user: CurrentUser}>()
)