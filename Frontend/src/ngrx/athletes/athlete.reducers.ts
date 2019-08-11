import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { initialAthletesState, AthletesState } from './athlete.state';
import * as UsersActions from './athlete.actions';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

export const athletesReducer: ActionReducer<AthletesState, Action> = createReducer(
    initialAthletesState,

    on(UsersActions.athletesFetched, (state: AthletesState, payload: {athletes: ApplicationUser[]}) => {
        return {
            ...state,
            athletes: [...payload.athletes]
        }
    }),

    on(UsersActions.setSelectedAthlete, (state: AthletesState, payload: { athlete: ApplicationUser }) => {
        return {
            ...state,
            selected: payload.athlete
        }
    }),

    on(UsersActions.deactivateAthlete, (state: AthletesState) => {
        let selected = Object.assign({}, state.selected);
        selected.active = false;
        return {
            ...state,
            athletes: state.athletes.map(su => su.id == state.selected.id ? { ...su, active: false } : su),
            selected: selected
        }
    }),

    on(UsersActions.activateAthlete, (state: AthletesState) => {
        let selected = Object.assign({}, state.selected);
        selected.active = true;
        return {
            ...state,
            athletes: state.athletes.map(su => su.id == state.selected.id  ? { ...su, active: true } : su),
            selected: selected
        }
    }),

    on(UsersActions.updateAthlete, (state: AthletesState, athlete: ApplicationUser) => {
        return {
            ...state,
            athletes: state.athletes.map(su => su.id == athlete.id  ? athlete : su)
        }
    }),

    on(UsersActions.registerAthlete, (state: AthletesState, athlete: ApplicationUser) => {
        return {
            ...state,
            athletes: [...state.athletes, athlete]
        }
    }),

    on(UsersActions.deleteAthlete, (state: AthletesState, athlete: ApplicationUser) => {
        
        return {
            ...state,
            athletes: [...state.athletes.filter(x => x.id !== athlete.id)],
            selected: state.selected.id == athlete.id ? null : state.selected
        }
    }),



);

