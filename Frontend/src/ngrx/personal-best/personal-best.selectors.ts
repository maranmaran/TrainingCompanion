import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromPersonalBest from './personal-best.reducers';
import { PersonalBestState } from './personal-best.state';

export const selectPersonalBestState = createFeatureSelector<PersonalBestState>("personalBest");

export const personalBestIds = createSelector(
    selectPersonalBestState,
    fromPersonalBest.selectIds
);

export const personalBestEntities = createSelector(
    selectPersonalBestState,
    fromPersonalBest.selectEntities
);

export const personalBest = createSelector(
    selectPersonalBestState,
    fromPersonalBest.selectAll,
);

export const personalBestCount = createSelector(
    selectPersonalBestState,
    fromPersonalBest.selectTotal
);

// ids
export const selectedPersonalBestId = createSelector(
    selectPersonalBestState,
    fromPersonalBest.getSelectedPersonalBestId
);

// objects
export const selectedPersonalBest = createSelector(
    selectPersonalBestState,
    (state) => state.entities[state.selectedPersonalBestId]
);
