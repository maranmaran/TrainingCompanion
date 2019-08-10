import { createAction, props } from "@ngrx/store";
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

export const athletesFetched = createAction(
    '[Athletes API] Athletes fetched',
    props<{ athletes: ApplicationUser[]}>()
)

export const deactivateAthlete = createAction(
    '[Athletes API] Deactivate athlete'
)

export const activateAthlete = createAction(
    '[Athletes API] Activate athlete'
)

export const registerAthlete = createAction(
    '[Athletes API] Register athlete',
    props<ApplicationUser>()
)

export const setSelectedAthlete = createAction(
    '[Athletes API] Set selected athlete',
    props<{athlete: ApplicationUser}>()
)
