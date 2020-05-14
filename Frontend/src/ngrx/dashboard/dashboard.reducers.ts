import { userActivities } from './dashboard.selectors';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import * as _ from 'lodash';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from 'src/server-models/entities/track.model';
import { Activity, UserActivitiesContainer, BasicActivityInfo, BasicUserInfo } from './../../app/features/dashboard/models/activity.model';
import * as DashboardActions from './dashboard.actions';
import { DashboardState, initialDashboardState } from './dashboard.state';
import { act } from '@ngrx/effects';

export const dashboardReducer: ActionReducer<DashboardState, Action> = createReducer(
  initialDashboardState,

  on(DashboardActions.updateTrackItem, (state: DashboardState, payload: { trackItem: TrackItem }) => {
    let tracks = _.cloneDeep(state.tracks);

    for (let track of tracks) {
      let itemIdx = track.items.findIndex(item => item.id == payload.trackItem.id);
      if (itemIdx !== -1) {
        let trackItem = track.items[itemIdx];
        trackItem.jsonParams = payload.trackItem.jsonParams;
      }
    }

    return {
      ...state,
      tracks: tracks
    }
  }),

  on(DashboardActions.trackItemUpdated, (state: DashboardState, payload: { trackItem: TrackItem }) => {

    let tracks = _.cloneDeep(state.tracks);

    for (let track of tracks) {
      let itemIdx = track.items.findIndex(item => item.id == payload.trackItem.id);

      if (itemIdx !== -1)
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
  on(DashboardActions.setDashboardActive, (state: DashboardState, payload: { active: boolean }) => {
    return {
      ...state,
      dashboardActive: payload.active
    }
  }),
  on(DashboardActions.setDashboardUpdated, (state: DashboardState, payload: { updated: boolean }) => {
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

    let extendedActivities = payload.activities.map(activity => {
      return Object.assign({}, activity, { entity: JSON.parse(activity.activityInfo.jsonEntity) });
    });

    return {
      ...state,
      activities: [...extendedActivities]
    }
  }),
  on(DashboardActions.groupedActivitiesFetched, (state: DashboardState, payload: { userActivities: UserActivitiesContainer[] }) => {

    let userActivitiesArr = [];
    payload.userActivities.forEach(ua => {

      let extendedActivities = ua.activities.map(activity => {
        return Object.assign({}, activity, { entity: JSON.parse(activity.jsonEntity) });
      });

      let userActivities = Object.assign({}, ua, { activities: extendedActivities })
      userActivitiesArr.push(userActivities);
    });

    return {
      ...state,
      userActivities: [...userActivitiesArr]
    }
  }),
  on(DashboardActions.pushActivity, (state: DashboardState, payload: { activity: Activity }) => {
    let extendedActivity = Object.assign({}, payload.activity, { entity: JSON.parse(payload.activity.activityInfo.jsonEntity) });
    return {
      ...state,
      activities: [extendedActivity, ...state.activities]
    }
  }),
  on(DashboardActions.pushActivity, (state: DashboardState, payload: { activity: Activity }) => {

    let entity = JSON.parse(payload.activity.activityInfo.jsonEntity);

    let newActivity = new Activity();
    newActivity.userInfo = Object.assign(new BasicUserInfo(), payload.activity.userInfo);
    newActivity.activityInfo = Object.assign(new BasicActivityInfo(), payload.activity.activityInfo, entity);

    var clonedUserActivities = _.cloneDeep(state.userActivities);

    let userId = payload.activity.userInfo.userId;
    let userActivitiesIdx = clonedUserActivities.findIndex(x => x.userId == userId)
    let activities = [newActivity.activityInfo, ...clonedUserActivities[userActivitiesIdx].activities]
    clonedUserActivities[userActivitiesIdx].activities = activities;

    return {
      ...state,
      activities: [newActivity, ...state.activities],
      userActivities: [...clonedUserActivities]
    }
  }),
  on(DashboardActions.activitySeen, (state: DashboardState, payload: { userId: string, activityId: string }) => {

    let userActivitiesIdx = state.userActivities.findIndex(x => x.userId == payload.userId);
    var userActivities = _.cloneDeep(state.userActivities[userActivitiesIdx]);

    let activityIdx = userActivities.activities.findIndex(x => x.id == payload.activityId);
    userActivities.activities[activityIdx].seen = true;
    userActivities.unseenActivities -= 1;

    return {
      ...state,
      userActivities: state.userActivities.map(x => x.userId == userActivities.userId ? userActivities : x)
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
      if (i.id == payload.item.id) {
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
