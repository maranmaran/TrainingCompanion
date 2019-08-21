import { CreateExercisePropertyRequest } from '../../../server-models/cqrs/exercise-property/requests/create-exercise-property.request';
import { createAction, props } from "@ngrx/store";
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import { UpdateExercisePropertyRequest } from 'src/server-models/cqrs/exercise-property/requests/update-exercise-property.request';

// CREATE
export const createExerciseProperty = createAction(
    '[Exericse Property API] Create',
    props<{ request: CreateExercisePropertyRequest}>()
)
export const exercisePropertyCreated = createAction(
    '[Exercise property] Created',
    props<{ property: ExerciseProperty}>()
)

// GET ALL
export const getAllExerciseProperty = createAction(
    '[Exericse Property API] Get all',
    props<{ userId: string, typeId: string }>()
)
export const exercisePropertiesFetched = createAction(
    '[Exericse Property] Fetched',
    props<{  properties: ExerciseProperty[] }>()
)
   
// UPDATE
export const updateExerciseProperty = createAction(
    '[Exericse Property API] Update',
    props<{ request: UpdateExercisePropertyRequest }>()
)
export const exercisePropertyUpdated = createAction(
    '[Exericse Property] Updated',
    props<{ property: ExerciseProperty }>()
)
   
// UPDATE MANY
export const updateManyExerciseProperty = createAction(
    '[Exericse Property API] Update many',
    props<{ properties: ExerciseProperty[] }>()
)
export const manyExercisePropertiesUpdated = createAction(
    '[Exericse Property] Many updated',
    props<{ properties: ExerciseProperty[] }>()
)

// DELETE
export const deleteExerciseProperty = createAction(
    '[Exericse Property API] Delete',
    props<{ id: string }>()
)
export const exercisePropertyDeleted = createAction(
    '[Exericse Property] Deleted',
    props<{ id: string }>()
)

