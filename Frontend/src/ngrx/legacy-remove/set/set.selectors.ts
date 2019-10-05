import { createSelector, createFeatureSelector } from '@ngrx/store';
import * as fromSet from './set.reducers';
import * as fromExercise from './../exercise/exercise.reducers';
import { SetState } from './set.state';
import { selectTrainingLogState } from '../training-log.state';

// export const setFeatureSelector = createFeatureSelector<SetState>("set");
export const setFeatureSelector = createSelector(
    selectTrainingLogState,
    state => state.setState
)

export const selectSetState = createSelector(
    setFeatureSelector,
    (state: SetState) => state
);

export const setIds = createSelector(
    selectSetState,
    fromSet.selectIds
);

export const setEntities = createSelector(
    selectSetState,
    fromSet.selectEntities
);

export const sets = createSelector(
    selectTrainingLogState,
    (state) => {
        if(!state.exerciseState.selectedId) return null;
        
        var selectedExercise = state.exerciseState.entities[state.exerciseState.selectedId];
        var sets = selectedExercise.sets;
        var setEntities = state.setState.entities;

        return sets.map(id => setEntities[id.toString()]);
    }
)

export const setCount = createSelector(
    selectSetState,
    fromSet.selectTotal
);

export const selectedSetId = createSelector(
    selectSetState,
    fromSet.getSelectedId
);

export const selectedSet = createSelector(
    selectSetState,
    (state) => state.entities[state.selectedId]
);


