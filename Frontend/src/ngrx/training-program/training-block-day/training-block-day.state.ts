import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { TrainingBlockDay } from './../../../server-models/entities/training-program.model';

export interface TrainingBlockDayState extends EntityState<TrainingBlockDay> {
    selectedTrainingBlockDayId: string | number;
}


//sort function

export const adapterTrainingBlockDay = createEntityAdapter<TrainingBlockDay>();

export const trainingBlockDayInitialState: TrainingBlockDayState = adapterTrainingBlockDay.getInitialState({
    selectedTrainingBlockDayId: undefined,
})
