import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromTrainingBlock from './training-block.reducers';
import { TrainingBlockState } from './training-block.state';

export const selectTrainingBlockState = createFeatureSelector<TrainingBlockState>("trainingBlocks");

export const trainingBlockIds = createSelector(
    selectTrainingBlockState,
    fromTrainingBlock.selectIds
);

export const trainingBlockEntities = createSelector(
    selectTrainingBlockState,
    fromTrainingBlock.selectEntities
);

export const trainingBlocks = createSelector(
    selectTrainingBlockState,
    fromTrainingBlock.selectAll,
);

export const trainingBlockCount = createSelector(
    selectTrainingBlockState,
    fromTrainingBlock.selectTotal
);

// ids
export const selectedTrainingBlockId = createSelector(
    selectTrainingBlockState,
    fromTrainingBlock.getSelectedTrainingBlockId
);

// objects
export const selectedTrainingBlock = createSelector(
    selectTrainingBlockState,
    (state) => state.entities[state.selectedTrainingBlockId]
);
