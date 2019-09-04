import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';

export const exercisePropertyCreated = createAction(
    '[Exercise property] Created',
    props<{ entity: ExerciseProperty}>()
)

export const exercisePropertiesFetched = createAction(
    '[Exercise property] Fetched',
    props<{ entities: ExerciseProperty[] }>()
)

export const exercisePropertyUpdated = createAction(
    '[Exercise property] Updated',
    props<{ entity: Update<ExerciseProperty> }>()
)

export const manyExercisePropertiesUpdated = createAction(
    '[Exercise property] Many updated',
    props<{ entities: Update<ExerciseProperty>[] }>()
)

export const exercisePropertyDeleted = createAction(
    '[Exercise property] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderExerciseProperties = createAction(
    '[Exercise property] Reorder',
    props<{ itemToReplace: string, itemToReplaceWith: string }>()
)

// SELECT
export const setSelectedExerciseProperty = createAction(
    '[Exercise property] Set selected',
    props<{ entity: ExerciseProperty }>()
)
