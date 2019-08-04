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
    on(UsersActions.subuserAdded, (state: SubusersState, user: ApplicationUser) => {
        return {
            ...state,
            subusers: [...state.subusers, user]
    }
    }),
    on(UsersActions.subuserUpdated, (state: SubusersState, user: ApplicationUser) => {

        let userStateToUpdate = [...state.subusers];
        let indexToUpdate = userStateToUpdate.indexOf(user);
        userStateToUpdate[indexToUpdate] = user;

        return {
            ...state,
            subusers: [...userStateToUpdate]
        }
    }),
    on(UsersActions.subuserDeleted, (state: SubusersState, user: ApplicationUser) => {
        return {
            ...state,
            subusers: [...state.subusers.filter(x => x.id != user.id)]
        }
    }),

);

