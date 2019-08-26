import { createAction, props } from "@ngrx/store";
import { Training } from 'src/server-models/entities/training.model';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/requests/update-training.request';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/requests/create-training.request';

// CREATE
export const createTraining = createAction(
    '[Trainings API] Create',
    props<{ request: CreateTrainingRequest}>()
)
export const trainingCreated = createAction(
    '[Trainings] Created',
    props<{ training: Training}>()
)

// GET ALL
export const getAllTraining = createAction(
    '[Trainings API] Get all',
    props<{ userId: string, typeId: string }>()
)
export const trainingsFetched = createAction(
    '[Trainings] Fetched',
    props<{ trainings: Training[] }>()
)
   
// UPDATE
export const updateTraining = createAction(
    '[Trainings API] Update',
    props<{ request: UpdateTrainingRequest }>()
)
export const trainingUpdated = createAction(
    '[Trainings] Updated',
    props<{ training: Training }>()
)
   
// UPDATE MANY
export const updateManyTraining = createAction(
    '[Trainings API] Update many',
    props<{ trainings: Training[] }>()
)
export const manyExercisePropertiesUpdated = createAction(
    '[Trainings] Many updated',
    props<{ trainings: Training[] }>()
)

// DELETE
export const deleteTraining = createAction(
    '[Trainings API] Delete',
    props<{ id: string }>()
)
export const trainingDeleted = createAction(
    '[Trainings] Deleted',
    props<{ id: string }>()
)

// SELECT
export const setSelectedTraining = createAction(
    '[Trainings] Set selected',
    props<{ training: Training }>()
)

