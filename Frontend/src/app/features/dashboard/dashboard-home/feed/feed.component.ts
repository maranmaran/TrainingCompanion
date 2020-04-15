import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { Activity } from '../../models/activity.model';
import { activities } from './../../../../../ngrx/dashboard/dashboard.selectors';
import { ActivityType } from './../../models/activity.model';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
})
export class FeedComponent implements OnInit {

  activities: Observable<Activity[]>;
  unitSystem: Observable<UnitSystem>;
  activityType = ActivityType;

  constructor(
    private store: Store<AppState>,
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    this.activities = this.store.select(activities)
    this.unitSystem = this.store.select(userSetting).pipe(map(setting => setting.unitSystem));
  }

  getEntity(activity: Activity) {
    console.log(activity);
  }

}
