import { createFeatureSelector, createSelector } from '@ngrx/store';
import { sortBy } from 'src/business/utils/utils';
import * as fromTraining from './training.reducers';
import { TrainingState } from './training.state';

export const selectTrainingState = createFeatureSelector<TrainingState>("training");

export const trainingIds = createSelector(
    selectTrainingState,
    fromTraining.selectIds
);

export const trainingEntities = createSelector(
    selectTrainingState,
    fromTraining.selectEntities
);

export const trainings = createSelector(
    selectTrainingState,
    fromTraining.selectAll,
);

export const trainingsForMonth = createSelector(
  trainings,
  (trainings, month) => trainings.filter(training => training.dateTrained)
)

export const trainingCount = createSelector(
    selectTrainingState,
    fromTraining.selectTotal
);

// ids
export const selectedTrainingId = createSelector(
    selectTrainingState,
    fromTraining.getSelectedTrainingId
);
export const selectedExerciseId = createSelector(
    selectTrainingState,
    fromTraining.getSelectedExerciseId
);

// objects
export const selectedTraining = createSelector(
    selectTrainingState,
    (state) => state.entities[state.selectedTrainingId]
);
export const selectedTrainingExercises = createSelector(
    selectTrainingState,
    (state) => {

        var training = (state.entities[state.selectedTrainingId]);

        if (training) {
            return sortBy(training.exercises, ['order']); // not normalized
        }

        return null;
    }
);
export const selectedExerciseType = createSelector(
    selectTrainingState,
    (state) => {

        var training = (state.entities[state.selectedTrainingId]);

        if (training) {
            return training.exercises.filter(x => x.id == state.selectedExerciseId)[0].exerciseType; // not normalized
        }

        return null;
    }
);
export const selectedExercise = createSelector(
    selectTrainingState,
    (state) => {

        var training = (state.entities[state.selectedTrainingId]);

        if (training) {
            return training.exercises.filter(x => x.id == state.selectedExerciseId)[0]; // not normalized
        }

        return null;
    }
);
export const selectedExerciseSets = createSelector(
    selectTrainingState,
    (state) => {

        var training = (state.entities[state.selectedTrainingId]);

        if (training) {
            var exercise = training.exercises.filter(x => x.id == state.selectedExerciseId)[0]; // not normalized

            if (exercise) {
                return exercise.sets; // not normalized
            }
        }

        return null;
    }
);

export const sessionVolume = createSelector(
    selectedTraining,
    training => training?.exercises?.reduce((a, b) => a + b.sets.reduce((c, d) => c + d.volume, 0), 0)
)
export const sessionNumberOfLifts = createSelector(
    selectedTraining,
    training => training?.exercises?.reduce((a, b) => a + b.sets.reduce((c, d) => c + d.reps, 0), 0)
)
