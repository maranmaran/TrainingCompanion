import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import { AttributesMap, dynamicDirectiveDef } from 'ng-dynamic-component';
import { BehaviorSubject } from 'rxjs';
import { catchError, take } from 'rxjs/operators';
import { MaterialElevationDirective } from 'src/business/directives/elevation.directive';
import { BaseService } from 'src/business/services/base.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { TrackItem } from '../../../../server-models/entities/track-item.model';
import { Track } from '../../../../server-models/entities/track.model';
import { Activity } from '../models/activity.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends BaseService {

  constructor(
    private httpDI: HttpClient,
    private store: Store<AppState>
  ) {
    super(httpDI, 'Dashboard');

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => {
      this._userId = id
    });
  }

  // two tracks supported
  private _defaultState: Track[] = [
    {
      id: Guid.create().toString(),
      items: []
    },
    {
      id: Guid.create().toString(),
      items: []
    }
  ]
  private _userId: string;
  private _trackState = new BehaviorSubject<Track[]>(this._defaultState);


  tracks$ = this._trackState.asObservable();
  trackItemAttributes: AttributesMap = { class: 'dashboard-component' };
  trackItemDirectives = [ dynamicDirectiveDef(MaterialElevationDirective, { raisedElevation: 16 }) ]

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
            tracks = this._defaultState;

          this._trackState.next(tracks)
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
        (tracks: Track[]) => {
          this._trackState.next(tracks)
        },
        err => console.log(err)
      );
  }

  removeItem = (item: TrackItem) => {
    const state = this._trackState.getValue();

    state.forEach(track => {
      track.items.forEach((i, index) => {
        if (i == item) {
          track.items.splice(index, 1);
        }
      })
    });

    this._trackState.next(state);
  }

  // support drag and drop to specific track
  addItem = (item: TrackItem, trackIdx: number) => {
    const state = this._trackState.getValue();

    state[trackIdx].items.push(item);

    this._trackState.next(state);
  }

  getFeed(userId: string) {
    return this.http.get<Activity[]>(this.url + 'GetFeed/' + userId)
      .pipe(catchError(this.handleError));
  }
}
