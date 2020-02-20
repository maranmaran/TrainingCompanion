import { Update } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { ApplicationUser } from './../../server-models/entities/application-user.model';
import * as AthleteActions from './athlete.actions';
import { adapterAthlete, athleteInitialState, AthleteState } from './athlete.state';

export const athletesReducer: ActionReducer<AthleteState, Action> = createReducer(
  athleteInitialState,


  // CREATE
  on(AthleteActions.athleteCreated, (state: AthleteState, payload: { entity: ApplicationUser }) => {
    return adapterAthlete.addOne(payload.entity, state);
  }),

  // UPDATE
  on(AthleteActions.athleteUpdated, (state: AthleteState, payload: { entity: Update<ApplicationUser> }) => {
    return adapterAthlete.updateOne(payload.entity, state);
  }),

  // UPDATE MANY
  on(AthleteActions.manyAthletesUpdated, (state: AthleteState, payload: { entities: Update<ApplicationUser>[] }) => {
    return adapterAthlete.updateMany(payload.entities, state);
  }),

  // DELETE
  on(AthleteActions.athleteDeleted, (state: AthleteState, payload: { id: string }) => {
    return adapterAthlete.removeOne(payload.id, state);
  }),

  // GET ALL
  on(AthleteActions.athletesFetched, (state: AthleteState, payload: { entities: ApplicationUser[] }) => {
    return adapterAthlete.addMany(payload.entities, state);
  }),

  // SET SELECTED
  on(AthleteActions.setSelectedAthlete, (state: AthleteState, payload: { entity: ApplicationUser }) => {
    return {
      ...state,
      selectedAthleteId: payload.entity ? payload.entity.id : null,
    };
  }),

);

export const getSelectedAthleteId = (state: AthleteState) => state.selectedAthleteId;

// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterAthlete.getSelectors();


