import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';

export interface ExercisePropertyState {
    properties: ExerciseProperty[];
}

export const initialExercisePropertyState: ExercisePropertyState = {
    properties: undefined
};


