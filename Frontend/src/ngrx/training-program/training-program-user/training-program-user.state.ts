import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { TrainingProgramUser } from './../../../server-models/entities/training-program.model';

export interface TrainingProgramUserState extends EntityState<TrainingProgramUser> {
    selectedTrainingProgramUserId: string | number;
}


//sort function

export const adapterTrainingProgramUser = createEntityAdapter<TrainingProgramUser>();

export const trainingProgramUserInitialState: TrainingProgramUserState = adapterTrainingProgramUser.getInitialState({
    selectedTrainingProgramUserId: undefined,
})
