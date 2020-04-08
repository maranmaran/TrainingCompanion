import { createAction, props } from '@ngrx/store';
import { Activity } from './../../app/features/dashboard/models/activity.model';
import { TrackItem } from './../../server-models/entities/track-item.model';
import { Track } from './../../server-models/entities/track.model';

export const setTrackEditMode = createAction('[Dashboard] Track edit');
export const setDashboardUpdated = createAction('[Dashboard] Updated', props<{ updated: boolean}>());

export const tracksFetched = createAction('[Dashboard] Tracks fetched', props<{tracks: Track[]}>());
export const activitiesFetched = createAction('[Dashboard] Activities fetched', props<{activities: Activity[]}>());

export const pushActivity = createAction('[Dashboard] Push activity', props<{activity: Activity}>());

export const addTrackItem = createAction('[Dashboard] Add track item', props<{item: TrackItem, idx: number}>())
export const removeTrackItem = createAction('[Dashboard] Remove track item', props<{item: TrackItem, idx: number}>())
export const saveDashboard = createAction('[Dashboard] Save', props<{tracks: Track[]}>());

export const updateTrackItemParams = createAction('[Dashboard] Update track item params', props<{trackItemId: string, jsonParams: string}>());
export const trackItemParamsUpdated = createAction('[Dashboard] Track item params updated', props<{ trackItemId: string, jsonParams: string}>());
