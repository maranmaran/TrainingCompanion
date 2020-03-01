import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { PersonalBest } from 'src/server-models/entities/personal-best.model';

export const personalBestCreated = createAction(
  '[PersonalBest] Created',
  props<{ entity: PersonalBest }>()
);

export const personalBestFetched = createAction(
  '[PersonalBest] Fetched',
  props<{ entities: PersonalBest[] }>()
);

export const personalBestUpdated = createAction(
  '[PersonalBest] Updated',
  props<{ entity: Update<PersonalBest> }>()
);

export const personalBestDeleted = createAction(
  '[PersonalBest] Deleted',
  props<{ id: string }>()
);

export const setSelectedPersonalBest = createAction(
  '[PersonalBest] Set selected personalBest',
  props<{ entity: PersonalBest }>()
);
