import { SubusersState } from './subuser.state';
import { createSelector, createFeatureSelector } from '@ngrx/store';

export const selectSubusersState = createFeatureSelector<SubusersState>("subusers");

export const subusers = createSelector(
    selectSubusersState,
    (subusersState: SubusersState) => subusersState.subusers
)
