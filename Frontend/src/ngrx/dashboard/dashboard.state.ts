import { Activity } from 'src/app/features/dashboard/models/activity.model';
import { Track } from 'src/server-models/entities/track.model';

export interface DashboardState {
  trackEdit: boolean;
  dashboardUpdated: boolean;
  tracks: Track[],
  activities: Activity[],
  dashboardActive: boolean;
}

export const initialDashboardState: DashboardState = {
  trackEdit: false,
  dashboardUpdated: false,
  tracks: [],
  activities: [],
  dashboardActive: false,
};
