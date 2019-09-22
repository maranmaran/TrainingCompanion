import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { Tag } from 'src/server-models/entities/tag.model';

export const tagCreated = createAction(
    '[Exercise property] Created',
    props<{ entity: Tag }>()
)

export const tagsFetched = createAction(
    '[Exercise property] Fetched',
    props<{ entities: Tag[] }>()
)

export const tagUpdated = createAction(
    '[Exercise property] Updated',
    props<{ entity: Update<Tag> }>()
)

export const manyExercisePropertiesUpdated = createAction(
    '[Exercise property] Many updated',
    props<{ entities: Update<Tag>[] }>()
)

export const tagDeleted = createAction(
    '[Exercise property] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderExerciseProperties = createAction(
    '[Exercise property] Reorder',
    props<{ itemToReplace: string, itemToReplaceWith: string }>()
)

// SELECT
export const setSelectedTag = createAction(
    '[Exercise property] Set selected',
    props<{ entity: Tag }>()
)
