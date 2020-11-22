import { createFeatureSelector, createSelector } from '@ngrx/store';
import { selectTrainingState } from 'src/ngrx/training-log/training.selectors';
import { ExerciseState } from './exercise.state';

export const selectExerciseState = createFeatureSelector<ExerciseState>("exercise");

export const exercises = createSelector(
    selectExerciseState,
    selectTrainingState,
    (exerciseState, trainingState) => Object.values(exerciseState.exercises[trainingState.selectedTrainingId] ?? {}) 
);

export const exercisesDict = createSelector(
    selectExerciseState,
    selectTrainingState,
    (exerciseState, trainingState) => exerciseState.exercises[trainingState.selectedTrainingId]
); 

export const exerciseCount = createSelector(
    exercisesDict,
    exercises => Object.keys(exercises ?? {}).length
);

export const selectedExerciseId = createSelector(
    selectExerciseState,
    state => state.selectedExerciseId
);

export const selectedExercise = createSelector(
    selectedExerciseId,
    exercisesDict,
    (selectedId, exercises) => exercises ? exercises[selectedId] : null 
);

export const exercisePrs = createSelector(
    selectExerciseState,
    exerciseState => Object.values(exerciseState.exercisePrs[exerciseState.selectedExerciseId])
)
export const exercisePrsDict = createSelector(
    selectExerciseState,
    exerciseState => exerciseState.exercisePrs[exerciseState.selectedExerciseId]
)

export const selectedExerciseType = createSelector(
    selectExerciseState,
    exercisesDict,
    (exerciseState, exercises) => {

        if(!exercises) return null;

        let exercise = exercises[exerciseState.selectedExerciseId];
        
        return exercise?.exerciseType;
    }
);

export const selectedExerciseSets = createSelector(
    selectExerciseState,
    exercisesDict,
    (exerciseState, exercises) => {

        if(!exercises) return exercises;

        let exercise = exercises[exerciseState.selectedExerciseId];
        
        return exercise?.sets;
    }
);