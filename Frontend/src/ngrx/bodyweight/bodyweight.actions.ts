import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';

export const bodyweightCreated = createAction(
  '[Bodyweight] Created',
  props<{ entity: Bodyweight }>()
);

export const bodyweightFetched = createAction(
  '[Bodyweight] Fetched',
  props<{ entities: Bodyweight[] }>()
);

export const bodyweightUpdated = createAction(
  '[Bodyweight] Updated',
  props<{ entity: Update<Bodyweight> }>()
);

export const bodyweightDeleted = createAction(
  '[Bodyweight] Deleted',
  props<{ id: string }>()
);

export const setSelectedBodyweight = createAction(
  '[Bodyweight] Set selected bodyweight',
  props<{ entity: Bodyweight }>()
);
