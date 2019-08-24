import { createAction, props } from "@ngrx/store";
import { CreateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/requests/create-exercise-type.request';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { UpdateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/requests/update-exercise-type.request';

// CREATE
export const createExerciseType = createAction(
    '[Exercise type API] Create',
    props<{ request: CreateExerciseTypeRequest}>()
)
export const exerciseTypeCreated = createAction(
    '[Exercise type] Created',
    props<{ exerciseType: ExerciseType}>()
)

// GET ALL
export const getAllExerciseType = createAction(
    '[Exercise type API] Get all',
    props<{ userId: string, typeId: string }>()
)
export const exerciseTypesFetched = createAction(
    '[Exercise type] Fetched',
    props<{ exerciseTypes: ExerciseType[] }>()
)
   
// UPDATE
export const updateExerciseType = createAction(
    '[Exercise type API] Update',
    props<{ request: UpdateExerciseTypeRequest }>()
)
export const exerciseTypeUpdated = createAction(
    '[Exercise type] Updated',
    props<{ exerciseType: ExerciseType }>()
)
   
// UPDATE MANY
export const updateManyExerciseType = createAction(
    '[Exercise type API] Update many',
    props<{ exerciseTypes: ExerciseType[] }>()
)
export const manyExercisePropertiesUpdated = createAction(
    '[Exercise type] Many updated',
    props<{ exerciseTypes: ExerciseType[] }>()
)

// DELETE
export const deleteExerciseType = createAction(
    '[Exercise type API] Delete',
    props<{ id: string }>()
)
export const exerciseTypeDeleted = createAction(
    '[Exercise type] Deleted',
    props<{ id: string }>()
)

// SELECT
export const setSelectedExerciseType = createAction(
    '[Exercise type] Set selected',
    props<{ exerciseType: ExerciseType }>()
)

