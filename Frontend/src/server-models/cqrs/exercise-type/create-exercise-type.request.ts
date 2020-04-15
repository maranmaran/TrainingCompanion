import { ExerciseTypeTag } from 'src/server-models/entities/exercise-type.model';
export class CreateExerciseTypeRequest {

    constructor(data: Partial<CreateExerciseTypeRequest>) {
        Object.assign(this, data);
    }

    name: string;
    active: boolean;
    requiresReps?: boolean;
    requiresWeight?: boolean;
    requiresSets?: boolean;
    requiresBodyweight?: boolean;
    requiresTime?: boolean;
    properties: ExerciseTypeTag[];
    applicationUserId: string;
}