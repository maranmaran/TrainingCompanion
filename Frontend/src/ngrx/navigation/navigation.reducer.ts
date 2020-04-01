import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import * as NavigationActions from './navigation.actions';
import { BottomNavigation, navigationInitialState, NavigationState } from './navigation.state';

export const navigationsReducer: ActionReducer<NavigationState, Action> = createReducer(
  navigationInitialState,


  on(NavigationActions.setActiveNavigation, (state: NavigationState, payload: { nav: BottomNavigation }) => {
    return {
      ...state,
      athleteActiveNavigation: payload.nav
    }
  }),
  on(NavigationActions.setActiveTab, (state: NavigationState, payload: { tab: number }) => {
    return {
      ...state,
      athleteActiveTabIdx: payload.tab
    }
  }),
  on(NavigationActions.setPreviousRoute, (state: NavigationState, payload: { route: string }) => {
    return {
      ...state,
      athletePreviousRoute: payload.route
    }
  }),

)
