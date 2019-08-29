import { Set } from './../../server-models/entities/Set';
import { Exercise } from './../../server-models/entities/Exercise';
import { Training } from 'src/server-models/entities/training.model';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';

export interface TrainingState {
    trainings: Training[];
    selectedTraining: Training;
    selectedExercise: Exercise;
    selectedSet: Set;
}

export const initialTrainingState: TrainingState = {
    trainings: [],
    selectedTraining: undefined,
    selectedExercise: undefined,
    selectedSet: undefined,
};


