import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { Training } from 'src/server-models/entities/training.model';
import { Exercise } from 'src/server-models/entities/exercise.model';


// Exercise property type ENTITY
export interface TrainingState extends EntityState<Training> {
    selectedTrainingId: string | number,
    selectedExerciseId: string | number,
}

// ADAPTERS
export const adapterTraining = createEntityAdapter<Training>({});
export const adapterExercise = createEntityAdapter<Exercise>({});

// INITIAL STATES
export const trainingInitialState: TrainingState = adapterTraining.getInitialState({
    selectedTrainingId: undefined,
    selectedExerciseId: undefined
});
