import { TrainingState, trainingInitialState, adapterTraining } from './training.state';
import { ActionReducer, createReducer, Action, on } from '@ngrx/store';
import { Training } from 'src/server-models/entities/training.model';
import { Update } from '@ngrx/entity';
import * as TrainingActions from './training.actions';

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
    on(TrainingActions.trainingDeleted, (state: TrainingState, payload: {id: string}) => {
        return adapterTraining.removeOne(payload.id, state);
    }),

    // GET ALL
    on(TrainingActions.trainingsFetched, (state: TrainingState, payload: { entities: Training[] }) => {
        return adapterTraining.addMany(payload.entities, state);
    }),

    // SET SELECTED
    on(TrainingActions.setSelectedTraining, (state: TrainingState, payload: {entity: Training}) => {
        return {
            ...state,
            selectedId: payload.entity ? payload.entity.id : null,
        }
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