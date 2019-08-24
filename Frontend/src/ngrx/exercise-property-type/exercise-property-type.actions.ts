import { createAction, props } from "@ngrx/store";
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { CreateExercisePropertyTypeRequest } from 'src/server-models/cqrs/exercise-property-type/requests/create-exercise-property-type.request';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { UpdateExercisePropertyTypeRequest } from 'src/server-models/cqrs/exercise-property-type/requests/update-exercise-property-type.request';

// CREATE
export const createExercisePropertyType = createAction(
    '[Exericse Property API] Create',
    props<{ request: CreateExercisePropertyTypeRequest}>()
)
export const exercisePropertyTypeCreated = createAction(
    '[Exercise property] Created',
    props<{ propertyType: ExercisePropertyType}>()
)

// GET ALL
export const getAllExercisePropertyType = createAction(
    '[Exericse Property API] Get all',
    props<{ userId: string, typeId: string }>()
)
export const exercisePropertyTypesFetched = createAction(
    '[Exericse Property] Fetched',
    props<{ propertyTypes: ExercisePropertyType[] }>()
)
   
// UPDATE
export const updateExercisePropertyType = createAction(
    '[Exericse Property API] Update',
    props<{ request: UpdateExercisePropertyTypeRequest }>()
)
export const exercisePropertyTypeUpdated = createAction(
    '[Exericse Property] Updated',
    props<{ propertyType: ExercisePropertyType }>()
)
   
// UPDATE MANY
export const updateManyExercisePropertyType = createAction(
    '[Exericse Property API] Update many',
    props<{ propertyTypes: ExercisePropertyType[] }>()
)
export const manyExercisePropertiesUpdated = createAction(
    '[Exericse Property] Many updated',
    props<{ propertyTypes: ExercisePropertyType[] }>()
)

// DELETE
export const deleteExercisePropertyType = createAction(
    '[Exericse Property API] Delete',
    props<{ id: string }>()
)
export const exercisePropertyTypeDeleted = createAction(
    '[Exericse Property] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderExercisePropertyTypes = createAction(
    '[Exericse Property] Reorder',
    props<{ previousItem: string, currentItem: string }>()
)

// SELECT
export const setSelectedExercisePropertyType = createAction(
    '[Exericse Property] Set selected',
    props<{ propertyType: ExercisePropertyType }>()
)

