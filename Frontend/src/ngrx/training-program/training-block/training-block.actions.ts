import { Update } from "@ngrx/entity";
import { createAction, props } from "@ngrx/store";
import { TrainingBlock } from './../../../server-models/entities/training-program.model';

export const trainingBlockCreated = createAction(
    '[TrainingBlock] Created',
    props<{ entity: TrainingBlock }>()
);

export const trainingBlockFetched = createAction(
    '[TrainingBlock] Fetched',
    props<{ entities: TrainingBlock[] }>()
);

export const trainingBlockUpdated = createAction(
    '[TrainingBlock] Updated',
    props<{ entity: Update<TrainingBlock> }>()
);

export const trainingBlockDeleted = createAction(
    '[TrainingBlock] Deleted',
    props<{ id: string }>()
);

export const setSelectedTrainingBlock = createAction(
    '[TrainingBlock] Set selected trainingBlock',
    props<{ entity: TrainingBlock }>()
);
