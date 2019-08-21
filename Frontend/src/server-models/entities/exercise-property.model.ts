import { ExercisePropertyType } from './exercise-property-type.model';

export class ExerciseProperty {
    id: string;
    value: string;
    active: boolean;
    order: number;

    exercisePropertyTypeId: string;
    exercisePropertyType: ExercisePropertyType
}