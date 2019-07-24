import { routerReducer, BaseRouterStoreState } from '@ngrx/router-store';
import { ActionReducer, ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from 'src/environments/environment';
import { AuthEffects } from './auth/auth.effects';
import { authReducer } from './auth/auth.reducers';
import { AuthState } from './auth/auth.state';
import { UIEffects } from './user-interface/ui.effects';
import { uiReducer } from './user-interface/ui.reducers';
import { UIState } from './user-interface/ui.state';
import { RouterState } from '@angular/router';

export interface AppState {
  auth: AuthState,
  ui: UIState,
}

export const reducers: ActionReducerMap<AppState> = {
  router: routerReducer,
  auth: authReducer,
  ui: uiReducer
};

export function stateLogger(reducer: ActionReducer<any>)
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

export const CoreEffects = [AuthEffects, UIEffects];