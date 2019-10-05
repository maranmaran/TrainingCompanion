import { createSelector } from '@ngrx/store';
import * as fromTraining from './training.reducers';
import { selectTrainingLogState } from '../training-log.state';


// export const selectTrainingState = createFeatureSelector<TrainingState>("training");
export const selectTrainingState = createSelector(
    selectTrainingLogState,
    state => state.trainingState
)

export const trainingIds = createSelector(
    selectTrainingState,
    fromTraining.selectIds
);

export const trainingEntities = createSelector(
    selectTrainingState,
    fromTraining.selectEntities
);

export const allTrainings = createSelector(
    selectTrainingState,
    fromTraining.selectAll
);

export const trainingCount = createSelector(
    selectTrainingState,
    fromTraining.selectTotal
);

export const selectedTrainingId = createSelector(
    selectTrainingState,
    fromTraining.getSelectedTrainingId
);

export const selectedTraining = createSelector(
    selectTrainingState,
    (state) => state.entities[state.selectedId]
);
