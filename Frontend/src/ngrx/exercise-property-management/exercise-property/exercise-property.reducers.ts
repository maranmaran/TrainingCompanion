import { ActionReducer, Action, createReducer, on } from '@ngrx/store';
import * as ExercisePropertyActions from './exercise-property.actions';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import { ExercisePropertyState, initialExercisePropertyState } from './exercise-property.state';


export const exercisePropertyReducer: ActionReducer<ExercisePropertyState, Action> = createReducer(
    initialExercisePropertyState,

    // CREATE
    on(ExercisePropertyActions.exercisePropertyCreated, (state: ExercisePropertyState, payload: {property: ExerciseProperty}) => {
        return {
            ...state,
            properties: [...state.properties, payload.property]
        }
    }),

    // UPDATE
    on(ExercisePropertyActions.exercisePropertyUpdated, (state: ExercisePropertyState, payload: {property: ExerciseProperty}) => {
        return {
            ...state,
            properties: state.properties.map(x => x.id == payload.property.id  ? payload.property : x)
        }
    }),

    // UPDATE MANY
    on(ExercisePropertyActions.manyExercisePropertiesUpdated, (state: ExercisePropertyState, payload: {properties: ExerciseProperty[]}) => {
        return {
            ...state,
            properties: [...payload.properties]
        }
    }),

    // DELETE
    on(ExercisePropertyActions.exercisePropertyDeleted, (state: ExercisePropertyState, payload: {id: string}) => {
        return {
            ...state,
            properties: state.properties.filter(x => x.id != payload.id)
        }
    }),

    // GET ALL
    on(ExercisePropertyActions.exercisePropertiesFetched, (state: ExercisePropertyState, payload: {properties: ExerciseProperty[]}) => {
        return {
            ...state,
            properties: [...payload.properties]
        }
    }),
);