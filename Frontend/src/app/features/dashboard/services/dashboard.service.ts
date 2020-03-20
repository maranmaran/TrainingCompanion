import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import { catchError } from 'rxjs/operators';
import { BaseService } from 'src/business/services/base.service';
import { activitiesFetched, setDashboardUpdated, tracksFetched } from 'src/ngrx/dashboard/dashboard.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Track } from '../../../../server-models/entities/track.model';
import { Activity } from '../models/activity.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends BaseService {

  constructor(
    private httpDI: HttpClient,
    private store: Store<AppState>,
    // private tracksService: TracksService
  ) {
    super(httpDI, 'Dashboard');
  };

  getFeed(userId: string) {
    return this.http.get<Activity[]>(this.url + 'GetFeed/' + userId)
      .pipe(catchError(this.handleError))
      .subscribe((activities: Activity[]) => this.store.dispatch(activitiesFetched({activities})));
  }

  getUserTracks(userId: string) {
    this.http
      .get<Track[]>(this.url + 'GetMainDashboard/' + userId)
      .pipe(
        catchError(this.handleError)
      ).subscribe(
        (tracks: Track[]) => {

          if (tracks.length > 2)
            throw new Error('You cannot have more than 2 tracks for Main dashboard');

          if (tracks.length == 0)
            tracks = this.getDefaultTracksState();

          this.store.dispatch(tracksFetched({tracks}));
        },
        err => console.log(err)
      );
  }

  saveMainDashboard(userId: string, tracks: Track[]) {
    var request = { userId: userId, tracks: tracks };

    this.http
      .put(this.url + 'SaveMainDashboard/', request)
      .pipe(
        catchError(this.handleError)
      ).subscribe(
        (tracks: Track[]) => {
          this.store.dispatch(setDashboardUpdated({updated: false}));
          this.store.dispatch(tracksFetched({tracks}));
        },
        err => console.log(err),
        () => this.store.dispatch(setDashboardUpdated({updated: false}))
      );
  }

  private getDefaultTracksState(): Track[] {
    return  [
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
