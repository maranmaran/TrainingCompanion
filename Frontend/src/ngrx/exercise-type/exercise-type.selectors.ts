import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromExerciseType from './exercise-type.reducers';
import { ExerciseTypeState } from './exercise-type.state';


export const selectExerciseTypeState = createFeatureSelector<ExerciseTypeState>("exerciseType");

export const exerciseTypeIds = createSelector(
    selectExerciseTypeState,
    fromExerciseType.selectIds
);

export const exerciseTypeEntities = createSelector(
    selectExerciseTypeState,
    fromExerciseType.selectEntities
);

export const exerciseTypes = createSelector(
    selectExerciseTypeState,
    fromExerciseType.selectAll
);

export const exerciseTypesForMonth = createSelector(
  exerciseTypes,
  (exerciseTypes, month) => exerciseTypes.filter(exerciseType => exerciseType.dateTrained)
)

export const exerciseTypeCount = createSelector(
    selectExerciseTypeState,
    fromExerciseType.selectTotal
);

// ids
export const selectedExerciseTypeId = createSelector(
    selectExerciseTypeState,
    fromExerciseType.getSelectedExerciseTypeId
);

export const selectedExerciseType = createSelector(
    selectExerciseTypeState,
    (state) => state.entities[state.selectedExerciseTypeId]
);
