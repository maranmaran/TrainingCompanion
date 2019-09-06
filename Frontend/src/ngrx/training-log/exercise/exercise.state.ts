import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Exercise } from 'src/server-models/entities/exercise.model';

// Exercise property ENTITY
export interface ExerciseState extends EntityState<Exercise> {
    selectedId: string | number;
}

// ADAPTERS
export const adapterExercise = createEntityAdapter<Exercise>();

// INITIAL STATES
export const exerciseInitialState: ExerciseState = adapterExercise.getInitialState({selectedId: undefined});
