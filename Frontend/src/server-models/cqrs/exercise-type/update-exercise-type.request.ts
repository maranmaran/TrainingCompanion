import { ExerciseType } from 'src/server-models/entities/exercise-type.model';

export class UpdateExerciseTypeRequest {
  constructor(data: Partial<UpdateExerciseTypeRequest>) {
    Object.assign(this, data);
  }
  exerciseType: ExerciseType;
}
