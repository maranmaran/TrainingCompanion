import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import * as _ from 'lodash';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from 'src/server-models/entities/track.model';
import { Activity } from './../../app/features/dashboard/models/activity.model';
import * as DashboardActions from './dashboard.actions';
import { DashboardState, initialDashboardState } from './dashboard.state';

export const dashboardReducer: ActionReducer<DashboardState, Action> = createReducer(
  initialDashboardState,

  on(DashboardActions.updateTrackItem, (state: DashboardState, payload: {trackItem: TrackItem}) => {
    let tracks = _.cloneDeep(state.tracks);

    for(let track of tracks) {
      let itemIdx = track.items.findIndex(item => item.id == payload.trackItem.id);
      if(itemIdx !== -1) {
        let trackItem = track.items[itemIdx];
        trackItem.jsonParams = payload.trackItem.jsonParams;
      }
    }

    return {
        ...state,
        tracks: tracks
    }
  }),

  on(DashboardActions.trackItemUpdated, (state: DashboardState, payload: { trackItem: TrackItem}) => {

    let tracks = _.cloneDeep(state.tracks);

    for(let track of tracks) {
      let itemIdx = track.items.findIndex(item => item.id == payload.trackItem.id);

      if(itemIdx !== -1)
        track.items[itemIdx] = payload.trackItem;
    }

    return {
        ...state,
        tracks: tracks
    }
  }),
  on(DashboardActions.setTrackEditMode, (state: DashboardState) => {
      return {
          ...state,
          trackEdit: !state.trackEdit
      }
  }),
  on(DashboardActions.setDashboardUpdated, (state: DashboardState, payload: {updated: boolean}) => {
      return {
          ...state,
          dashboardUpdated: payload.updated
      }
  }),
  on(DashboardActions.tracksFetched, (state: DashboardState, payload: { tracks: Track[] }) => {
      return {
          ...state,
          tracks: [...payload.tracks]
      }
  }),
  on(DashboardActions.activitiesFetched, (state: DashboardState, payload: { activities: Activity[] }) => {
      return {
          ...state,
          activities: [...payload.activities]
      }
  }),
  on(DashboardActions.pushActivity, (state: DashboardState, payload: { activity: Activity }) => {
      return {
          ...state,
          activities: [payload.activity, ...state.activities]
      }
  }),
  on(DashboardActions.addTrackItem, (state: DashboardState, payload: { item: TrackItem, idx: number }) => {
    let tracks = _.cloneDeep(state.tracks);
    tracks[payload.idx].items.push(payload.item);

    return {
          ...state,
          tracks: [...tracks],
          dashboardUpdated: true
      }
  }),
  on(DashboardActions.removeTrackItem, (state: DashboardState, payload: { item: TrackItem, idx: number }) => {
    let tracks = _.cloneDeep(state.tracks);

    tracks[payload.idx].items.forEach((i, index) => {
      if (i == payload.item) {
        tracks[payload.idx].items.splice(index, 1);
      }
    });

    return {
          ...state,
          tracks: [...tracks],
          dashboardUpdated: true
      }
  }),
)
