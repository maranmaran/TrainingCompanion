import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromTrainingBlockDay from './training-block-day.reducers';
import { TrainingBlockDayState } from './training-block-day.state';

export const selectTrainingBlockDayState = createFeatureSelector<TrainingBlockDayState>("trainingBlockDays");

export const trainingBlockDayIds = createSelector(
    selectTrainingBlockDayState,
    fromTrainingBlockDay.selectIds
);

export const trainingBlockDayEntities = createSelector(
    selectTrainingBlockDayState,
    fromTrainingBlockDay.selectEntities
);

export const trainingBlockDays = createSelector(
    selectTrainingBlockDayState,
    fromTrainingBlockDay.selectAll,
);

export const trainingBlockDayCount = createSelector(
    selectTrainingBlockDayState,
    fromTrainingBlockDay.selectTotal
);

// ids
export const selectedTrainingBlockDayId = createSelector(
    selectTrainingBlockDayState,
    fromTrainingBlockDay.getSelectedTrainingBlockDayId
);

// objects
export const selectedTrainingBlockDay = createSelector(
    selectTrainingBlockDayState,
    (state) => state.entities[state.selectedTrainingBlockDayId]
);
