import { ApplicationUser } from './application-user.model';
import { Tag } from './tag.model';

export class TagGroup {
    id: string;
    type: string;
    active: boolean;
    order: number;
    hexColor: string = "#616161";
    hexBackground: string = "#fef6f9";

    applicationUserId: string;
    applicationUser: ApplicationUser;

    properties: Tag[]
}