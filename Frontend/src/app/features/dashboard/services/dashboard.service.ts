import { Injectable, OnInit } from "@angular/core";
import { Track } from '../models/track.interface';
import { DashboardCards } from '../models/dashboard-cards';
import { BehaviorSubject } from 'rxjs';
import { BaseService } from 'src/business/services/base.service';
import { HttpClient } from '@angular/common/http';
import { catchError, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/app/app.state';
import { Store } from '@ngrx/store';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { DashboardItem } from '../models/dashboard-item.interface';

@Injectable({
    providedIn: 'root'
})
export class DashboardService extends BaseService implements OnInit {

    constructor(
        private httpDI: HttpClient,
        private store: Store<AppState>
    ) {
        super(httpDI, 'Dashboard');
    }

    // two tracks supported
    private _defaultState: Track[] = [
        {
            items: [
                {
                    component: DashboardCards.Test,
                    id: 'test'
                }
            ]
        },
        {
            items: [
                {
                    component: DashboardCards.Test,
                    id: 'test'
                }
            ]
        }
    ]

    private _userId: string;
    private _trackState = new BehaviorSubject<Track[]>(this._defaultState);
    tracks$ = this._trackState.asObservable();

    ngOnInit() {
        this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);
    }

    public getUserTracks() {
        this.http
            .get<Track[]>(this.url + 'GetMainDashboard/' + this._userId)
            .pipe(
                catchError(this.handleError)
            ).subscribe(
                (tracks: Track[]) => this._trackState.next(tracks),
                err => {
                    console.log(err);
                    this._trackState.next(this._defaultState); //fallback
                }
            );
    }

    public saveMainDashboard(tracks: Track[]) {
        var request = { userId: this._userId, tracks: tracks };

        this.http
            .post(this.url + 'SaveMainDashboard/', request)
            .pipe(
                catchError(this.handleError)
            ).subscribe(
                () => {},
                err => console.log(err)
            );
    }

    public removeItem = (item: DashboardItem) => {
        const state = this._trackState.getValue();
        
        state.forEach(track => {
            track.items.forEach((i, index) => {
                if(i == item) {
                    track.items.splice(index, 1);
                }
            })
        });

        this._trackState.next(state);
    }

    // support drag and drop to specific track
    public addItem = (item: DashboardItem) => {
        const state = this._trackState.getValue();

        // check if tracks already contain this component
        if(state[0].items.indexOf(item) !== -1 || state[1].items.indexOf(item) !== -1) {
            console.warn('Item with the same id exists on the dashboard.');
            return;
        }

        state[0].items.length <= state[1].items.length ? state[0].items.push(item) : state[1].items.push(item);

        this._trackState.next(state);
    }

}