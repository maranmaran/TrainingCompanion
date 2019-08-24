import { createSelector, createFeatureSelector } from '@ngrx/store';
import { ExercisePropertyTypeState } from './exercise-property-type.state';

export const selectExercisePropertyTypeState = createFeatureSelector<ExercisePropertyTypeState>("exercisePropertyType");

export const exercisePropertyTypes = createSelector(
    selectExercisePropertyTypeState,
    (state: ExercisePropertyTypeState) => state.types
)

export const selectedPropertyType = createSelector(
    selectExercisePropertyTypeState,
    (state: ExercisePropertyTypeState) => state.selected
)
