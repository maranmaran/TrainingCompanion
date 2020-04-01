import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import * as NavigationActions from './navigation.actions';
import { AthleteBottomNavigation, navigationInitialState, NavigationState } from './navigation.state';

export const navigationsReducer: ActionReducer<NavigationState, Action> = createReducer(
  navigationInitialState,


  on(NavigationActions.athleteActiveBottomNav, (state: NavigationState, payload: { nav: AthleteBottomNavigation }) => {
    return {
      ...state,
      athleteActiveNavigation: payload.nav
    }
  }),
  on(NavigationActions.athleteActiveTab, (state: NavigationState, payload: { tab: number }) => {
    return {
      ...state,
      athleteActiveTabIdx: payload.tab
    }
  }),
  on(NavigationActions.athletePreviousRoute, (state: NavigationState, payload: { route: string }) => {
    return {
      ...state,
      athletePreviousRoute: payload.route
    }
  }),

)
