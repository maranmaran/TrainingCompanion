import { UserActivitiesContainer } from './../models/activity.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import { Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from 'src/business/services/base.service';
import { setDashboardUpdated, tracksFetched } from 'src/ngrx/dashboard/dashboard.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from '../../../../server-models/entities/track.model';
import { Activity } from '../models/activity.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends BaseService {

  saveTrackItemParams = new Subject();

  constructor(
    private httpDI: HttpClient,
    private store: Store<AppState>,
    // private tracksService: TracksService
  ) {
    super(httpDI, 'Dashboard');
  };

  getFeed(userId: string) {
    return this.http.get<Activity[]>(this.url + 'GetFeed/' + userId)
      .pipe(catchError(this.handleError));
  }

  getFeedGroupedByUser(userId: string) {
    return this.http.get<UserActivitiesContainer[]>(this.url + 'GetFeedGroupedByUser/' + userId)
      .pipe(catchError(this.handleError));
  }

  activitySeen(activityId: string) {
    return this.http.get(this.url + 'ActivitySeen/' + activityId)
      .pipe(catchError(this.handleError));
  }

  getUserTracks(userId: string) {
    return this.http
      .get<Track[]>(this.url + 'GetMainDashboard/' + userId)
      .pipe(
        catchError(this.handleError)
      )
  }

  updateTrackItem(trackItemId: string, jsonParams: string) {
    return this.http
      .put<TrackItem>(this.url + 'UpdateTrackItem/', { trackItemId, jsonParams })
      .pipe(catchError(this.handleError))
  }

  saveMainDashboard(userId: string, tracks: Track[]) {
    var request = { userId: userId, tracks: tracks };

    this.http
      .put(this.url + 'SaveMainDashboard/', request)
      .pipe(catchError(this.handleError))
      .subscribe(
        (tracks: Track[]) => {
          this.store.dispatch(setDashboardUpdated({ updated: false }));
          this.store.dispatch(tracksFetched({ tracks }));
        },
        err => console.log(err),
        () => this.store.dispatch(setDashboardUpdated({ updated: false }))
      );
  }

  get defaultTracksState(): Track[] {
    return [
      {
        id: Guid.create().toString(),
        items: []
      },
      {
        id: Guid.create().toString(),
        items: []
      }
    ]
  }
}
