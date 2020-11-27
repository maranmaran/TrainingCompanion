import { createFeatureSelector, createSelector } from '@ngrx/store';

import * as fromTraining from './training.reducers';
import { TrainingState } from './training.state';

export const selectTrainingState = createFeatureSelector<TrainingState>("training");

export const trainingIds = createSelector(
    selectTrainingState,
    fromTraining.selectIds
);

export const trainingEntities = createSelector(
    selectTrainingState,
    fromTraining.selectEntities
);

export const trainings = createSelector(
    selectTrainingState,
    fromTraining.selectAll,
);

export const trainingsForMonth = createSelector(
  trainings,
  (trainings, month) => trainings.filter(training => training.dateTrained)
)

export const trainingCount = createSelector(
    selectTrainingState,
    fromTraining.selectTotal
);

// ids
export const selectedTrainingId = createSelector(
    selectTrainingState,
    fromTraining.getSelectedTrainingId
);

// objects
export const selectedTraining = createSelector(
    selectTrainingState,
    (state) => state.entities[state.selectedTrainingId]
);

export const trainingMedia = createSelector(
    selectTrainingState,
    (state) => Object.values(state.media[state.selectedTrainingId] ?? {})
);
export const trainingMediaDict = createSelector(
    selectTrainingState,
    (state) => state.media[state.selectedTrainingId]
);

export const trainingMetrics = createSelector(
    selectTrainingState,
    (state) => state.metrics[state.selectedTrainingId] ?? {}
);
export const trainingMetricsDict = createSelector(
    selectTrainingState,
    (state) => state.metrics[state.selectedTrainingId]
);

export const sessionVolume = createSelector(
    selectedTraining,
    training => training?.exercises?.reduce((a, b) => a + b.sets.reduce((c, d) => c + d.volume, 0), 0)
)
export const sessionNumberOfLifts = createSelector(
    selectedTraining,
    training => training?.exercises?.reduce((a, b) => a + b.sets.reduce((c, d) => c + d.reps, 0), 0)
)
