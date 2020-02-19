import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { Tag } from '../../server-models/entities/tag.model';


export const tagGroupCreated = createAction(
    '[Exercise property type] Created',
    props<{ tagGroup: TagGroup }>()
)

export const tagGroupsFetched = createAction(
    '[Exercise property type] Fetched',
    props<{ tagGroups: TagGroup[] }>()
)

export const tagGroupUpdated = createAction(
    '[Exercise property type] Updated',
    props<{ tagGroup: Update<TagGroup> }>()
)

export const manyTagGroupsUpdated = createAction(
    '[Exercise property type] Many updated',
    props<{ tagGroups: Update<TagGroup>[] }>()
)

export const tagGroupDeleted = createAction(
    '[Exercise property type] Deleted',
    props<{ id: string }>()
)

// REORDER
export const reorderTagGroups = createAction(
    '[Tag group] Reorder',
    props<{ previousItem: string, currentItem: string }>()
)
export const reorderTags = createAction(
    '[Tag] Reorder',
    props<{ previousItem: string, currentItem: string }>()
)

// SELECT
export const setSelectedTagGroup = createAction(
    '[Exercise property type] Set selected',
    props<{ tagGroup: TagGroup }>()
)
export const setSelectedTag = createAction(
    '[Exercise property] Set selected',
    props<{ property: Tag }>()
)

// CREATE
// export const createTagGroup = createAction(
//     '[Exercise property API] Create',
//     props<{ request: CreateTagGroupRequest}>()
// )
// GET ALL
// export const getAllTagGroup = createAction(
//     '[Exercise property API] Get all',
//     props<{ userId: string, typeId: string }>()
// )
// UPDATE
// export const updateTagGroup = createAction(
//     '[Exercise property API] Update',
//     props<{ request: UpdateTagGroupRequest }>()
// )
// UPDATE MANY
// export const updateManyTagGroup = createAction(
//     '[Exercise property API] Update many',
//     props<{ tagGroups: TagGroup[] }>()
// )
// DELETE
// export const deleteTagGroup = createAction(
//     '[Exercise property API] Delete',
//     props<{ id: string }>()
// )
