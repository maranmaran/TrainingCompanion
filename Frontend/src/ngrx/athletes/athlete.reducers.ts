import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import * as UsersActions from './athlete.actions';
import { AthletesState, initialAthletesState } from './athlete.state';

export const athletesReducer: ActionReducer<AthletesState, Action> = createReducer(
    initialAthletesState,

    // GET
    on(UsersActions.athletesFetched, (state: AthletesState, payload: {athletes: ApplicationUser[]}) => {
        return {
            ...state,
            athletes: [...payload.athletes]
        }
    }),

    // UPDATE
    on(UsersActions.athleteUpdated, (state: AthletesState, payload: { athlete: ApplicationUser }) => {
        return {
            ...state,
            athletes: state.athletes.map(su => su.id == payload.athlete.id  ? payload.athlete : su),
            selected: payload.athlete.id == state.selected.id ? payload.athlete : state.selected
        }
    }),

    // UPDATE
    on(UsersActions.athleteCreated, (state: AthletesState, payload: { athlete: ApplicationUser }) => {
        return {
            ...state,
            athletes: [...state.athletes, payload.athlete]
        }
    }),

    // DELETE
    on(UsersActions.athleteDeleted, (state: AthletesState, payload: { id: string }) => {
        
        return {
            ...state,
            athletes: [...state.athletes.filter(x => x.id !== payload.id)],
            selected: state.selected.id == payload.id ? null : state.selected
        }
    }),

    // SET SELECTED
    on(UsersActions.setSelectedAthlete, (state: AthletesState, payload: { athlete: ApplicationUser }) => {
        return {
            ...state,
            selected: payload.athlete
        }
    }),



);

