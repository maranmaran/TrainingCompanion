import { UIState } from './ui.state';
import { createFeatureSelector, createSelector, Store } from '@ngrx/store';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { map } from 'rxjs/internal/operators/map';
import { Observable } from 'rxjs/internal/Observable';
import { AppState } from '../global-setup.ngrx';
import { observeOn } from 'rxjs/operators';
import { asyncScheduler } from 'rxjs';

export const selectUIState = createFeatureSelector<UIState>("ui");

export const showErrorDialogs = createSelector(
    selectUIState,
    (uiState: UIState) => uiState.showErrorDialogs
);

export const activeTheme = createSelector(
    selectUIState,
    (uiState: UIState) => uiState.theme
);

export const requestLoading = createSelector(
    selectUIState,
    (uiState: UIState) => uiState.httpRequestLoading
);

export const activeProgressBar = createSelector(
    selectUIState,
    (uiState: UIState) => uiState.activeProgressBar
);

export const isMobile = createSelector(
    selectUIState,
    (uiState: UIState) => uiState.isMobile
);

export function getLoadingState(store: Store<AppState>, progressBarType: UIProgressBar): Observable<boolean> {

    // async because of ExpressionChangedAfterItHasBeenCheckedError

    return combineLatest(
        store.select(requestLoading),
        store.select(activeProgressBar)
      ).pipe(
          map(([isLoading, progressBar]) => isLoading && progressBar == progressBarType),
          observeOn(asyncScheduler));
          
}

