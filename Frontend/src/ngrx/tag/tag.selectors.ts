import { createSelector, createFeatureSelector } from '@ngrx/store';
import * as fromTag from './tag.reducers';
import { TagState } from './tag.state';

export const tagFeatureSelector = createFeatureSelector<TagState>("tag");

export const selectTagState = createSelector(
    tagFeatureSelector,
    (state: TagState) => state
);

export const tagIds = createSelector(
    selectTagState,
    fromTag.selectIds
);

export const tagEntities = createSelector(
    selectTagState,
    fromTag.selectEntities
);

export const tags = createSelector(
    selectTagState,
    fromTag.selectAll
);

export const tagCount = createSelector(
    selectTagState,
    fromTag.selectTotal
);

export const selectedTagId = createSelector(
    selectTagState,
    fromTag.getSelectedId
);

export const selectedTag = createSelector(
    selectTagState,
    (state) => state.entities[state.selectedId]
);
