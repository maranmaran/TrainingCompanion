import { Set } from './../../../entities/set.model';
export class UpdateExerciseRequest {
    id: string;
    exerciseTypeId: string;
    trainingId: string;
    sets: Set[];
}