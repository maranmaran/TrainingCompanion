import { createFeatureSelector, createSelector } from '@ngrx/store';
import { NavigationState } from './navigation.state';

export const selectNavigationState = createFeatureSelector<NavigationState>("navigations");

export const activeNavigation = createSelector(selectNavigationState, state => state.activeNavigation);
export const activeTab = createSelector(selectNavigationState, state => state.activeTab);
export const previousRoute = createSelector(selectNavigationState, state => state.previousRoute);
