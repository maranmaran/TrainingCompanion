import { Update } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { PersonalBest } from './../../server-models/entities/personal-best.model';
import * as PersonalBestActions from './personal-best.actions';
import { adapterPersonalBest, personalBestInitialState, PersonalBestState } from './personal-best.state';

export const personalBestReducer: ActionReducer<PersonalBestState, Action> = createReducer(
  personalBestInitialState,


  // CREATE
  on(PersonalBestActions.personalBestCreated, (state: PersonalBestState, payload: { entity: PersonalBest }) => {
    return adapterPersonalBest.addOne(payload.entity, state);
  }),

  // UPDATE
  on(PersonalBestActions.personalBestUpdated, (state: PersonalBestState, payload: { entity: Update<PersonalBest> }) => {
    return adapterPersonalBest.updateOne(payload.entity, state);
  }),

  // DELETE
  on(PersonalBestActions.personalBestDeleted, (state: PersonalBestState, payload: { id: string }) => {
    return adapterPersonalBest.removeOne(payload.id, state);
  }),

  // GET ALL
  on(PersonalBestActions.personalBestFetched, (state: PersonalBestState, payload: { entities: PersonalBest[] }) => {
    return adapterPersonalBest.addMany(payload.entities, state);
  }),

  // SET SELECTED
  on(PersonalBestActions.setSelectedPersonalBest, (state: PersonalBestState, payload: { entity: PersonalBest }) => {
    return {
      ...state,
      selectedPersonalBestId: payload.entity ? payload.entity.id : null,
    };
  }),

);

export const getSelectedPersonalBestId = (state: PersonalBestState) => state.selectedPersonalBestId;

// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterPersonalBest.getSelectors();


