import { TrainingState, trainingInitialState } from './training/training.state';
import { ExerciseState, exerciseInitialState } from './exercise/exercise.state';
import { SetState, setInitialState } from './set/set.state';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';
import { trainingReducer } from './training/training.reducers';
import { exerciseReducer } from './exercise/exercise.reducers';
import { setReducer } from './set/set.reducers';

// JOIN STATE
export interface TrainingLogState {
    trainingState: TrainingState;
    exerciseState: ExerciseState;
    setState: SetState;
}

// initial state
export const trainingLogInitialState: TrainingLogState = {
    trainingState: trainingInitialState,
    exerciseState: exerciseInitialState,
    setState: setInitialState,
}

// Reducer map of the lib
export const trainingLogReducerMap: ActionReducerMap<TrainingLogState> = {
    trainingState: trainingReducer,
    exerciseState: exerciseReducer,
    setState: setReducer,
};

export const selectTrainingLogState = createFeatureSelector<TrainingLogState>("trainingLogState");


