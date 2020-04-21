
import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { TrainingBlock } from '../../../server-models/entities/training-program.model';
import * as TrainingBlockActions from './training-block.actions';
import { adapterTrainingBlock, trainingBlockInitialState, TrainingBlockState } from './training-block.state';

export const trainingBlockReducer: ActionReducer<TrainingBlockState, Action> = createReducer(
    trainingBlockInitialState,


    // CREATE
    on(TrainingBlockActions.trainingBlockCreated, (state: TrainingBlockState, payload: { entity: TrainingBlock }) => {
        return adapterTrainingBlock.addOne(payload.entity, state);
    }),

    // UPDATE
    on(TrainingBlockActions.trainingBlockUpdated, (state: TrainingBlockState, payload: { entity: Update<TrainingBlock> }) => {
        return adapterTrainingBlock.updateOne(payload.entity, state);
    }),

    // DELETE
    on(TrainingBlockActions.trainingBlockDeleted, (state: TrainingBlockState, payload: { id: string }) => {
        return adapterTrainingBlock.removeOne(payload.id, state);
    }),

    // GET ALL
    on(TrainingBlockActions.trainingBlockFetched, (state: TrainingBlockState, payload: { entities: TrainingBlock[] }) => {
        return adapterTrainingBlock.addAll(payload.entities, state);
    }),

    // SET SELECTED
    on(TrainingBlockActions.setSelectedTrainingBlock, (state: TrainingBlockState, payload: { entity: TrainingBlock }) => {
        return {
            ...state,
            selectedTrainingBlockId: payload.entity ? payload.entity.id : null,
        };
    }),

);

export const getSelectedTrainingBlockId = (state: TrainingBlockState) => state.selectedTrainingBlockId;

// get the selectors
export const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
} = adapterTrainingBlock.getSelectors();
