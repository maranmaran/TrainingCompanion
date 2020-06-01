import { createFeatureSelector, createSelector } from '@ngrx/store';
import { DashboardState } from './dashboard.state';

export const selectDashboardState = createFeatureSelector<DashboardState>('dashboard');

export const trackEditMode = createSelector(
  selectDashboardState,
  (dashboardState: DashboardState) => dashboardState.trackEdit
)

export const dashboardUpdated = createSelector(
  selectDashboardState,
  (dashboardState: DashboardState) => dashboardState.dashboardUpdated
)

export const tracks = createSelector(
  selectDashboardState,
  (dashboardState: DashboardState) => dashboardState.tracks
)


export const userActivities = createSelector(
  selectDashboardState,
  (dashboardState: DashboardState) => dashboardState.userActivities
)
export const dashboardActive = createSelector(
  selectDashboardState,
  (dashboardState: DashboardState) => dashboardState?.dashboardActive
)
