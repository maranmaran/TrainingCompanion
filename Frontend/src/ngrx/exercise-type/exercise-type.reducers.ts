import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import * as ExerciseTypeActions from './exercise-type.actions';
import { adapterExerciseType, exerciseTypeInitialState, ExerciseTypeState } from './exercise-type.state';

export const exerciseTypeReducer: ActionReducer<ExerciseTypeState, Action> = createReducer(
  exerciseTypeInitialState,

  // CREATE
  on(ExerciseTypeActions.exerciseTypeCreated, (state: ExerciseTypeState, payload: { entity: ExerciseType }) => {

    return adapterExerciseType.addOne(payload.entity, {
      ...state,
      totalItems: state.totalItems + 1
    });
  }),

  // UPDATE
  on(ExerciseTypeActions.exerciseTypeUpdated, (state: ExerciseTypeState, payload: { entity: Update<ExerciseType> }) => {
    return adapterExerciseType.updateOne(payload.entity, state);
  }),

  // UPDATE MANY
  on(ExerciseTypeActions.manyExerciseTypesUpdated, (state: ExerciseTypeState, payload: { entities: Update<ExerciseType>[] }) => {
    return adapterExerciseType.updateMany(payload.entities, state);
  }),

  // DELETE
  on(ExerciseTypeActions.exerciseTypeDeleted, (state: ExerciseTypeState, payload: { id: string }) => {
    return adapterExerciseType.removeOne(payload.id, {
      ...state,
      totalItems: state.totalItems - 1
    });
  }),

  // GET ALL PAGED
  on(ExerciseTypeActions.exerciseTypesFetched, (state: ExerciseTypeState, payload: { entities: ExerciseType[], totalItems: number, pagingModel: PagingModel }) => {
    return {
      ...adapterExerciseType.addMany(payload.entities, state),
      totalItems: payload.totalItems,
      pagingModel: payload.pagingModel
    };
  }),

  // GET ALL
  on(ExerciseTypeActions.allExerciseTypesFetched, (state: ExerciseTypeState, payload: { entities: ExerciseType[] }) => {
    return adapterExerciseType.addMany(payload.entities, state);
  }),

  // SET SELECTED
  on(ExerciseTypeActions.setSelectedExerciseType, (state: ExerciseTypeState, payload: { entity: ExerciseType }) => {
    return {
      ...state,
      selectedExerciseTypeId: payload.entity ? payload.entity.id : null,
    };
  }),

  on(ExerciseTypeActions.clearExerciseTypeState, (state: ExerciseTypeState) => {
    return undefined;
  }),
);

export const getSelectedExerciseTypeId = (state: ExerciseTypeState) => state.selectedExerciseTypeId;

// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterExerciseType.getSelectors();
