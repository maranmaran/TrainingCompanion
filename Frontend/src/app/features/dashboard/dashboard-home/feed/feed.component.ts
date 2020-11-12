import { AfterViewInit, Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { DashboardService } from 'src/app/features/dashboard/services/dashboard.service';
import { userSetting } from 'src/ngrx/auth/auth.selectors';
import { activitySeen } from 'src/ngrx/dashboard/dashboard.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { Activity } from '../../models/activity.model';
import { userActivities } from './../../../../../ngrx/dashboard/dashboard.selectors';
import { ActivityType, BasicActivityInfo, UserActivitiesContainer } from './../../models/activity.model';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
})
export class FeedComponent implements OnInit, AfterViewInit {

  userActivities: Observable<UserActivitiesContainer[]>;
  unitSystem: Observable<UnitSystem>;
  activityType = ActivityType;

  constructor(
    private store: Store<AppState>,
    private sanitizer: DomSanitizer,
    private dashboardService: DashboardService
  ) { }

  ngOnInit(): void {
    this.userActivities = this.store.select(userActivities)
    this.unitSystem = this.store.select(userSetting).pipe(map(setting => setting.unitSystem));
  }

  // Workaround - https://github.com/angular/components/issues/13870
  // tslint:disable-next-line: member-ordering
  disableAnimation = true;
  ngAfterViewInit(): void {
    // timeout required to avoid the dreaded 'ExpressionChangedAfterItHasBeenCheckedError'
    setTimeout(() => this.disableAnimation = false);
  }


  getEntity(activity: Activity) {
    console.log(activity);
  }

  markSeen(userId: string, activity: BasicActivityInfo) {
    if (activity.seen) return; // if already seen ok

    // if not seen.. mark it as seen now
    this.dashboardService.activitySeen(userId, activity.id)
      .pipe(take(1))
      .subscribe(
        _ => {
          this.store.dispatch(activitySeen({ userId, activityId: activity.id }))
        },
        err => console.log(err)
      )
  }

  trackActivityId = (activity: BasicActivityInfo) => activity.id
  trackUserId = (container: UserActivitiesContainer) => container.userId

}
