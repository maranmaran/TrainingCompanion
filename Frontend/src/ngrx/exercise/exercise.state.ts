import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { PersonalBest } from '../../server-models/entities/personal-best.model';
import { Exercise } from './../../server-models/entities/exercise.model';

export interface ExerciseState {
    exercises: Record<string, Record<string, Exercise>>, // trainingId / exercise dict
    selectedExerciseId: string | number,
    exercisePrs: Record<string, PersonalBest[]>,
}

//sort function
export function sortByOrder(a: Exercise, b: Exercise): number {
    return (a.order - b.order) > 0 ? 1 : (a.order - b.order) < 0 ? -1 : 0;
}

export const exerciseInitialState: ExerciseState = {
    exercises: {},
    selectedExerciseId: undefined,
    exercisePrs: {},
}
