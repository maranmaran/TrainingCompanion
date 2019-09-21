import { filter } from 'rxjs/operators';
import { map } from 'rxjs/internal/operators/map';
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
    on(SetActions.manySetsUpdated, (state: SetState, payload: { entities: Dictionary<Set>, ids: string[], idsToRemove: string[] }) => {
        // entities without those that need to be "updated"
        let ids = Object.assign([], state.ids) as string[];
        let entities = Object.assign({}, state.entities);
        payload.idsToRemove.forEach(id => {
            delete entities[id];
            ids.splice(ids.indexOf(id), 1);
        });

        return {
            ...state,
            entities: Object.assign({}, entities, payload.entities),
            ids: Object.assign({}, ids, payload.ids),
            selectedId: null
        }
    }),

    // DELETE
    on(SetActions.setDeleted, (state: SetState, payload: {id: string}) => {
        return adapterSet.removeOne(payload.id, state);
    }),

    // GET ALL
    on(SetActions.setsFetched, (state: SetState, payload: { entities: Dictionary<Set>, ids: string[] }) => {
        return {
            ...state,
            entities: Object.assign({}, state.entities, payload.entities),
            ids: Object.assign({}, state.ids, payload.ids),
        }
    }),

    // SET SELECTED
    on(SetActions.setSelectedSet, (state: SetState, payload: {entity: Set}) => {
        return {
            ...state,
            selectedId: payload.entity ? payload.entity.id : null,
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
 