import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';


export const exercisePropertyTypeCreated = createAction(
    '[Exercise property type] Created',
    props<{ propertyType: ExercisePropertyType}>()
)

export const exercisePropertyTypesFetched = createAction(
    '[Exercise property type] Fetched',
    props<{ propertyTypes: ExercisePropertyType[] }>()
)

export const exercisePropertyTypeUpdated = createAction(
    '[Exercise property type] Updated',
    props<{ propertyType: Update<ExercisePropertyType> }>()
)

export const manyExercisePropertyTypesUpdated = createAction(
    '[Exercise property type] Many updated',
    props<{ propertyTypes: Update<ExercisePropertyType>[] }>()
)

export const exercisePropertyTypeDeleted = createAction(
    '[Exercise property type] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderExercisePropertyTypes = createAction(
    '[Exercise property type] Reorder',
    props<{ previousItem: string, currentItem: string }>()
)

// SELECT
export const setSelectedExercisePropertyType = createAction(
    '[Exercise property type] Set selected',
    props<{ propertyType: ExercisePropertyType }>()
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