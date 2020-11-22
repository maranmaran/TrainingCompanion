import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/get-training-metrics.response';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import { MediaFile } from './../../server-models/entities/media-file.model';

// Exercise property type ENTITY
export interface TrainingState extends EntityState<Training> {
    selectedTrainingId: string | number,
    media: Record<string | number, MediaFile[]>
    metrics: Record<string | number, GetTrainingMetricsResponse>
}

//sort function
export function sortByDate(a: Training, b: Training): number {
  return (new Date(a.dateTrained).getTime() - new Date(b.dateTrained).getTime()) > 0 ? 1 : (new Date(a.dateTrained).getTime() - new Date(b.dateTrained).getTime()) < 0 ? -1 : 0;
}

// ADAPTERS
export const adapterTraining = createEntityAdapter<Training>({sortComparer: sortByDate});
export const adapterExercise = createEntityAdapter<Exercise>({});

// INITIAL STATES
export const trainingInitialState: TrainingState = adapterTraining.getInitialState({
    selectedTrainingId: undefined,
    selectedExerciseId: undefined,
    media: {},
    metrics: {}
});
