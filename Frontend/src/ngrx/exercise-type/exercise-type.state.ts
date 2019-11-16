import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';

// Exercise property type ENTITY
export interface ExerciseTypeState extends EntityState<ExerciseType> {
  selectedExerciseTypeId: string | number
}

// //sort function
// export function sortByOrder(a: ExerciseType, b: ExerciseType): number {
//   return ;
// }

// ADAPTERS
export const adapterExerciseType = createEntityAdapter<ExerciseType>();

// INITIAL STATES
export const exerciseTypeInitialState = adapterExerciseType.getInitialState({ selectedExerciseTypeId: undefined});

