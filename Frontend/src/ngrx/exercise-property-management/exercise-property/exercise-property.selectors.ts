import { createSelector, createFeatureSelector } from '@ngrx/store';
import { ExercisePropertyState } from './exercise-property.state';

export const selectExercisePropertyState = createFeatureSelector<ExercisePropertyState>("exerciseProperty");

export const exerciseProperties = createSelector(
    selectExercisePropertyState,
    (state: ExercisePropertyState) => state.properties
)
