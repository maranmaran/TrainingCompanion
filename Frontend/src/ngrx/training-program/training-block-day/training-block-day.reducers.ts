
import { Update, Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { TrainingBlockDay } from 'src/server-models/entities/training-program.model';
import { Training } from 'src/server-models/entities/training.model';
import * as TrainingBlockDayActions from './training-block-day.actions';
import { adapterTrainingBlockDay, trainingBlockDayInitialState, TrainingBlockDayState } from './training-block-day.state';
import * as _ from 'lodash-es';

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
       return adapterTrainingBlockDay.setAll(payload.entities, state); // replace current entities with these
    }),

    // SET SELECTED
    on(TrainingBlockDayActions.setSelectedTrainingBlockDay, (state: TrainingBlockDayState, payload: { entity: TrainingBlockDay }) => {
        return {
            ...state,
            selectedTrainingBlockDayId: payload.entity?.id == state.selectedTrainingBlockDayId ? null : payload.entity?.id,
        };
    }),


    on(TrainingBlockDayActions.addTraining, (state: TrainingBlockDayState, payload: { dayId: string, training: Training }) => {
        
        const entities = _.cloneDeep(state.entities);
        const day = entities[payload.dayId] as TrainingBlockDay;

        let update: Update<TrainingBlockDay> = {
            id: payload.dayId,
            changes: {
                trainings: [...day.trainings, payload.training]
            }
        };

        return adapterTrainingBlockDay.updateOne(update, state);
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
