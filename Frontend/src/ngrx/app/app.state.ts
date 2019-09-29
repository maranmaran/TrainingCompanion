import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { Training } from 'src/server-models/entities/training.model';
import { Exercise } from 'src/server-models/entities/exercise.model';


// Exercise property type ENTITY
export interface AppState {
    tagsChanged: boolean
}

// INITIAL STATES
export const appInitialState: AppState = {
    tagsChanged: false,
}
