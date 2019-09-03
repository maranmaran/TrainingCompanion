import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';

export class UpdateTrainingRequest {
    training: Training;
    exerciseAdd?: Exercise;
}
export class UpdateTrainingRequestResponse {
    training: Training;
    addedExercise?: Exercise;
}