import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import * as _ from "lodash";
import { sortBy } from 'src/business/utils/utils';
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { Tag } from '../../server-models/entities/tag.model';
import * as TagGroupActions from './tag-group.actions';
import { adapterTag, adapterTagGroup, tagGroupInitialState, TagGroupState } from './tag-group.state';

export const tagGroupReducer: ActionReducer<TagGroupState, Action> = createReducer(
    tagGroupInitialState,

    // CREATE
    on(TagGroupActions.tagGroupCreated, (state: TagGroupState, payload: { tagGroup: TagGroup }) => {
        return adapterTagGroup.addOne(payload.tagGroup, state);
    }),

    // UPDATE
    on(TagGroupActions.tagGroupUpdated, (state: TagGroupState, payload: { tagGroup: Update<TagGroup> }) => {
        return adapterTagGroup.updateOne(payload.tagGroup, state);
    }),

    // UPDATE MANY
    on(TagGroupActions.manyTagGroupsUpdated, (state: TagGroupState, payload: { tagGroups: Update<TagGroup>[] }) => {
        return adapterTagGroup.updateMany(payload.tagGroups, state);
    }),

    // DELETE
    on(TagGroupActions.tagGroupDeleted, (state: TagGroupState, payload: { id: string }) => {
        return adapterTagGroup.removeOne(payload.id, state);
    }),

    // GET ALL
    on(TagGroupActions.tagGroupsFetched, (state: TagGroupState, payload: { tagGroups: TagGroup[] }) => {
        return adapterTagGroup.addMany(payload.tagGroups, { ...state, selectedTypeId: null });
    }),

    // SET SELECTED
    on(TagGroupActions.setSelectedTagGroup, (state: TagGroupState, payload: { tagGroup: TagGroup }) => {
        return {
            ...state,
            selectedTypeId: payload.tagGroup ? adapterTagGroup.selectId(payload.tagGroup) : null,
            selectedPropertyId: null
        }
    }),
    on(TagGroupActions.setSelectedTag, (state: TagGroupState, payload: { property: Tag }) => {
        return {
            ...state,
            selectedPropertyId: payload.property ? adapterTag.selectId(payload.property) : null,
        }
    }),

    // REORDER
    on(TagGroupActions.reorderTagGroups, (state: TagGroupState, payload: { previousItem: string, currentItem: string }) => {

        // pluck types
        const first = state.entities[payload.previousItem];
        const second = state.entities[payload.currentItem];

        // temp
        let firstOrder = first.order;
        let secondOrder = second.order;

        // update statements
        const firstUpdate: Update<TagGroup> = {
            id: first.id,
            changes: { order: secondOrder }
        }
        const secondUpdate: Update<TagGroup> = {
            id: second.id,
            changes: { order: firstOrder }
        }

        // update
        return adapterTagGroup.updateMany([firstUpdate, secondUpdate], state);
    }),
    on(TagGroupActions.reorderTags, (state: TagGroupState, payload: { previousItem: string, currentItem: string }) => {

        // pluck types
        let first: Tag;
        let second: Tag;
        let parent: TagGroup;

        for(let parentId of state.ids) {
          let parentTemp = state.entities[parentId];

          for(let tag of parentTemp.tags) {

            if(tag.id == payload.previousItem) {
              first = Object.assign(new Tag(), tag);
              parent = _.cloneDeep(parentTemp);
            }
            if(tag.id == payload.currentItem) {
              second = Object.assign(new Tag(), tag);
            }

          }
        }

        // switch
        let firstOrder = first.order;
        let secondOrder = second.order;

        first.order = secondOrder;
        second.order = firstOrder;

        // map to parent for update
        parent.tags = parent.tags.map(x => x.id == first.id ? first : x);
        parent.tags = parent.tags.map(x => x.id == second.id ? second : x);

        parent.tags = sortBy(parent.tags, ["order"]);

        // update statements
        const update: Update<TagGroup> = {
            id: parent.id,
            changes: { tags: parent.tags }
        }

        // // update
        return adapterTagGroup.updateOne(update, state);
    }),
);

export const getSelectedTypeId = (state: TagGroupState) => state.selectedTypeId;
export const getSelectedPropertyId = (state: TagGroupState) => state.selectedPropertyId;

// get the selectors
export const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
} = adapterTagGroup.getSelectors();

// select the array of ids
export const selectTypeIds = selectIds;

// select the dictionary of entities
export const selectTypeEntities = selectEntities;

// select the array of entity objects
export const selectAllTypes = selectAll;

// select the total entity count
export const selectTypeTotal = selectTotal;
