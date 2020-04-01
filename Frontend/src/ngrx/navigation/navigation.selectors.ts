import { createFeatureSelector, createSelector } from '@ngrx/store';
import { NavigationState } from './navigation.state';

export const selectNavigationState = createFeatureSelector<NavigationState>("navigations");

export const athleteActiveNavigation = createSelector(selectNavigationState, state => state.athleteActiveNavigation);
export const athleteActiveTab = createSelector(selectNavigationState, state => state.athleteActiveTabIdx);
export const athletePreviousRoute = createSelector(selectNavigationState, state => state.athletePreviousRoute);
