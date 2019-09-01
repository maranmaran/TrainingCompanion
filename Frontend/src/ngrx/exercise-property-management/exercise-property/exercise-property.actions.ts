import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';


// CREATE
export const exercisePropertyCreated = createAction(
    '[Exercise property] Created',
    props<{ property: ExerciseProperty}>()
)

// GET ALL
export const exercisePropertiesFetched = createAction(
    '[Exercise property] Fetched',
    props<{  properties: ExerciseProperty[] }>()
)

// UPDATE
export const exercisePropertyUpdated = createAction(
    '[Exercise property] Updated',
    props<{ property: Update<ExerciseProperty> }>()
)
   
// UPDATE MANY
export const manyExercisePropertiesUpdated = createAction(
    '[Exercise property] Many updated',
    props<{ properties: Update<ExerciseProperty>[] }>()
)

// DELETE
export const exercisePropertyDeleted = createAction(
    '[Exercise property] Deleted',
    props<{ id: string }>()
)

// SELECT
export const setSelectedExerciseProperty = createAction(
    '[Exercise property] Set selected',
    props<{ property: ExerciseProperty }>()
)



// CREATE
// export const createExercisePropertyType = createAction(
//     '[Exercise property API] Create',
//     props<{ request: CreateExercisePropertyTypeRequest}>()
// )
// GET ALL
// export const getAllExercisePropertyType = createAction(
//     '[Exercise property API] Get all',
//     props<{ userId: string, typeId: string }>()
// )
// UPDATE
// export const updateExercisePropertyType = createAction(
//     '[Exercise property API] Update',
//     props<{ request: UpdateExercisePropertyTypeRequest }>()
// )
// UPDATE MANY
// export const updateManyExercisePropertyType = createAction(
//     '[Exercise property API] Update many',
//     props<{ propertyTypes: ExercisePropertyType[] }>()
// )
// DELETE
// export const deleteExercisePropertyType = createAction(
//     '[Exercise property API] Delete',
//     props<{ id: string }>()
// )