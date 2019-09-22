import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { Tag } from 'src/server-models/entities/tag.model';
import * as TagActions from './tag.actions';
import { adapterTag, tagInitialState, TagState } from './tag.state';


export const tagReducer: ActionReducer<TagState, Action> = createReducer(
    tagInitialState,

    // CREATE
    on(TagActions.tagCreated, (state: TagState, payload: { entity: Tag }) => {
        return adapterTag.addOne(payload.entity, state);
    }),

    // UPDATE
    on(TagActions.tagUpdated, (state: TagState, payload: { entity: Update<Tag> }) => {
        return adapterTag.updateOne(payload.entity, state);
    }),

    // UPDATE MANY
    on(TagActions.manyExercisePropertiesUpdated, (state: TagState, payload: { entities: Update<Tag>[] }) => {
        return adapterTag.updateMany(payload.entities, state);
    }),

    // DELETE
    on(TagActions.tagDeleted, (state: TagState, payload: { id: string }) => {
        return adapterTag.removeOne(payload.id, state);
    }),

    // GET ALL
    on(TagActions.tagsFetched, (state: TagState, payload: { entities: Tag[] }) => {
        return adapterTag.addMany(payload.entities, { ...state, selectedTypeId: null });
    }),

    // SET SELECTED
    on(TagActions.setSelectedTag, (state: TagState, payload: { entity: Tag }) => {
        return {
            ...state,
            selectedTypeId: payload.entity ? adapterTag.selectId(payload.entity) : null,
            selectedPropertyId: null
        }
    }),

    // REORDER
    on(TagActions.reorderExerciseProperties, (state: TagState, payload: { itemToReplace: string, itemToReplaceWith: string }) => {

        // pluck types
        const itemToReplace = state.entities[payload.itemToReplace];
        const itemToReplaceWith = state.entities[payload.itemToReplaceWith];

        // temp
        let firstOrder = itemToReplace.order;
        let secondOrder = itemToReplaceWith.order;

        // update statements
        const firstUpdate: Update<Tag> = {
            id: itemToReplace.id,
            changes: { order: secondOrder }
        }
        const secondUpdate: Update<Tag> = {
            id: itemToReplaceWith.id,
            changes: { order: firstOrder }
        }

        // update
        return adapterTag.updateMany([firstUpdate, secondUpdate], state);
    }),
);

export const getSelectedId = (state: TagState) => state.selectedId;

// get the selectors
export const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
} = adapterTag.getSelectors();

// select the array of ids
export const selectTypeIds = selectIds;

// select the dictionary of entities
export const selectTypeEntities = selectEntities;

// select the array of entity objects
export const selectAllTypes = selectAll;

// select the total entity count
export const selectTypeTotal = selectTotal;