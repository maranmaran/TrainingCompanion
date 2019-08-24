import { ApplicationUser } from './application-user.model';
import { ExerciseProperty } from './exercise-property.model';

export class ExerciseType {
    id: string;
    name: string;
    active: boolean;

    requiresReps?: boolean;
    requiresWeight?: boolean;
    requiresSets?: boolean;
    requiresBodyweight?: boolean;
    requiresTime?: boolean;

    applicationUserId: string;
    applicationUser: ApplicationUser;

    properties: ExerciseTypeExerciseProperty[];
    //exerciseMaxes: ExerciseMax[]
}

// JOIN TABLE
export class ExerciseTypeExerciseProperty {
    id: string;
    
    show: boolean;
    
    exerciseTypeId: string;
    exerciseType: ExerciseType;

    exercisePropertyId: string;
    exerciseProperty: ExerciseProperty;

}