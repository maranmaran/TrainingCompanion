import { Training } from 'src/server-models/entities/training.model';
import { ExerciseType } from './../../../entities/exercise-type.model';
import { Set } from './../../../entities/set.model';
export class CreateExerciseRequest {

    exerciseTypeId: string;
    exerciseType: ExerciseType;

    trainingId: string;
    
    sets: Set[];
}