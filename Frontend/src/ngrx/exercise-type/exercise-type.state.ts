import { ExerciseType } from 'src/server-models/entities/exercise-type.model';

export interface ExerciseTypeState {
    types: ExerciseType[];
    selected: ExerciseType
}

export const initialExerciseTypeState: ExerciseTypeState = {
    types: undefined,
    selected: undefined
};


