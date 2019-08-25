import { first } from 'rxjs/operators';
import { ActionReducer, Action, createReducer, on, createFeatureSelector } from '@ngrx/store';
import * as TrainingActions from './training.actions';
import { TrainingState, initialTrainingState } from './training.state';
import { Training } from 'src/server-models/entities/training.model';


export const trainingReducer: ActionReducer<TrainingState, Action> = createReducer(
    initialTrainingState,

    // CREATE
    on(TrainingActions.trainingCreated, (state: TrainingState, payload: {training: Training}) => {
        return {
            ...state,
            trainings: [...state.trainings, payload.training]
        }
    }),

    // UPDATE
    on(TrainingActions.trainingUpdated, (state: TrainingState, payload: {training: Training}) => {
        return {
            ...state,
            trainings: state.trainings.map(x => x.id == payload.training.id  ? payload.training : x)
        }
    }),

    // UPDATE MANY
    on(TrainingActions.manyExercisePropertiesUpdated, (state: TrainingState, payload: {trainings: Training[]}) => {
        return {
            ...state,
            trainings: [...payload.trainings]
        }
    }),

    // DELETE
    on(TrainingActions.trainingDeleted, (state: TrainingState, payload: {id: string}) => {
        return {
            ...state,
            trainings: state.trainings.filter(x => x.id != payload.id)
        }
    }),

    // GET ALL
    on(TrainingActions.trainingsFetched, (state: TrainingState, payload: {trainings: Training[]}) => {
        return {
            ...state,
            trainings: [...payload.trainings]
        }
    }),

    // SET SELECTED
    on(TrainingActions.setSelectedTraining, (state: TrainingState, payload: {training: Training}) => {
        return {
            ...state,
            selected: payload.training
        }
    }),
);