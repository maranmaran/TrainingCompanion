import { createSelector, createFeatureSelector } from '@ngrx/store';
import * as fromSet from './set.reducers';
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

export const setProperties = createSelector(
    selectSetState,
    fromSet.selectAll
);

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


