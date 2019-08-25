import { first } from 'rxjs/operators';
import { ActionReducer, Action, createReducer, on, createFeatureSelector } from '@ngrx/store';
import * as ExercisePropertyTypeActions from './exercise-property-type.actions';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { ExercisePropertyTypeState, initialExercisePropertyTypeState } from './exercise-property-type.state';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';


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

    // SET SELECTED
    on(ExercisePropertyTypeActions.setSelectedExercisePropertyType, (state: ExercisePropertyTypeState, payload: {propertyType: ExercisePropertyType}) => {
        return {
            ...state,
            selectedType: payload.propertyType,
            selectedProperty: null
        }
    }),

    // SET SELECTED
    on(ExercisePropertyTypeActions.setSelectedExerciseProperty, (state: ExercisePropertyTypeState, payload: {property: ExerciseProperty}) => {
        return {
            ...state,
            selectedProperty: payload.property
        }
    }),

    // REORDER
    on(ExercisePropertyTypeActions.reorderExercisePropertyTypes, (state: ExercisePropertyTypeState, payload: {  previousItem: string, currentItem: string }) => {

        // pluck types
        let types = [...state.types];
       
        let first = Object.assign({}, types.find(x => x.id == payload.previousItem));
        let second = Object.assign({}, types.find(x => x.id == payload.currentItem));

        // switch
        let tempOrder = first.order;
        first.order = second.order;
        second.order = tempOrder;

        return {
            ...state,
            types: state.types.map(x => {
                switch (x.id) {
                    case first.id:
                        return first;
                    case second.id:
                        return second;
                    default:
                        return x
                }
            })
        }
    }),
);