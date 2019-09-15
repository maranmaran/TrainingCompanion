import { Update, Dictionary } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { Exercise } from 'src/server-models/entities/exercise.model';


export const exerciseCreated = createAction(
    '[Exercise] Created',
    props<{ entity: Dictionary<Exercise>, id: string }>()
)

export const normalizeExercise = createAction(
    '[Exercise] Normalize',
    props<{exercise: Exercise}>()
)

export const exercisesFetched = createAction(
    '[Exercise] Fetched',
    props<{ entities: Dictionary<Exercise>, ids: string[] }>()
)

export const exerciseUpdated = createAction(
    '[Exercise] Updated',
    props<{ entity: Dictionary<Exercise>, id: string }>()
)

export const manyExercisesUpdated = createAction(
    '[Exercise] Many updated',
    props<{ entities: Update<Exercise>[] }>()
)

export const exerciseDeleted = createAction(
    '[Exercise] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderExercises = createAction(
    '[Exercise] Reorder',
    props<{ itemToReplace: string, itemToReplaceWith: string }>()
)

// SELECT
export const setSelectedExercise = createAction(
    '[Exercise] Set selected',
    props<{ entity: Exercise }>()
)
