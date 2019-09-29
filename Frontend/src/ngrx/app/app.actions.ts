import { createAction, props } from '@ngrx/store';
import { Training } from 'src/server-models/entities/training.model';

export const tagsChanged = createAction(
    '[App] Tags changed - need to update anything tag related'
)