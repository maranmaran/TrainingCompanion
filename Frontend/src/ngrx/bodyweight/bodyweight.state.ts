import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Bodyweight } from '../../server-models/entities/bodyweight.model';

export interface BodyweightState extends EntityState<Bodyweight> {
    selectedBodyweightId: string | number;
}


//sort function

export const adapterBodyweight = createEntityAdapter<Bodyweight>();

export const bodyweightInitialState: BodyweightState = adapterBodyweight.getInitialState({
  selectedBodyweightId: undefined,
})


