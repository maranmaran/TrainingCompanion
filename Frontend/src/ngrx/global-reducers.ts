import { AuthState } from './auth/auth.state';
import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../environments/environment';
import {routerReducer} from '@ngrx/router-store';
import { authReducer } from './auth/auth.reducers';

export interface AppState {
  auth: AuthState
}

export const reducers: ActionReducerMap<AppState> = {
  //  router: routerReducer,
  auth: authReducer
};

export function stateLogger(reducer:ActionReducer<any>)
    : ActionReducer<any> {
    return (state, action) => {
        console.log("state before: ", state);
        console.log("action: ", action);

        return reducer(state, action);
    }
}

export const metaReducers: MetaReducer<AppState>[] =
!environment.production ? [] : [];
// !environment.production ? [stateLogger] : [];
