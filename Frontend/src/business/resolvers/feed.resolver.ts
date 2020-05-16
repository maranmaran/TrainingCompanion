import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { DashboardService } from 'src/app/features/dashboard/services/dashboard.service';
import { activitiesFetched } from 'src/ngrx/dashboard/dashboard.actions';
import { userActivities } from 'src/ngrx/dashboard/dashboard.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { isEmpty } from '../utils/utils';
import { UserActivitiesContainer } from './../../app/features/dashboard/models/activity.model';

@Injectable()
export class FeedResolver implements Resolve<Observable<UserActivitiesContainer[] | void>> {

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
      .select(userActivities)
      .pipe(
        take(1),
        concatMap((userActivities: UserActivitiesContainer[]) => {

          if (isEmpty(userActivities)) {
            return this.updateState(userId);
          }

          return of(userActivities);
        }));
  }

  private updateState(userId: string) {

    // return this.dashboardService.getFeed(userId)
    return this.dashboardService.getFeedGroupedByUser(userId)
      .pipe(
        take(1),
        map((entities: UserActivitiesContainer[]) => this.store.dispatch(activitiesFetched({ userActivities: entities })))
      )
  }
}
