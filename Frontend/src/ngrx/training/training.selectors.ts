import { createSelector, createFeatureSelector } from '@ngrx/store';
import { TrainingState } from './training.state';

export const selectTrainingState = createFeatureSelector<TrainingState>("training");

export const trainings = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.trainings
)

export const selectedTraining = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.selected
)
