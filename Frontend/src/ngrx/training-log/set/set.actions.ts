
import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { Set } from 'src/server-models/entities/set.model';


export const setCreated = createAction(
    '[Set] Created',
    props<{ entity: Set}>()
)

export const setPropertiesFetched = createAction(
    '[Set] Fetched',
    props<{ entities: Set[] }>()
)

export const setUpdated = createAction(
    '[Set] Updated',
    props<{ entity: Update<Set> }>()
)

export const manySetPropertiesUpdated = createAction(
    '[Set] Many updated',
    props<{ entities: Update<Set>[] }>()
)

export const setDeleted = createAction(
    '[Set] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderSetProperties = createAction(
    '[Set] Reorder',
    props<{ itemToReplace: string, itemToReplaceWith: string }>()
)

// SELECT
export const setSelectedSet = createAction(
    '[Set] Set selected',
    props<{ entity: Set }>()
)
