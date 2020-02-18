import { TagGroup } from './tag-group.model';

export class Tag {
    id: string;
    value: string;
    active: boolean;
    order: number;

    tagGroupId: string;
    tagGroup: TagGroup;
}
