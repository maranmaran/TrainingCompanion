import { createSelector, createFeatureSelector } from '@ngrx/store';
import * as fromExerciseProperty from './exercise-property.reducers';
import { ExercisePropertyState } from './exercise-property.state';

export const selectExercisePropertyTypeState = createFeatureSelector<ExercisePropertyState>("exerciseProperty");

export const selectExercisePropertyState = createSelector(
    selectExercisePropertyTypeState,
    (state: ExercisePropertyState) => state
);

export const exercisePropertyIds = createSelector(
    selectExercisePropertyState,
    fromExerciseProperty.selectIds
);

export const exercisePropertyEntities = createSelector(
    selectExercisePropertyState,
    fromExerciseProperty.selectEntities
);

export const exerciseProperties = createSelector(
    selectExercisePropertyState,
    fromExerciseProperty.selectAll
);

export const exercisePropertyCount = createSelector(
    selectExercisePropertyState,
    fromExerciseProperty.selectTotal
);

export const selectedExercisePropertyId = createSelector(
    selectExercisePropertyState,
    fromExerciseProperty.getSelectedId
);

export const selectedExerciseProperty = createSelector(
    selectExercisePropertyState,
    (state) => state.entities[state.selectedId]
);


