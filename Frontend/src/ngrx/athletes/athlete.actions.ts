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

export const updateAthlete = createAction(
    '[Athletes API] Update athlete',
    props<ApplicationUser>()
)

export const deleteAthlete = createAction(
    '[Athletes API] Delete athlete',
    props<ApplicationUser>()
)

export const deleteAthletes = createAction(
    '[Athletes API] Delete athletes',
    props<ApplicationUser[]>()
)

export const setSelectedAthlete = createAction(
    '[Athletes API] Set selected athlete',
    props<{athlete: ApplicationUser}>()
)
