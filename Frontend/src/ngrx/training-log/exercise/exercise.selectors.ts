import { createSelector, createFeatureSelector } from '@ngrx/store';
import * as fromExercise from './exercise.reducers';
import { ExerciseState } from './exercise.state';
import { selectTrainingLogState } from '../training-log.state';

// export const exerciseFeatureSelector = createFeatureSelector<ExerciseState>("exercise");
export const exerciseFeatureSelector = createSelector(
    selectTrainingLogState,
    state => state.exerciseState
)

export const selectExerciseState = createSelector(
    exerciseFeatureSelector,
    (state: ExerciseState) => state
);

export const exerciseIds = createSelector(
    selectExerciseState,
    fromExercise.selectIds
);

export const exerciseEntities = createSelector(
    selectExerciseState,
    fromExercise.selectEntities
);

export const exerciseProperties = createSelector(
    selectExerciseState,
    fromExercise.selectAll
);

export const exerciseCount = createSelector(
    selectExerciseState,
    fromExercise.selectTotal
);

export const selectedExerciseId = createSelector(
    selectExerciseState,
    fromExercise.getSelectedId
);

export const selectedExercise = createSelector(
    selectExerciseState,
    (state) => state.entities[state.selectedId]
);


