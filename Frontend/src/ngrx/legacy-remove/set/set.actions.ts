import { Dictionary, Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { Set } from '../../../server-models/entities/set.model';


export const setCreated = createAction(
    '[Set] Created',
    props<{ entity: Set}>()
)

export const normalizeSets = createAction(
    '[Set] Normalize sets',
    props<{ exerciseId: string, sets: Set[], originalIds: string[] }>()
)

export const setsFetched = createAction(
    '[Set] Fetched',
    props<{ entities: Dictionary<Set>, ids: string[] }>()
)

export const setUpdated = createAction(
    '[Set] Updated',
    props<{ entity: Update<Set> }>()
)

export const manySetsUpdated = createAction(
    '[Set] Many updated',
    props<{ entities: Dictionary<Set>, ids: string[], idsToRemove: string[] }>()
)

export const setDeleted = createAction(
    '[Set] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderSets = createAction(
    '[Set] Reorder',
    props<{ itemToReplace: string, itemToReplaceWith: string }>()
)

// SELECT
export const setSelectedSet = createAction(
    '[Set] Set selected',
    props<{ entity: Set }>()
)
