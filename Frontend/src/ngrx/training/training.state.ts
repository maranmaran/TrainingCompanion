import { Set } from '../../server-models/entities/set.model';
import { Exercise } from '../../server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';

export interface TrainingState {
    trainings: Training[];
    selectedTraining: Training;
    selectedExercise: Exercise;
    selectedSet: Set;
}

export const initialTrainingState: TrainingState = {
    trainings: undefined,
    selectedTraining: undefined,
    selectedExercise: undefined,
    selectedSet: undefined,
};


