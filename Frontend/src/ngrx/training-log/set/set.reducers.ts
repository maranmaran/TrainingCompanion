import { Update, Dictionary } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { Set } from 'src/server-models/entities/set.model';
import * as SetActions from './set.actions';
import { adapterSet, setInitialState, SetState } from './set.state';


export const setReducer: ActionReducer<SetState, Action> = createReducer(
    setInitialState,

    // CREATE
    on(SetActions.setCreated, (state: SetState, payload: {entity: Set}) => {
        return adapterSet.addOne(payload.entity, state);
    }),

    // UPDATE
    on(SetActions.setUpdated, (state: SetState, payload: {entity: Update<Set>}) => {
        return adapterSet.updateOne(payload.entity, state);
    }),

    // UPDATE MANY
    on(SetActions.manySetsUpdated, (state: SetState, payload: {entities: Update<Set>[]}) => {
        return adapterSet.updateMany(payload.entities, state);
    }),

    // DELETE
    on(SetActions.setDeleted, (state: SetState, payload: {id: string}) => {
        return adapterSet.removeOne(payload.id, state);
    }),

    // GET ALL
    on(SetActions.setsFetched, (state: SetState, payload: { entities: Dictionary<Set>, ids: string[] }) => {
        return {
            ...state,
            entities: payload.entities,
            ids: payload.ids
        }
    }),

    // SET SELECTED
    on(SetActions.setSelectedSet, (state: SetState, payload: {entity: Set}) => {
        return {
            ...state,
            selectedTypeId: payload.entity ? adapterSet.selectId(payload.entity) : null,
            selectedPropertyId: null
        }
    }),

);

export const getSelectedId = (state: SetState) => state.selectedId;
 
// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterSet.getSelectors();
 
// select the array of ids
export const selectTypeIds = selectIds;
 
// select the dictionary of entities
export const selectTypeEntities = selectEntities;
 
// select the array of entity objects
export const selectAllTypes = selectAll;
 
// select the total entity count
export const selectTypeTotal = selectTotal;