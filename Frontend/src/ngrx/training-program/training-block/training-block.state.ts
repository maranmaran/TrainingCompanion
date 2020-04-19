import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { TrainingBlock } from '../../../server-models/entities/training-program.model';

export interface TrainingBlockState extends EntityState<TrainingBlock> {
    selectedTrainingBlockId: string | number;
}


//sort function

export const adapterTrainingBlock = createEntityAdapter<TrainingBlock>();

export const trainingBlockInitialState: TrainingBlockState = adapterTrainingBlock.getInitialState({
    selectedTrainingBlockId: undefined,
})
