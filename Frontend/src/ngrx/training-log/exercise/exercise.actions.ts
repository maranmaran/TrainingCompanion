import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { Exercise } from 'src/server-models/entities/exercise.model';


export const exerciseCreated = createAction(
    '[Exercise] Created',
    props<{ entity: Exercise}>()
)

export const exercisePropertiesFetched = createAction(
    '[Exercise] Fetched',
    props<{ entities: Exercise[] }>()
)

export const exerciseUpdated = createAction(
    '[Exercise] Updated',
    props<{ entity: Update<Exercise> }>()
)

export const manyExercisePropertiesUpdated = createAction(
    '[Exercise] Many updated',
    props<{ entities: Update<Exercise>[] }>()
)

export const exerciseDeleted = createAction(
    '[Exercise] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderExerciseProperties = createAction(
    '[Exercise] Reorder',
    props<{ itemToReplace: string, itemToReplaceWith: string }>()
)

// SELECT
export const setSelectedExercise = createAction(
    '[Exercise] Set selected',
    props<{ entity: Exercise }>()
)
