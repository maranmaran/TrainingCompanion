import { ExerciseType } from './exercise-type.model';
import { Set } from './set.model';
import { Training } from './training.model';
export class Exercise {
    id: string;
    
    trainingId: string;
    training: Training;
    
    exerciseTypeId: string;
    exerciseType: ExerciseType;

    sets: Set[];
}
