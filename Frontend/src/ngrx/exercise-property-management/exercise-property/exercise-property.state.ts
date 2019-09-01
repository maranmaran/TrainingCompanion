import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';

// Exercise property ENTITY
export interface ExercisePropertyState extends EntityState<ExerciseProperty> {
    selectedPropertyId: string | number;
}

// ADAPTERS
export const adapterExerciseProperty = createEntityAdapter<ExerciseProperty>();

// INITIAL STATES
export const exercisePropertyInitialState: ExercisePropertyState = adapterExerciseProperty.getInitialState({selectedPropertyId: undefined});
