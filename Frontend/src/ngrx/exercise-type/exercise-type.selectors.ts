import { createSelector, createFeatureSelector } from '@ngrx/store';
import { ExerciseTypeState } from './exercise-type.state';

export const selectExerciseTypeState = createFeatureSelector<ExerciseTypeState>("exerciseType");

export const exerciseTypes = createSelector(
    selectExerciseTypeState,
    (state: ExerciseTypeState) => state.types
)

export const selectedExerciseType = createSelector(
    selectExerciseTypeState,
    (state: ExerciseTypeState) => state.selected
)
