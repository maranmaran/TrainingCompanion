import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromBodyweight from './bodyweight.reducers';
import { BodyweightState } from './bodyweight.state';

export const selectBodyweightState = createFeatureSelector<BodyweightState>("bodyweights");

export const bodyweightIds = createSelector(
    selectBodyweightState,
    fromBodyweight.selectIds
);

export const bodyweightEntities = createSelector(
    selectBodyweightState,
    fromBodyweight.selectEntities
);

export const bodyweights = createSelector(
    selectBodyweightState,
    fromBodyweight.selectAll,
);

export const bodyweightCount = createSelector(
    selectBodyweightState,
    fromBodyweight.selectTotal
);

// ids
export const selectedBodyweightId = createSelector(
    selectBodyweightState,
    fromBodyweight.getSelectedBodyweightId
);

// objects
export const selectedBodyweight = createSelector(
    selectBodyweightState,
    (state) => state.entities[state.selectedBodyweightId]
);
