import { ApplicationUser } from './application-user.model';
import { PersonalBest } from './personal-best.model';
import { Tag } from './tag.model';

export class ExerciseType {
    id: string;
    name: string;
    code: string;
    active: boolean;

    requiresReps?: boolean;
    requiresWeight?: boolean;
    requiresSets?: boolean;
    requiresBodyweight?: boolean;
    requiresTime?: boolean;

    applicationUserId: string;
    applicationUser: ApplicationUser;

    properties: ExerciseTypeTag[];
    pbs: PersonalBest[];
    //exerciseMaxes: ExerciseMax[]
}

// JOIN TABLE
export class ExerciseTypeTag {
    id: string;

    show: boolean;

    exerciseTypeId: string;
    exerciseType: ExerciseType;

    tagId: string;
    tag: Tag;

}
