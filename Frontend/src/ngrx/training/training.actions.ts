import { createAction, props } from "@ngrx/store";
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/requests/create-training.request';
import { Training } from 'src/server-models/entities/training.model';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/requests/update-training.request';

// CREATE
export const createTraining = createAction(
    '[Exercise type API] Create',
    props<{ request: CreateTrainingRequest}>()
)
export const trainingCreated = createAction(
    '[Exercise type] Created',
    props<{ training: Training}>()
)

// GET ALL
export const getAllTraining = createAction(
    '[Exercise type API] Get all',
    props<{ userId: string, typeId: string }>()
)
export const trainingsFetched = createAction(
    '[Exercise type] Fetched',
    props<{ trainings: Training[] }>()
)
   
// UPDATE
export const updateTraining = createAction(
    '[Exercise type API] Update',
    props<{ request: UpdateTrainingRequest }>()
)
export const trainingUpdated = createAction(
    '[Exercise type] Updated',
    props<{ training: Training }>()
)
   
// UPDATE MANY
export const updateManyTraining = createAction(
    '[Exercise type API] Update many',
    props<{ trainings: Training[] }>()
)
export const manyExercisePropertiesUpdated = createAction(
    '[Exercise type] Many updated',
    props<{ trainings: Training[] }>()
)

// DELETE
export const deleteTraining = createAction(
    '[Exercise type API] Delete',
    props<{ id: string }>()
)
export const trainingDeleted = createAction(
    '[Exercise type] Deleted',
    props<{ id: string }>()
)

// SELECT
export const setSelectedTraining = createAction(
    '[Exercise type] Set selected',
    props<{ training: Training }>()
)

