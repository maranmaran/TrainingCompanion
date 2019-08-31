import { ApplicationUser } from './application-user.model';
import { ExerciseProperty } from './exercise-property.model';

export class ExercisePropertyType {
    id: string;
    type: string;
    active: boolean;
    order: number;
    hexColor: string = "#616161";
    hexBackground: string = "#fef6f9";

    applicationUserId: string;
    applicationUser: ApplicationUser;
    
    properties: ExerciseProperty[]    
}