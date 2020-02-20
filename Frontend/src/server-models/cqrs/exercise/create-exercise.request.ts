import { Set } from './../../../server-models/entities/set.model';

export class CreateExerciseRequest {
    exerciseTypeId: string;
    trainingId: string;
    order: number;
    sets: Set[];
}
