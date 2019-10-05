import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Training } from 'src/server-models/entities/training.model';


// Exercise property type ENTITY
export interface TrainingState extends EntityState<Training>{
    selectedId: string,
}

// ADAPTERS
export const adapterTraining = createEntityAdapter<Training>({});

// INITIAL STATES
export const trainingInitialState: TrainingState = adapterTraining.getInitialState({
    selectedId: undefined,
});
