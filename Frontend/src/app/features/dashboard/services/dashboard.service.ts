import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Store } from '@ngrx/store';
import { catchError, take } from 'rxjs/operators';
import { BaseService } from 'src/business/services/base.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Track } from '../../../../server-models/entities/track.model';
import { Activity } from '../models/activity.model';
import { TracksService } from './tracks.service';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends BaseService {

  constructor(
    private httpDI: HttpClient,
    private store: Store<AppState>,
    private tracksService: TracksService
  ) {
    super(httpDI, 'Dashboard');
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => {
      this._userId = id
    });
  };

  private _userId: string;

  getFeed(userId: string) {
    return this.http.get<Activity[]>(this.url + 'GetFeed/' + userId)
      .pipe(catchError(this.handleError));
  }

  getUserTracks() {
    this.http
      .get<Track[]>(this.url + 'GetMainDashboard/' + this._userId)
      .pipe(
        catchError(this.handleError)
      ).subscribe(
        (tracks: Track[]) => {

          if (tracks.length > 2)
            console.error('You cannot have more than 2 tracks for Main dashboard');

          if (tracks.length == 0)
            tracks = this.tracksService.defaultState;

          this.tracksService.setState(tracks);
        },
        err => console.log(err)
      );
  }

  saveMainDashboard(tracks: Track[]) {
    var request = { userId: this._userId, tracks: tracks };

    this.http
      .post(this.url + 'SaveMainDashboard/', request)
      .pipe(
        catchError(this.handleError)
      ).subscribe(
        (tracks: Track[]) => this.tracksService.setState(tracks),
        err => console.log(err)
      );
  }
}
