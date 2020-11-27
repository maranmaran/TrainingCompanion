import { MediaFile } from './../../server-models/entities/media-file.model';
import { TrainingDetailsResponse } from './../../server-models/cqrs/training/training-details.response';
import { Update } from '@ngrx/entity';
import { createAction, props } from '@ngrx/store';
import { Training } from 'src/server-models/entities/training.model';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/get-training-metrics.response';

export const trainingCreated = createAction(
    '[Training] Created',
    props<{ entity: Training }>()
);

export const trainingsFetched = createAction(
    '[Training] Fetched',
    props<{ entities: Training[] }>()
);

export const trainingsFetchedReplaceState = createAction(
  '[Training] Fetched',
  props<{ entities: Training[] }>()
);

export const trainingUpdated = createAction(
    '[Training] Updated',
    props<{ entity: Update<Training> }>()
);

export const manyTrainingsUpdated = createAction(
    '[Training] Many updated',
    props<{ entities: Update<Training>[] }>()
);

export const trainingDeleted = createAction(
    '[Training] Deleted',
    props<{ id: string }>()
);

export const setSelectedTraining = createAction(
    '[Training] Set selected training',
    props<{ id: string }>()
);

export const clearTrainingState = createAction(
  '[Training] Clear',
);

export const setTrainingMedia = createAction(
    '[Training] Set media',
    props<{id: string, media: MediaFile[]}>()
);

export const setTrainingMetrics = createAction(
    '[Training] Set metrics',
    props<{ id: string, metrics: GetTrainingMetricsResponse }>()
);

export const setMonthFetched = createAction(
    '[Training] Month fetched',
    props<{id: string, month: number, year: number}>()
)

