import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { TrainingBlock } from '../../../server-models/entities/training-program.model';

export interface TrainingBlockState extends EntityState<TrainingBlock> {
    selectedTrainingBlockId: string | number;
}

//sort function
export function sortByOrder(a: TrainingBlock, b: TrainingBlock): number {
  return (a.order - b.order) > 0 ? 1 : (a.order - b.order) < 0 ? -1 : 0;
}

export const adapterTrainingBlock = createEntityAdapter<TrainingBlock>({sortComparer: sortByOrder});

export const trainingBlockInitialState: TrainingBlockState = adapterTrainingBlock.getInitialState({
    selectedTrainingBlockId: undefined,
})
