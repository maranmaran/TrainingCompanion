import { createSelector, createFeatureSelector } from '@ngrx/store';
import { TrainingState } from './training.state';

export const selectTrainingState = createFeatureSelector<TrainingState>("training");

export const trainings = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.trainings
)
export const exercises = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.selectedTraining.exercises
)
export const sets = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.selectedExercise.sets
)
export const exerciseType = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.selectedExercise.exerciseType
)

export const selectedTraining = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.selectedTraining
)
export const selectedExercise = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.selectedExercise
)
export const selectedSet = createSelector(
    selectTrainingState,
    (state: TrainingState) => state.selectedSet
)
