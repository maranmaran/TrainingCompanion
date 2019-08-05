import { createAction, props } from "@ngrx/store";
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

export const subusersFetched = createAction(
    '[Subusers API] Subusers fetched',
    props<{ subusers: ApplicationUser[]}>()
)

export const deactivateSubuser = createAction(
    '[Subusers API] Deactivate subuser'
)

export const activateSubuser = createAction(
    '[Subusers API] Activate subuser'
)

export const registerSubuser = createAction(
    '[Subusers API] Register subuser',
    props<ApplicationUser>()
)

export const setSelectedSubuser = createAction(
    '[Subusers API] Set selected subuser',
    props<{subuser: ApplicationUser}>()
)
