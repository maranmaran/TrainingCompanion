import { tracks } from './../../ngrx/dashboard/dashboard.selectors';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { Track } from 'src/server-models/entities/Track.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { isEmpty } from '../utils/utils';
import { DashboardService } from 'src/app/features/dashboard/services/dashboard.service';
import { tracksFetched } from 'src/ngrx/dashboard/dashboard.actions';

@Injectable()
export class TracksResolver implements Resolve<Observable<Track[] | void>> {

    constructor(
        private dashboardService: DashboardService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return this.store.select(currentUser)
            .pipe(
                take(1),
                map((user: CurrentUser) => user.id),
                concatMap((userId: string) => {
                    return this.getState(userId);
                }));
    }

    private getState(userId: string) {

        return this.store
            .select(tracks)
            .pipe(
                take(1),
                concatMap((Tracks: Track[]) => {

                    if (isEmpty(Tracks)) {
                        return this.updateState(userId);
                    }

                    return of(Tracks);
                }));
    }

    private updateState(userId: string) {

        return this.dashboardService.getUserTracks(userId)
            .pipe(
                take(1),
                map((tracks: Track[]) => {
                    if (tracks.length > 2)
                        throw new Error('You cannot have more than 2 tracks for Main dashboard');

                    if (tracks.length == 0)
                        tracks = this.dashboardService.defaultTracksState;

                    this.store.dispatch(tracksFetched({ tracks }));
                }))
    }
}
