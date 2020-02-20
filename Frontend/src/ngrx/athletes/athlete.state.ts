import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { ApplicationUser } from '../../server-models/entities/application-user.model';

export interface AthleteState extends EntityState<ApplicationUser> {
    selectedAthleteId: string | number;
}

export const adapterAthlete = createEntityAdapter<ApplicationUser>();

export const athleteInitialState: AthleteState = adapterAthlete.getInitialState({
  selectedAthleteId: undefined,
})


