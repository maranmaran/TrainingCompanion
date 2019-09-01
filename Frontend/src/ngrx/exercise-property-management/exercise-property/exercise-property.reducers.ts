import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import * as ExercisePropertyTypeActions from './exercise-property.actions';
import { adapterExerciseProperty, exercisePropertyInitialState, ExercisePropertyState } from './exercise-property.state';


export const exercisePropertyReducer: ActionReducer<ExercisePropertyState, Action> = createReducer(
    exercisePropertyInitialState,

    // CREATE
    on(ExercisePropertyTypeActions.exercisePropertyCreated, (state: ExercisePropertyState, payload: {property: ExerciseProperty}) => {
        return adapterExerciseProperty.addOne(payload.property, state);
    }),

    // UPDATE
    on(ExercisePropertyTypeActions.exercisePropertyUpdated, (state: ExercisePropertyState, payload: {property: Update<ExerciseProperty>}) => {
        return adapterExerciseProperty.updateOne(payload.property, state);
    }),

    // UPDATE MANY
    on(ExercisePropertyTypeActions.manyExercisePropertiesUpdated, (state: ExercisePropertyState, payload: {properties: Update<ExerciseProperty>[]}) => {
        return adapterExerciseProperty.updateMany(payload.properties, state);
    }),

    // DELETE
    on(ExercisePropertyTypeActions.exercisePropertyDeleted, (state: ExercisePropertyState, payload: {id: string}) => {
        return adapterExerciseProperty.removeOne(payload.id, state);
    }),

    // GET ALL
    on(ExercisePropertyTypeActions.exercisePropertiesFetched, (state: ExercisePropertyState, payload: {properties: ExerciseProperty[]}) => {
        return adapterExerciseProperty.addMany(payload.properties, state);
    }),

    // SET SELECTED
    on(ExercisePropertyTypeActions.setSelectedExerciseProperty, (state: ExercisePropertyState, payload: {property: ExerciseProperty}) => {
        return {
            ...state,
            selectedPropertyId: payload.property ? adapterExerciseProperty.selectId(payload.property) : null
        }
    }),

);

export const getSelectedPropertyId = (state: ExercisePropertyState) => state.selectedPropertyId;

export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterExerciseProperty.getSelectors();
 
// select the array of ids
export const selectPropertyIds = selectIds;
 
// select the dictionary of entities
export const selectPropertyEntities = selectEntities;
 
// select the array of entity objects
export const selectAllProperties = selectAll;
 
// select the total entity count
export const selectPropertyTotal = selectTotal;