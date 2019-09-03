import { createSelector, createFeatureSelector } from '@ngrx/store';
import * as fromTraining from './training.reducers';
import { TrainingState } from './training.state';


export const selectTrainingState = createFeatureSelector<TrainingState>("training");

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
export const selectedExercisePropertyId = createSelector(
    selectTrainingState,
    fromTraining.getSelectedExerciseId
);
export const selectedSetId = createSelector(
    selectTrainingState,
    fromTraining.getSelectedSetId
);

export const selectedTraining = createSelector(
    selectTrainingState,
    (state) => state.entities[state.selectedTrainingId]
);
export const selectedExercises = createSelector(
    selectTrainingState,
    (state) => {
        
        var training = (state.entities[state.selectedTrainingId]);

        if(training) {
            return training.exercises; // not normalized
        }
        
        return null; 
    }
);
export const selectedExerciseType = createSelector(
    selectTrainingState,
    (state) => {
        
        var training = (state.entities[state.selectedTrainingId]);

        if(training) {
            return training.exercises.filter(x => x.id == state.selectedExerciseId)[0].exerciseType; // not normalized
        }
        
        return null; 
    }
);
export const selectedExercise = createSelector(
    selectTrainingState,
    (state) => {
        
        var training = (state.entities[state.selectedTrainingId]);

        if(training) {
            return training.exercises.filter(x => x.id == state.selectedExerciseId)[0]; // not normalized
        }
        
        return null; 
    }
);
export const selectedSet = createSelector(
    selectTrainingState,
    (state) => {
        
        var training = (state.entities[state.selectedTrainingId]);

        if(training) {
            var exercise = training.exercises.filter(x => x.id == state.selectedExerciseId)[0]; // not normalized

            if(exercise) {
                return exercise.sets.filter(x => x.id == state.selectedSetId)[0]; // not normalized
            } 
        }
        
        return null; 
    }
);
export const selectedSets = createSelector(
    selectTrainingState,
    (state) => {
        
        var training = (state.entities[state.selectedTrainingId]);

        if(training) {
            var exercise = training.exercises.filter(x => x.id == state.selectedExerciseId)[0]; // not normalized

            if(exercise) {
                return exercise.sets; // not normalized
            } 
        }
        
        return null; 
    }
);


