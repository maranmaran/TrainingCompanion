import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Set } from 'src/server-models/entities/set.model';

// Set property ENTITY
export interface SetState extends EntityState<Set> {
    selectedId: string | number;
}

// ADAPTERS
export const adapterSet = createEntityAdapter<Set>();

// INITIAL STATES
export const setInitialState: SetState = adapterSet.getInitialState({selectedId: undefined});
