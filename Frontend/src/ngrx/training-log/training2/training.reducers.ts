import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import * as TrainingActions from './training.actions';
import { adapterTraining, trainingInitialState, TrainingState } from './training.state';

export const trainingReducer: ActionReducer<TrainingState, Action> = createReducer(
    trainingInitialState,

    // CREATE
    on(TrainingActions.trainingCreated, (state: TrainingState, payload: { entity: Training }) => {
        return adapterTraining.addOne(payload.entity, state);
    }),

    // UPDATE
    on(TrainingActions.trainingUpdated, (state: TrainingState, payload: { entity: Update<Training> }) => {
        return adapterTraining.updateOne(payload.entity, state);
    }),

    // UPDATE MANY
    on(TrainingActions.manyTrainingsUpdated, (state: TrainingState, payload: { entities: Update<Training>[] }) => {
        return adapterTraining.updateMany(payload.entities, state);
    }),

    // DELETE
    on(TrainingActions.trainingDeleted, (state: TrainingState, payload: { id: string }) => {
        return adapterTraining.removeOne(payload.id, state);
    }),

    // GET ALL
    on(TrainingActions.trainingsFetched, (state: TrainingState, payload: { entities: Training[] }) => {
        return adapterTraining.addMany(payload.entities, state);
    }),

    // SET SELECTED
    on(TrainingActions.setSelectedTraining, (state: TrainingState, payload: { entity: Training }) => {
        return {
            ...state,
            selectedTrainingId: payload.entity ? payload.entity.id : null,
        };
    }),
    on(TrainingActions.setSelectedExercise, (state: TrainingState, payload: { entity: Exercise }) => {
        return {
            ...state,
            selectedExerciseId: payload.entity ? payload.entity.id : null,
        };
    }),

    on(TrainingActions.clearState, (state: TrainingState) => {
      return undefined;
  }),
);

export const getSelectedTrainingId = (state: TrainingState) => state.selectedTrainingId;
export const getSelectedExerciseId = (state: TrainingState) => state.selectedExerciseId;

// get the selectors
export const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
} = adapterTraining.getSelectors();
