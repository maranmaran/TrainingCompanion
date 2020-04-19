
import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { TrainingBlockDay } from 'src/server-models/entities/training-program.model';
import * as TrainingBlockDayActions from './training-block-day.actions';
import { adapterTrainingBlockDay, trainingBlockDayInitialState, TrainingBlockDayState } from './training-block-day.state';

export const trainingBlockDayReducer: ActionReducer<TrainingBlockDayState, Action> = createReducer(
    trainingBlockDayInitialState,


    // CREATE
    on(TrainingBlockDayActions.trainingBlockDayCreated, (state: TrainingBlockDayState, payload: { entity: TrainingBlockDay }) => {
        return adapterTrainingBlockDay.addOne(payload.entity, state);
    }),

    // UPDATE
    on(TrainingBlockDayActions.trainingBlockDayUpdated, (state: TrainingBlockDayState, payload: { entity: Update<TrainingBlockDay> }) => {
        return adapterTrainingBlockDay.updateOne(payload.entity, state);
    }),

    // DELETE
    on(TrainingBlockDayActions.trainingBlockDayDeleted, (state: TrainingBlockDayState, payload: { id: string }) => {
        return adapterTrainingBlockDay.removeOne(payload.id, state);
    }),

    // GET ALL
    on(TrainingBlockDayActions.trainingBlockDayFetched, (state: TrainingBlockDayState, payload: { entities: TrainingBlockDay[] }) => {
        return adapterTrainingBlockDay.addMany(payload.entities, state);
    }),

    // SET SELECTED
    on(TrainingBlockDayActions.setSelectedTrainingBlockDay, (state: TrainingBlockDayState, payload: { entity: TrainingBlockDay }) => {
        return {
            ...state,
            selectedTrainingBlockDayId: payload.entity ? payload.entity.id : null,
        };
    }),

);

export const getSelectedTrainingBlockDayId = (state: TrainingBlockDayState) => state.selectedTrainingBlockDayId;

// get the selectors
export const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
} = adapterTrainingBlockDay.getSelectors();
