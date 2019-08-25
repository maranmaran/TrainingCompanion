import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';

export interface ExercisePropertyTypeState {
    types: ExercisePropertyType[];
    selectedType: ExercisePropertyType,
    selectedProperty: ExerciseProperty
}

export const initialExercisePropertyTypeState: ExercisePropertyTypeState = {
    types: undefined,
    selectedType: undefined,
    selectedProperty: undefined
};


