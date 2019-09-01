import { ExercisePropertyTypeState } from './exercise-property-type.state';
import { createSelector, createFeatureSelector } from '@ngrx/store';
import * as fromType from './exercise-property-type.reducers';


export const selectExercisePropertyTypeState = createFeatureSelector<ExercisePropertyTypeState>("exercisePropertyType");

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
export const selectedExercisePropertyId = createSelector(
    selectExercisePropertyTypeState,
    fromType.getSelectedPropertyId
);

export const selectedExercisePropertyType = createSelector(
    selectExercisePropertyTypeState,
    (state) => state.entities[state.selectedTypeId]
);
export const selectedExerciseProperty = createSelector(
    selectExercisePropertyTypeState,
    (state) => {
        
        var type = (state.entities[state.selectedTypeId]);

        if(type) {
            return type.properties.filter(x => x.id == state.selectedPropertyId)[0]; // not normalized
        }
        
        return null; 
    }
);


