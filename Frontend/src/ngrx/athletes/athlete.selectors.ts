import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromAthlete from './athlete.reducers';
import { AthleteState } from './athlete.state';

export const selectAthleteState = createFeatureSelector<AthleteState>("athletes");

export const athleteIds = createSelector(
    selectAthleteState,
    fromAthlete.selectIds
);

export const athleteEntities = createSelector(
    selectAthleteState,
    fromAthlete.selectEntities
);

export const athletes = createSelector(
    selectAthleteState,
    fromAthlete.selectAll,
);

export const athleteCount = createSelector(
    selectAthleteState,
    fromAthlete.selectTotal
);

// ids
export const selectedAthleteId = createSelector(
    selectAthleteState,
    fromAthlete.getSelectedAthleteId
);

// objects
export const selectedAthlete = createSelector(
    selectAthleteState,
    (state) => state.entities[state.selectedAthleteId]
);
