import { ActionReducer, Action, createReducer, on, createFeatureSelector } from '@ngrx/store';
import * as ExercisePropertyTypeActions from './exercise-property-type.actions';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { ExercisePropertyTypeState, initialExercisePropertyTypeState } from './exercise-property-type.state';


export const exercisePropertyTypeReducer: ActionReducer<ExercisePropertyTypeState, Action> = createReducer(
    initialExercisePropertyTypeState,

    // CREATE
    on(ExercisePropertyTypeActions.exercisePropertyTypeCreated, (state: ExercisePropertyTypeState, payload: {propertyType: ExercisePropertyType}) => {
        return {
            ...state,
            types: [...state.types, payload.propertyType]
        }
    }),

    // UPDATE
    on(ExercisePropertyTypeActions.exercisePropertyTypeUpdated, (state: ExercisePropertyTypeState, payload: {propertyType: ExercisePropertyType}) => {
        return {
            ...state,
            types: state.types.map(x => x.id == payload.propertyType.id  ? payload.propertyType : x)
        }
    }),

    // UPDATE MANY
    on(ExercisePropertyTypeActions.manyExercisePropertiesUpdated, (state: ExercisePropertyTypeState, payload: {propertyTypes: ExercisePropertyType[]}) => {
        return {
            ...state,
            types: [...payload.propertyTypes]
        }
    }),

    // DELETE
    on(ExercisePropertyTypeActions.exercisePropertyTypeDeleted, (state: ExercisePropertyTypeState, payload: {id: string}) => {
        return {
            ...state,
            types: state.types.filter(x => x.id != payload.id)
        }
    }),

    // GET ALL
    on(ExercisePropertyTypeActions.exercisePropertyTypesFetched, (state: ExercisePropertyTypeState, payload: {propertyTypes: ExercisePropertyType[]}) => {
        return {
            ...state,
            types: [...payload.propertyTypes]
        }
    }),
);