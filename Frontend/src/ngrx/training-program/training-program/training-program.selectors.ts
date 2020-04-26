import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromTrainingProgram from './training-program.reducers';
import { TrainingProgramState } from './training-program.state';

export const selectTrainingProgramState = createFeatureSelector<TrainingProgramState>("trainingPrograms");

export const trainingProgramIds = createSelector(
    selectTrainingProgramState,
    fromTrainingProgram.selectIds
);

export const trainingProgramEntities = createSelector(
    selectTrainingProgramState,
    fromTrainingProgram.selectEntities
);

export const trainingPrograms = createSelector(
    selectTrainingProgramState,
    fromTrainingProgram.selectAll,
);

export const trainingProgramCount = createSelector(
    selectTrainingProgramState,
    fromTrainingProgram.selectTotal
);

// ids
export const selectedTrainingProgramId = createSelector(
    selectTrainingProgramState,
    fromTrainingProgram.getSelectedTrainingProgramId
);

// objects
export const selectedTrainingProgram = createSelector(
    selectTrainingProgramState,
    (state) => state.entities[state.selectedTrainingProgramId]
);
