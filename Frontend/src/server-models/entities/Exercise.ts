import { ExerciseType } from './exercise-type.model';
import { Set } from './Set';
export class Exercise {
    id: string;
    exerciseTypeId: string;
    exerciseType: ExerciseType;
    sets: Set[];
}
