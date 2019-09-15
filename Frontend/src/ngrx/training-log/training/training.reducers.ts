import { Set } from 'src/server-models/entities/set.model';
import { Update, Dictionary } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import * as TrainingActions from './training.actions';
import { adapterTraining, TrainingState, trainingInitialState, adapterExercise, adapterSet } from './training.state';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';

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
    on(TrainingActions.setSelectedTraining, (state: TrainingState, payload: {training: Training}) => {
        return {
            ...state,
            selectedTrainingId: payload.training ? adapterTraining.selectId(payload.training) : null,
            selectedExerciseId: null,
            selectedSetId: null
        }
    }),
);

export const getSelectedTrainingId = (state: TrainingState) => state.selectedTrainingId;
 
// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterTraining.getSelectors();
 
// select the array of ids
export const selectTrainingIds = selectIds;
 
// select the dictionary of entities
export const selectTrainingEntities = selectEntities;
 
// select the array of entity objects
export const selectAllTrainings= selectAll;
 
// select the total entity count
export const selectTrainingTotal = selectTotal;