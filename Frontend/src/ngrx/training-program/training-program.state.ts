import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Bodyweight } from '../../server-models/entities/bodyweight.model';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';

export interface TrainingProgramState extends EntityState<TrainingProgram> {
    selectedTrainingProgramId: string | number;
}


//sort function

export const adapterTrainingProgram = createEntityAdapter<TrainingProgram>();

export const trainingProgramInitialState: TrainingProgramState = adapterTrainingProgram.getInitialState({
    selectedTrainingProgramId: undefined,
})
