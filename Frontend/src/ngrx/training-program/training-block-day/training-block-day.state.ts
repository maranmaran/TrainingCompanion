import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { TrainingBlockDay } from './../../../server-models/entities/training-program.model';

export interface TrainingBlockDayState extends EntityState<TrainingBlockDay> {
    selectedTrainingBlockDayId: string | number;
}


//sort function

//sort function
export function sortByOrder(a: TrainingBlockDay, b: TrainingBlockDay): number {
  return (a.order - b.order) > 0 ? 1 : (a.order - b.order) < 0 ? -1 : 0;
}


export const adapterTrainingBlockDay = createEntityAdapter<TrainingBlockDay>({sortComparer: sortByOrder});

export const trainingBlockDayInitialState: TrainingBlockDayState = adapterTrainingBlockDay.getInitialState({
    selectedTrainingBlockDayId: undefined,
})
