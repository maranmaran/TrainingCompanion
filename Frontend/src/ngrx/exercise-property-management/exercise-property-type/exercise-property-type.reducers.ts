import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import * as ExercisePropertyTypeActions from './exercise-property-type.actions';
import { adapterExercisePropertyType, ExercisePropertyTypeState, exercisePropertyTypeInitialState } from './exercise-property-type.state';


export const exercisePropertyTypeReducer: ActionReducer<ExercisePropertyTypeState, Action> = createReducer(
    exercisePropertyTypeInitialState,

    // CREATE
    on(ExercisePropertyTypeActions.exercisePropertyTypeCreated, (state: ExercisePropertyTypeState, payload: {propertyType: ExercisePropertyType}) => {
        return adapterExercisePropertyType.addOne(payload.propertyType, state);
    }),

    // UPDATE
    on(ExercisePropertyTypeActions.exercisePropertyTypeUpdated, (state: ExercisePropertyTypeState, payload: {propertyType: Update<ExercisePropertyType>}) => {
        return adapterExercisePropertyType.updateOne(payload.propertyType, state);
    }),

    // UPDATE MANY
    on(ExercisePropertyTypeActions.manyExercisePropertyTypesUpdated, (state: ExercisePropertyTypeState, payload: {propertyTypes: Update<ExercisePropertyType>[]}) => {
        return adapterExercisePropertyType.updateMany(payload.propertyTypes, state);
    }),

    // DELETE
    on(ExercisePropertyTypeActions.exercisePropertyTypeDeleted, (state: ExercisePropertyTypeState, payload: {id: string}) => {
        return adapterExercisePropertyType.removeOne(payload.id, state);
    }),

    // GET ALL
    on(ExercisePropertyTypeActions.exercisePropertyTypesFetched, (state: ExercisePropertyTypeState, payload: {propertyTypes: ExercisePropertyType[]}) => {
        return adapterExercisePropertyType.addMany(payload.propertyTypes, {...state, selectedTypeId: null});
    }),

    // SET SELECTED
    on(ExercisePropertyTypeActions.setSelectedExercisePropertyType, (state: ExercisePropertyTypeState, payload: {propertyType: ExercisePropertyType}) => {
        return {
            ...state,
            selectedTypeId: payload.propertyType ? adapterExercisePropertyType.selectId(payload.propertyType) : null,
            selectedPropertyId: null
        }
    }),

    // REORDER
    on(ExercisePropertyTypeActions.reorderExercisePropertyTypes, (state: ExercisePropertyTypeState, payload: {  previousItem: string, currentItem: string }) => {

        // pluck types
        const first = state.entities[payload.previousItem];
        const second = state.entities[payload.currentItem];

        // temp
        let firstOrder = first.order;
        let secondOrder = second.order;

        // update statements
        const firstUpdate: Update<ExercisePropertyType> = {
            id: first.id,
            changes: { order: secondOrder }
        }
        const secondUpdate: Update<ExercisePropertyType> = {
            id: second.id,
            changes: { order: firstOrder }
        }

        // update
        return adapterExercisePropertyType.updateMany([firstUpdate, secondUpdate], state);
    }),
);

export const getSelectedTypeId = (state: ExercisePropertyTypeState) => state.selectedTypeId;
 
// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterExercisePropertyType.getSelectors();
 
// select the array of ids
export const selectTypeIds = selectIds;
 
// select the dictionary of entities
export const selectTypeEntities = selectEntities;
 
// select the array of entity objects
export const selectAllTypes = selectAll;
 
// select the total entity count
export const selectTypeTotal = selectTotal;