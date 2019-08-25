import { Training } from 'src/server-models/entities/training.model';

export interface TrainingState {
    trainings: Training[];
    selected: Training
}

export const initialTrainingState: TrainingState = {
    trainings: undefined,
    selected: undefined
};


