import { createSelector } from '@ngrx/store';
import { ExercisePropertyManagementState, selectExercisePropertyManagementState } from '../exercise-property-management.state';
import * as fromType from './exercise-property-type.reducers';

export const selectExercisePropertyTypeState = createSelector(
    selectExercisePropertyManagementState,
    (state: ExercisePropertyManagementState) => state.typeState
);
export const exercisePropertyTypeIds = createSelector(
    selectExercisePropertyTypeState,
    fromType.selectTypeIds
);

export const exercisePropertyTypeEntities = createSelector(
    selectExercisePropertyTypeState,
    fromType.selectTypeEntities
);

export const allExercisePropertyTypes = createSelector(
    selectExercisePropertyTypeState,
    fromType.selectAllTypes
);

export const exercisePropertyTypeCount = createSelector(
    selectExercisePropertyTypeState,
    fromType.selectTypeTotal
);

export const selectedExercisePropertyTypeId = createSelector(
    selectExercisePropertyTypeState,
    fromType.getSelectedTypeId
);

export const selectedExercisePropertyType = createSelector(
    selectExercisePropertyTypeState,
    (state) => state.entities[state.selectedTypeId]
);


