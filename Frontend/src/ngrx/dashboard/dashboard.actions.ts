import { createAction, props } from '@ngrx/store';
import { Activity, UserActivitiesContainer } from './../../app/features/dashboard/models/activity.model';
import { TrackItem } from './../../server-models/entities/track-item.model';
import { Track } from './../../server-models/entities/track.model';

export const setTrackEditMode = createAction('[Dashboard] Track edit');
export const setDashboardUpdated = createAction('[Dashboard] Updated', props<{ updated: boolean }>());

export const tracksFetched = createAction('[Dashboard] Tracks fetched', props<{ tracks: Track[] }>());
export const activitiesFetched = createAction('[Dashboard] Activities fetched', props<{ activities: Activity[] }>());
export const groupedActivitiesFetched = createAction('[Dashboard] Grouped activities fetched', props<{ userActivities: UserActivitiesContainer[] }>());

export const pushActivity = createAction('[Dashboard] Push activity', props<{ activity: Activity }>());
export const activitySeen = createAction('[Dashboard] Activity seen', props<{ userId: string, activityId: string }>());

export const addTrackItem = createAction('[Dashboard] Add track item', props<{ item: TrackItem, idx: number }>())
export const removeTrackItem = createAction('[Dashboard] Remove track item', props<{ item: TrackItem, idx: number }>())
export const saveDashboard = createAction('[Dashboard] Save', props<{ tracks: Track[] }>());

export const updateTrackItem = createAction('[Dashboard] Update track item', props<{ trackItem: TrackItem }>());
export const trackItemUpdated = createAction('[Dashboard] Track item updated', props<{ trackItem: TrackItem }>());
export const setDashboardActive = createAction('[Dashboard] Active', props<{ active: boolean }>());
