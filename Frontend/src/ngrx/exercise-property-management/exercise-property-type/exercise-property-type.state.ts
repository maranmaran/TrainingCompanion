import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';

export interface ExercisePropertyTypeState {
    types: ExercisePropertyType[];
}

export const initialExercisePropertyTypeState: ExercisePropertyTypeState = {
    types: undefined
};


