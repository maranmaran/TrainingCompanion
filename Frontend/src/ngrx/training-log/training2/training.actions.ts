import { Exercise } from './../../../server-models/entities/exercise.model';
import { Set } from './../../../server-models/entities/set.model';
import { createAction, props } from '@ngrx/store'
import { Training } from 'src/server-models/entities/training.model'
import { Update } from '@ngrx/entity'

export const trainingCreated = createAction(
    '[Training] Created',
    props<{ entity: Training }>()
)

export const trainingsFetched = createAction(
    '[Training] Fetched',
    props<{ entities: Training[] }>()
)

export const trainingUpdated = createAction(
    '[Training] Updated',
    props<{ entity: Update<Training> }>()
)

export const manyTrainingsUpdated = createAction(
    '[Training] Many updated',
    props<{ entities: Update<Training>[] }>()
)

export const trainingDeleted = createAction(
    '[Training] Deleted',
    props<{ id: string }>()
)
export const exerciseDeleted = createAction(
    '[Training] Deleted',
    props<{ id: string }>()
)

export const setSelectedTraining = createAction(
    '[Training] Set selected training',
    props<{ entity: Training }>()
)
export const setSelectedExercise = createAction(
    '[Training] Set selected exercise',
    props<{ entity: Exercise }>()
)