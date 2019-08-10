import { AthletesState } from './athlete.state';
import { createSelector, createFeatureSelector } from '@ngrx/store';

export const selectAthletesState = createFeatureSelector<AthletesState>("athletes");

export const athletes = createSelector(
    selectAthletesState,
    (athletesState: AthletesState) => athletesState.athletes
)

export const selectedAthlete = createSelector(
    selectAthletesState,
    (athletesState: AthletesState) => athletesState.selected,
)
