import { createReducer } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { navigationInitialState, NavigationState } from './navigation.state';

export const navigationsReducer: ActionReducer<NavigationState, Action> = createReducer(
  navigationInitialState,


  // on(NavigationActions.navigationCreated, (state: NavigationState, payload: { entity: ApplicationUser }) => {
  //   return adapterNavigation.addOne(payload.entity, state);
  // }),

)
