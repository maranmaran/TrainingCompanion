import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromTrainingProgramUser from './training-program-user.reducers';
import { TrainingProgramUserState } from './training-program-user.state';

export const selectTrainingProgramUserState = createFeatureSelector<TrainingProgramUserState>("trainingProgramUsers");

export const trainingProgramUserIds = createSelector(
    selectTrainingProgramUserState,
    fromTrainingProgramUser.selectIds
);

export const trainingProgramUserEntities = createSelector(
    selectTrainingProgramUserState,
    fromTrainingProgramUser.selectEntities
);

export const trainingProgramUsers = createSelector(
    selectTrainingProgramUserState,
    fromTrainingProgramUser.selectAll,
);

export const trainingProgramUserCount = createSelector(
    selectTrainingProgramUserState,
    fromTrainingProgramUser.selectTotal
);
