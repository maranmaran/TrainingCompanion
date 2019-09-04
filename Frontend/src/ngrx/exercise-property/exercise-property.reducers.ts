import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import * as ExercisePropertyActions from './exercise-property.actions';
import { adapterExerciseProperty, exercisePropertyInitialState, ExercisePropertyState } from './exercise-property.state';


export const exercisePropertyReducer: ActionReducer<ExercisePropertyState, Action> = createReducer(
    exercisePropertyInitialState,

    // CREATE
    on(ExercisePropertyActions.exercisePropertyCreated, (state: ExercisePropertyState, payload: {entity: ExerciseProperty}) => {
        return adapterExerciseProperty.addOne(payload.entity, state);
    }),

    // UPDATE
    on(ExercisePropertyActions.exercisePropertyUpdated, (state: ExercisePropertyState, payload: {entity: Update<ExerciseProperty>}) => {
        return adapterExerciseProperty.updateOne(payload.entity, state);
    }),

    // UPDATE MANY
    on(ExercisePropertyActions.manyExercisePropertiesUpdated, (state: ExercisePropertyState, payload: {entities: Update<ExerciseProperty>[]}) => {
        return adapterExerciseProperty.updateMany(payload.entities, state);
    }),

    // DELETE
    on(ExercisePropertyActions.exercisePropertyDeleted, (state: ExercisePropertyState, payload: {id: string}) => {
        return adapterExerciseProperty.removeOne(payload.id, state);
    }),

    // GET ALL
    on(ExercisePropertyActions.exercisePropertiesFetched, (state: ExercisePropertyState, payload: {entities: ExerciseProperty[]}) => {
        return adapterExerciseProperty.addMany(payload.entities, {...state, selectedTypeId: null});
    }),

    // SET SELECTED
    on(ExercisePropertyActions.setSelectedExerciseProperty, (state: ExercisePropertyState, payload: {entity: ExerciseProperty}) => {
        return {
            ...state,
            selectedTypeId: payload.entity ? adapterExerciseProperty.selectId(payload.entity) : null,
            selectedPropertyId: null
        }
    }),

    // REORDER
    on(ExercisePropertyActions.reorderExerciseProperties, (state: ExercisePropertyState, payload: {  itemToReplace: string, itemToReplaceWith: string }) => {

        // pluck types
        const itemToReplace = state.entities[payload.itemToReplace];
        const itemToReplaceWith = state.entities[payload.itemToReplaceWith];

        // temp
        let firstOrder = itemToReplace.order;
        let secondOrder = itemToReplaceWith.order;

        // update statements
        const firstUpdate: Update<ExerciseProperty> = {
            id: itemToReplace.id,
            changes: { order: secondOrder }
        }
        const secondUpdate: Update<ExerciseProperty> = {
            id: itemToReplaceWith.id,
            changes: { order: firstOrder }
        }

        // update
        return adapterExerciseProperty.updateMany([firstUpdate, secondUpdate], state);
    }),
);

export const getSelectedId = (state: ExercisePropertyState) => state.selectedId;
 
// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterExerciseProperty.getSelectors();
 
// select the array of ids
export const selectTypeIds = selectIds;
 
// select the dictionary of entities
export const selectTypeEntities = selectEntities;
 
// select the array of entity objects
export const selectAllTypes = selectAll;
 
// select the total entity count
export const selectTypeTotal = selectTotal;