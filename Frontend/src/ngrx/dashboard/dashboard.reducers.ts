import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import * as _ from 'lodash';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from 'src/server-models/entities/track.model';
import { Activity, UserActivitiesContainer } from './../../app/features/dashboard/models/activity.model';
import * as DashboardActions from './dashboard.actions';
import { DashboardState, initialDashboardState } from './dashboard.state';

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

  on(DashboardActions.activitiesFetched, (state: DashboardState, payload: { userActivities: UserActivitiesContainer[] }) => {

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
    let activityInfo = _.cloneDeep(payload.activity.activityInfo);
    let userInfo = _.cloneDeep(payload.activity.userInfo);

    // parse json entity
    let entity = JSON.parse(activityInfo.jsonEntity);
    activityInfo.entity = entity;

    // get user activity groups if none exists create new else find and map
    var clonedUserActivities = _.cloneDeep(state.userActivities);
    if (clonedUserActivities.length == 0) {
      let newUserActivityContainer = new UserActivitiesContainer();
      newUserActivityContainer.userId = userInfo.userId;
      newUserActivityContainer.userName = userInfo.userName;
      newUserActivityContainer.userAvatar = userInfo.userAvatar;
      newUserActivityContainer.activities = [activityInfo];
      newUserActivityContainer.unseenActivities = 1;

      clonedUserActivities = [newUserActivityContainer]
    } else {
      let userId = userInfo.userId;
      let userActivitiesIdx = clonedUserActivities.findIndex(x => x.userId == userId)

      let activities = [activityInfo, ...clonedUserActivities[userActivitiesIdx].activities]
      clonedUserActivities[userActivitiesIdx].activities = activities;
      clonedUserActivities[userActivitiesIdx].unseenActivities += 1;
    }


    return {
      ...state,
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
