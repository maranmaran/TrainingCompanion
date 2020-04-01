import { createFeatureSelector } from '@ngrx/store';
import { NavigationState } from './navigation.state';

export const selectNavigationState = createFeatureSelector<NavigationState>("navigations");

// export const navigationIds = createSelector(
//     selectNavigationState,
//     fromNavigation.selectIds
// );
