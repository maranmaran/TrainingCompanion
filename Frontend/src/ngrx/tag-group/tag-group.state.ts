import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { Tag } from 'src/server-models/entities/tag.model';


// Exercise property type ENTITY
export interface TagGroupState extends EntityState<TagGroup> {
    selectedTypeId: string | number,
    selectedPropertyId: string | number,
}


//sort function
export function sortByOrder(a: TagGroup | Tag, b: TagGroup | Tag): number {
    return (a.order - b.order) > 0 ? 1 : (a.order - b.order) < 0 ? -1 : 0;
}

// ADAPTERS
export const adapterTagGroup = createEntityAdapter<TagGroup>({ sortComparer: sortByOrder });
export const adapterTag = createEntityAdapter<Tag>({ sortComparer: sortByOrder });

// INITIAL STATES
export const tagGroupInitialState: TagGroupState = adapterTagGroup.getInitialState({ selectedTypeId: undefined, selectedPropertyId: undefined });
