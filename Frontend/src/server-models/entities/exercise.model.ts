import { ExerciseType } from './exercise-type.model';
import { Set } from './set.model';
export class Exercise {
    id: string;
    exerciseTypeId: string;
    exerciseType: ExerciseType;
    sets: Set[];
}
