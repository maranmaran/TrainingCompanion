import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AppState } from './app.state';


export const selectAppState = createFeatureSelector<AppState>("App");

export const tagsChanged = createSelector(
    selectAppState,
    state => state.tagsChanged
);
