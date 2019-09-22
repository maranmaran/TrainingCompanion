import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Tag } from 'src/server-models/entities/tag.model';

// Exercise property ENTITY
export interface TagState extends EntityState<Tag> {
    selectedId: string | number;
}

// ADAPTERS
export const adapterTag = createEntityAdapter<Tag>();

// INITIAL STATES
export const tagInitialState: TagState = adapterTag.getInitialState({ selectedId: undefined });
