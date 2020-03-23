import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take, catchError } from 'rxjs/operators';
import { bodyweights } from 'src/ngrx/bodyweight/bodyweight.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { BodyweightService } from '../services/feature-services/bodyweight.service';
import { isEmpty } from '../utils/utils';
import { bodyweightFetched } from './../../ngrx/bodyweight/bodyweight.actions';
import { Activity } from 'src/app/features/dashboard/models/activity.model';
import { DashboardService } from 'src/app/features/dashboard/services/dashboard.service';
import { activities } from 'src/ngrx/dashboard/dashboard.selectors';
import { activitiesFetched } from 'src/ngrx/dashboard/dashboard.actions';

@Injectable()
export class FeedResolver implements Resolve<Observable<Activity[] | void>> {

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
      .select(activities)
      .pipe(
        take(1),
        concatMap((activities: Activity[]) => {

          if (isEmpty(activities)) {
            return this.updateState(userId);
          }

          return of(activities);
        }));
  }

  private updateState(userId: string) {

    return this.dashboardService.getFeed(userId)
    .pipe(
        take(1),
        map((entities: Activity[]) => this.store.dispatch(activitiesFetched({activities: entities})))
    )
  }
}
