import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { PersonalBest } from '../../server-models/entities/personal-best.model';

export interface PersonalBestState extends EntityState<PersonalBest> {
    selectedPersonalBestId: string | number;
}

export const adapterPersonalBest = createEntityAdapter<PersonalBest>();

export const personalBestInitialState: PersonalBestState = adapterPersonalBest.getInitialState({
  selectedPersonalBestId: undefined,
})


