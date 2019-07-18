import { UIState } from './ui.state';
import { createFeatureSelector, createSelector } from '@ngrx/store';

export const selectUIState = createFeatureSelector<UIState>("ui");

export const showErrorSnackbar = createSelector(
    selectUIState,
    (uiState: UIState) => uiState.showErrorSnackbar
)

export const activeTheme = createSelector(
    selectUIState,
    (uiState: UIState) => uiState.theme
)

export const requestLoading = createSelector(
    selectUIState,
    (uiState: UIState) => uiState.httpRequestLoading
)
