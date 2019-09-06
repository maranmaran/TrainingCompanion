import { Set } from './../../../server-models/entities/set.model';
import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { Training } from 'src/server-models/entities/training.model';
import { Exercise } from 'src/server-models/entities/exercise.model';


export const trainingCreated = createAction(
    '[Training] Created',
    props<{ training: Training}>()
)

export const trainingsFetched = createAction(
    '[Training] Fetched',
    props<{ trainings: Training[] }>()
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


// SELECT
export const setSelectedTraining = createAction(
    '[Training] Set selected training',
    props<{ training: Training }>()
)
export const setSelectedExercise = createAction(
    '[Training] Set selected exercise',
    props<{ exercise: Exercise }>()
)
export const setSelectedSet = createAction(
    '[Training] Set selected set',
    props<{ set: Set }>()
)
