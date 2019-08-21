import { ApplicationUser } from './application-user.model';
import { ExerciseProperty } from './exercise-property.model';

export class ExercisePropertyType {
    id: string;
    type: string;
    active: boolean;
    order: number;
    hexColor: string;

    applicationUserId: string;
    applicationUser: ApplicationUser;
    
    properties: ExerciseProperty[]    
}