import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromType from './tag-group.reducers';
import { TagGroupState } from './tag-group.state';


export const selectTagGroupState = createFeatureSelector<TagGroupState>("tagGroup");

export const tagGroupIds = createSelector(
    selectTagGroupState,
    fromType.selectTypeIds
);

export const tagGroupEntities = createSelector(
    selectTagGroupState,
    fromType.selectTypeEntities
);

export const allTagGroups = createSelector(
    selectTagGroupState,
    fromType.selectAllTypes
);

export const tagGroupCount = createSelector(
    selectTagGroupState,
    fromType.selectTypeTotal
);

export const selectedTagGroupId = createSelector(
    selectTagGroupState,
    fromType.getSelectedTypeId
);
export const selectedTagId = createSelector(
    selectTagGroupState,
    fromType.getSelectedPropertyId
);

export const selectedTagGroup = createSelector(
    selectTagGroupState,
    (state) => state.entities[state.selectedTypeId]
);
export const selectedTag = createSelector(
    selectTagGroupState,
    (state) => {

        var type = (state.entities[state.selectedTypeId]);

        if (type) {
            return type.tags.filter(x => x.id == state.selectedPropertyId)[0]; // not normalized
        }

        return null;
    }
);
