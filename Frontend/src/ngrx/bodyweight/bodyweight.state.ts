import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Bodyweight } from '../../server-models/entities/bodyweight.model';

export interface BodyweightState extends EntityState<Bodyweight> {
    selectedBodyweightId: string | number;
}


//sort function
export function sortByDate(a: Bodyweight, b: Bodyweight): number {
  return a?.date?.getTime() - b?.date?.getTime() ? 1 : -1;
}

export const adapterBodyweight = createEntityAdapter<Bodyweight>({sortComparer: sortByDate});

export const bodyweightInitialState: BodyweightState = adapterBodyweight.getInitialState({
  selectedBodyweightId: undefined,
})


