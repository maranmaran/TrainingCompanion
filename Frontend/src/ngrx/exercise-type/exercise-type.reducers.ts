import { first } from 'rxjs/operators';
import { ActionReducer, Action, createReducer, on, createFeatureSelector } from '@ngrx/store';
import * as ExerciseTypeActions from './exercise-type.actions';
import { ExerciseTypeState, initialExerciseTypeState } from './exercise-type.state';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';


export const exerciseTypeReducer: ActionReducer<ExerciseTypeState, Action> = createReducer(
    initialExerciseTypeState,

    // CREATE
    on(ExerciseTypeActions.exerciseTypeCreated, (state: ExerciseTypeState, payload: {exerciseType: ExerciseType}) => {
        return {
            ...state,
            types: [...state.types, payload.exerciseType]
        }
    }),

    // UPDATE
    on(ExerciseTypeActions.exerciseTypeUpdated, (state: ExerciseTypeState, payload: {exerciseType: ExerciseType}) => {
        return {
            ...state,
            types: state.types.map(x => x.id == payload.exerciseType.id  ? payload.exerciseType : x)
        }
    }),

    // UPDATE MANY
    on(ExerciseTypeActions.manyExercisePropertiesUpdated, (state: ExerciseTypeState, payload: {exerciseTypes: ExerciseType[]}) => {
        return {
            ...state,
            types: [...payload.exerciseTypes]
        }
    }),

    // DELETE
    on(ExerciseTypeActions.exerciseTypeDeleted, (state: ExerciseTypeState, payload: {id: string}) => {
        return {
            ...state,
            types: state.types.filter(x => x.id != payload.id)
        }
    }),

    // GET ALL
    on(ExerciseTypeActions.exerciseTypesFetched, (state: ExerciseTypeState, payload: {exerciseTypes: ExerciseType[]}) => {
        return {
            ...state,
            types: [...payload.exerciseTypes]
        }
    }),

    // SET SELECTED
    on(ExerciseTypeActions.setSelectedExerciseType, (state: ExerciseTypeState, payload: {exerciseType: ExerciseType}) => {
        return {
            ...state,
            selected: payload.exerciseType
        }
    }),
);