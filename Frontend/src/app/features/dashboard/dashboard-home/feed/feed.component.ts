import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Activity } from '../../models/activity.model';
import { activities } from './../../../../../ngrx/dashboard/dashboard.selectors';
import { DashboardService } from './../../services/dashboard.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent implements OnInit {

  activities: Observable<Activity[]>;

  constructor(
    private store: Store<AppState>,
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    this.activities = this.store.select(activities)
  }

  getEntity(activity: Activity) {
    console.log(activity);
  }

}
