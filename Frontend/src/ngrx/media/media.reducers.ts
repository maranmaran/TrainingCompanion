import { createReducer } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { initialMediaState, MediaState } from './media.state';

export const mediaReducer: ActionReducer<MediaState, Action> = createReducer(
    initialMediaState,

   

);