import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';


// Exercise property type ENTITY
export interface ExercisePropertyTypeState extends EntityState<ExercisePropertyType>{
    selectedTypeId: string | number,
}


//sort function
export function sortByOrder(a: ExercisePropertyType | ExerciseProperty, b: ExercisePropertyType | ExerciseProperty): number {
    return (a.order - b.order) > 0 ? 1 : (a.order - b.order) < 0 ? -1 : 0;
}

// ADAPTERS
export const adapterExercisePropertyType = createEntityAdapter<ExercisePropertyType>({sortComparer: sortByOrder});

// INITIAL STATES
export const exercisePropertyTypeInitialState: ExercisePropertyTypeState = adapterExercisePropertyType.getInitialState({selectedTypeId: undefined, selectedPropertyId: undefined});
