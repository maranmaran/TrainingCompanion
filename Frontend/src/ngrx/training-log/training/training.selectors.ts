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
    fromTraining.selectTrainingIds
);

export const trainingEntities = createSelector(
    selectTrainingState,
    fromTraining.selectTrainingEntities
);

export const allTrainings = createSelector(
    selectTrainingState,
    fromTraining.selectAllTrainings
);

export const trainingCount = createSelector(
    selectTrainingState,
    fromTraining.selectTrainingTotal
);

export const selectedTrainingId = createSelector(
    selectTrainingState,
    fromTraining.getSelectedTrainingId
);

export const selectedTraining = createSelector(
    selectTrainingState,
    (state) => state.entities[state.selectedTrainingId]
);
