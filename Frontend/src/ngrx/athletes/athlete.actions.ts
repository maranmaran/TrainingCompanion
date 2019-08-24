import { UpdateUserRequest } from './../../server-models/cqrs/users/requests/update-user.request';
import { CreateUserRequest } from './../../server-models/cqrs/users/requests/create-user.request';
import { createAction, props } from "@ngrx/store";
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

// CREATE
// export const createAthlete = createAction(
//     '[Athlete API] Create',
//     props<{ request: CreateUserRequest}>()
// )
export const athleteCreated = createAction(
    '[Athlete] Created',
    props<{ athlete: ApplicationUser}>()
)

// GET ALL
// export const getAllAthlete = createAction(
//     '[Athlete API] Get all',
//     props<{ userId: string }>()
// )
export const athletesFetched = createAction(
    '[Athlete] Fetched',
    props<{ athletes: ApplicationUser[] }>()
)
   
// UPDATE
// export const updateAthlete = createAction(
//     '[Athlete API] Update',
//     props<{ request: UpdateUserRequest }>()
// )
export const athleteUpdated = createAction(
    '[Athlete] Updated',
    props<{ athlete: ApplicationUser }>()
)

// DELETE
// export const deleteAthlete = createAction(
//     '[Athlete API] Delete',
//     props<{ id: string }>()
// )
export const athleteDeleted = createAction(
    '[Athlete] Deleted',
    props<{ id: string }>()
)

// SELECT
export const setSelectedAthlete = createAction(
    '[Athlete] Set selected',
    props<{ athlete: ApplicationUser }>()
)

