import { routerReducer, RouterReducerState } from '@ngrx/router-store';
import { ActionReducer, ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from 'src/environments/environment';
import { AppInitializeEffects } from './app-initialize.ngrx';
import { AuthEffects } from './auth/auth.effects';
import { authReducer } from './auth/auth.reducers';
import { AuthState } from './auth/auth.state';
import { clearState } from './clear-state.reducer';
import { navigationsReducer } from './navigation/navigation.reducer';
import { NavigationState } from './navigation/navigation.state';
import { UIEffects } from './user-interface/ui.effects';
import { uiReducer } from './user-interface/ui.reducers';
import { UIState } from './user-interface/ui.state';

export interface AppState {
  router: RouterReducerState,
  navigation: NavigationState,
  auth: AuthState,
  ui: UIState,
}

export const reducers: ActionReducerMap<AppState> = {
  router: routerReducer,
  navigation: navigationsReducer,
  auth: authReducer,
  ui: uiReducer,
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
  !environment.production ?
    [clearState] :
    [clearState]
// !environment.production ? [stateLogger] : [];

export const CoreEffects = [AppInitializeEffects, AuthEffects, UIEffects];
