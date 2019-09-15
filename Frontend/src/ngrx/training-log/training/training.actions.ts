import { Set } from './../../../server-models/entities/set.model';
import { Update, Dictionary } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { Training } from 'src/server-models/entities/training.model';
import { Exercise } from 'src/server-models/entities/exercise.model';


export const trainingCreated = createAction(
    '[Training] Created',
    props<{ training: Training}>()
)

export const normalizeTrainings = createAction(
    '[Training] Normalize',
    props<{trainings: Training[]}>()
)

export const trainingsFetched = createAction(
    '[Training] Fetched',
    props<{ entities: Dictionary<Training>, ids: string[] }>()
)

export const trainingUpdated = createAction(
    '[Training] Updated',
    props<{ training: Update<Training> }>()
)

export const manyTrainingsUpdated = createAction(
    '[Training] Many updated',
    props<{ trainings: Update<Training>[] }>()
)

export const trainingDeleted = createAction(
    '[Training] Deleted',
    props<{ id: string }>()
)

export const setSelectedTraining = createAction(
    '[Training] Set selected training',
    props<{ training: Training }>()
)
