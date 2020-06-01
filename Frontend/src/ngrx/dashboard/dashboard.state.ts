import { Track } from 'src/server-models/entities/track.model';
import { UserActivitiesContainer } from './../../app/features/dashboard/models/activity.model';

export interface DashboardState {
  trackEdit: boolean;
  dashboardUpdated: boolean;
  tracks: Track[],
  dashboardActive: boolean;
  userActivities: UserActivitiesContainer[]
}

export const initialDashboardState: DashboardState = {
  trackEdit: false,
  dashboardUpdated: false,
  tracks: [],
  dashboardActive: false,
  userActivities: []
};
