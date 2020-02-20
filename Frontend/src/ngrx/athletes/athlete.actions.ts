import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

export const athleteCreated = createAction(
  '[Athlete] Created',
  props<{ entity: ApplicationUser }>()
);

export const athletesFetched = createAction(
  '[Athlete] Fetched',
  props<{ entities: ApplicationUser[] }>()
);

export const athleteUpdated = createAction(
  '[Athlete] Updated',
  props<{ entity: Update<ApplicationUser> }>()
);

export const manyAthletesUpdated = createAction(
  '[Athlete] Many updated',
  props<{ entities: Update<ApplicationUser>[] }>()
);

export const athleteDeleted = createAction(
  '[Athlete] Deleted',
  props<{ id: string }>()
);

export const setSelectedAthlete = createAction(
  '[Athlete] Set selected athlete',
  props<{ entity: ApplicationUser }>()
);
