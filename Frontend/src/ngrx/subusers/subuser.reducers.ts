import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { initialSubusersState, SubusersState } from './subuser.state';
import * as UsersActions from './subuser.actions';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

export const subusersReducer: ActionReducer<SubusersState, Action> = createReducer(
    initialSubusersState,

    on(UsersActions.subusersFetched, (state: SubusersState, payload: {subusers: ApplicationUser[]}) => {
        return {
            ...state,
            subusers: [...payload.subusers]
        }
    }),

    on(UsersActions.setSelectedSubuser, (state: SubusersState, payload: { subuser: ApplicationUser }) => {
        return {
            ...state,
            selected: payload.subuser
        }
    }),

    on(UsersActions.deactivateSubuser, (state: SubusersState) => {
        let selected = Object.assign({}, state.selected);
        selected.active = false;
        return {
            ...state,
            subusers: state.subusers.map(su => su.id == state.selected.id ? { ...su, active: false } : su),
            selected: selected
        }
    }),

    on(UsersActions.activateSubuser, (state: SubusersState) => {
        let selected = Object.assign({}, state.selected);
        selected.active = true;
        return {
            ...state,
            subusers: state.subusers.map(su => su.id == state.selected.id  ? { ...su, active: true } : su),
            selected: selected
        }
    }),

    on(UsersActions.registerSubuser, (state: SubusersState, subuser: ApplicationUser) => {
        return {
            ...state,
            subusers: [...state.subusers, subuser]
        }
    }),



);

