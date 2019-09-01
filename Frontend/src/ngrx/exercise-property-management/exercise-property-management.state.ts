import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';
import { exercisePropertyTypeReducer } from './exercise-property-type/exercise-property-type.reducers';
import { exercisePropertyTypeInitialState, ExercisePropertyTypeState } from './exercise-property-type/exercise-property-type.state';
import { exercisePropertyReducer } from './exercise-property/exercise-property.reducers';
import { exercisePropertyInitialState, ExercisePropertyState } from './exercise-property/exercise-property.state';

// JOIN STATE
export interface ExercisePropertyManagementState {
    typeState: ExercisePropertyTypeState;
    propertyState: ExercisePropertyState;
}

// initial state
export const exercisePropertyManagementInitialState: ExercisePropertyManagementState = {
    typeState: exercisePropertyTypeInitialState,
    propertyState: exercisePropertyInitialState
}

// Reducer map of the lib
export const exercisePropertyManagementReducerMap: ActionReducerMap<ExercisePropertyManagementState> = {
    typeState: exercisePropertyTypeReducer,
    propertyState: exercisePropertyReducer
};

export const selectExercisePropertyManagementState = createFeatureSelector<ExercisePropertyManagementState>("exercisePropertyManagement");


