import { ExercisePropertyManagementState } from './../exercise-property-management.state';
import { createSelector } from '@ngrx/store';
import { selectExercisePropertyManagementState } from '../exercise-property-management.state';
import * as fromProperty from './exercise-property.reducers';
import { ExercisePropertyState } from './exercise-property.state';

export const selectExercisePropertytate = createSelector(
    selectExercisePropertyManagementState,
    (state: ExercisePropertyManagementState) => state.propertyState
);

export const exercisePropertyIds = createSelector(
    selectExercisePropertytate,
    fromProperty.selectPropertyIds
);

export const exercisePropertyEntities = createSelector(
    selectExercisePropertytate,
    fromProperty.selectPropertyEntities
);

export const allExerciseProperties = createSelector(
    selectExercisePropertytate,
    fromProperty.selectAllProperties
);

export const exercisePropertyTypesByTypeId = (id: string) => createSelector(
    allExerciseProperties,
    properties => properties.filter(x => x.exercisePropertyTypeId == id)
);

export const exercisePropertyCount = createSelector(
    selectExercisePropertytate,
    fromProperty.selectPropertyTotal
);

export const selectedExercisePropertyId = createSelector(
    selectExercisePropertytate,
    fromProperty.getSelectedPropertyId
);

export const selectedExerciseProperty = createSelector(
    selectExercisePropertytate,
    (state) => state.entities[state.selectedPropertyId]
);


