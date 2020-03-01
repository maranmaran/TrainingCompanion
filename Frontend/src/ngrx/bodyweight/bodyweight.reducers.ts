import { Update } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { Bodyweight } from './../../server-models/entities/bodyweight.model';
import * as BodyweightActions from './bodyweight.actions';
import { adapterBodyweight, bodyweightInitialState, BodyweightState } from './bodyweight.state';

export const bodyweightReducer: ActionReducer<BodyweightState, Action> = createReducer(
  bodyweightInitialState,


  // CREATE
  on(BodyweightActions.bodyweightCreated, (state: BodyweightState, payload: { entity: Bodyweight }) => {
    return adapterBodyweight.addOne(payload.entity, state);
  }),

  // UPDATE
  on(BodyweightActions.bodyweightUpdated, (state: BodyweightState, payload: { entity: Update<Bodyweight> }) => {
    return adapterBodyweight.updateOne(payload.entity, state);
  }),

  // DELETE
  on(BodyweightActions.bodyweightDeleted, (state: BodyweightState, payload: { id: string }) => {
    return adapterBodyweight.removeOne(payload.id, state);
  }),

  // GET ALL
  on(BodyweightActions.bodyweightFetched, (state: BodyweightState, payload: { entities: Bodyweight[] }) => {
    return adapterBodyweight.addMany(payload.entities, state);
  }),

  // SET SELECTED
  on(BodyweightActions.setSelectedBodyweight, (state: BodyweightState, payload: { entity: Bodyweight }) => {
    return {
      ...state,
      selectedBodyweightId: payload.entity ? payload.entity.id : null,
    };
  }),

);

export const getSelectedBodyweightId = (state: BodyweightState) => state.selectedBodyweightId;

// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterBodyweight.getSelectors();


