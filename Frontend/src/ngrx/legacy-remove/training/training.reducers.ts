import { Dictionary, Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { Training } from 'src/server-models/entities/training.model';
import * as TrainingActions from './training.actions';
import { adapterTraining, trainingInitialState, TrainingState } from './training.state';

export const trainingReducer: ActionReducer<TrainingState, Action> = createReducer(
    trainingInitialState,

    // CREATE
    on(TrainingActions.trainingCreated, (state: TrainingState, payload: {training: Training}) => {
        return adapterTraining.addOne(payload.training, state);
    }),

    // UPDATE
    on(TrainingActions.trainingUpdated, (state: TrainingState, payload: {training: Update<Training>}) => {
        return adapterTraining.updateOne(payload.training, state);
    }),

    // UPDATE MANY
    on(TrainingActions.manyTrainingsUpdated, (state: TrainingState, payload: {trainings: Update<Training>[]}) => {
        return adapterTraining.updateMany(payload.trainings, state);
    }),

    // DELETE
    on(TrainingActions.trainingDeleted, (state: TrainingState, payload: {id: string}) => {
        return adapterTraining.removeOne(payload.id, state);
    }),

    // GET ALL
    on(TrainingActions.trainingsFetched, (state: TrainingState, payload: { entities: Dictionary<Training>, ids: string[] }) => {
        return {
            ...state,
            entities: payload.entities,
            ids: payload.ids
        }
    }),

    // SET SELECTED
    on(TrainingActions.setSelectedTraining, (state: TrainingState, payload: {entity: Training}) => {
        return {
            ...state,
            selectedId: payload.entity ? payload.entity.id : null,
        }
    }),
);

export const getSelectedTrainingId = (state: TrainingState) => state.selectedId;

// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterTraining.getSelectors();
