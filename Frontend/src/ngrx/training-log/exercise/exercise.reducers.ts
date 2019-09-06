import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { Exercise } from 'src/server-models/entities/exercise.model';
import * as ExerciseActions from './exercise.actions';
import { adapterExercise, exerciseInitialState, ExerciseState } from './exercise.state';


export const exerciseReducer: ActionReducer<ExerciseState, Action> = createReducer(
    exerciseInitialState,

    // CREATE
    on(ExerciseActions.exerciseCreated, (state: ExerciseState, payload: {entity: Exercise}) => {
        return adapterExercise.addOne(payload.entity, state);
    }),

    // UPDATE
    on(ExerciseActions.exerciseUpdated, (state: ExerciseState, payload: {entity: Update<Exercise>}) => {
        return adapterExercise.updateOne(payload.entity, state);
    }),

    // UPDATE MANY
    on(ExerciseActions.manyExercisePropertiesUpdated, (state: ExerciseState, payload: {entities: Update<Exercise>[]}) => {
        return adapterExercise.updateMany(payload.entities, state);
    }),

    // DELETE
    on(ExerciseActions.exerciseDeleted, (state: ExerciseState, payload: {id: string}) => {
        return adapterExercise.removeOne(payload.id, state);
    }),

    // GET ALL
    on(ExerciseActions.exercisePropertiesFetched, (state: ExerciseState, payload: {entities: Exercise[]}) => {
        return adapterExercise.addMany(payload.entities, {...state, selectedTypeId: null});
    }),

    // SET SELECTED
    on(ExerciseActions.setSelectedExercise, (state: ExerciseState, payload: {entity: Exercise}) => {
        return {
            ...state,
            selectedTypeId: payload.entity ? adapterExercise.selectId(payload.entity) : null,
            selectedPropertyId: null
        }
    }),

);

export const getSelectedId = (state: ExerciseState) => state.selectedId;
 
// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterExercise.getSelectors();
 
// select the array of ids
export const selectTypeIds = selectIds;
 
// select the dictionary of entities
export const selectTypeEntities = selectEntities;
 
// select the array of entity objects
export const selectAllTypes = selectAll;
 
// select the total entity count
export const selectTypeTotal = selectTotal;