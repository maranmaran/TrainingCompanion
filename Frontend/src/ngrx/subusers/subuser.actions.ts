import { createAction, props } from "@ngrx/store";
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

export const subusersFetched = createAction(
    '[Subusers API] Subusers fetched',
    props<{ subusers: ApplicationUser[]}>()
)

export const subuserAdded = createAction(
    '[Subusers API] Subuser created',
    props<ApplicationUser>()
)

export const subuserUpdated = createAction(
    '[Subusers API] Subuser updated',
    props<ApplicationUser>()
)

export const subuserDeleted = createAction(
    '[Subusers API] Subuser deleted',
    props<ApplicationUser>()
)

