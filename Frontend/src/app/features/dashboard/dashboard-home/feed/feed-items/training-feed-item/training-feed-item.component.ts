import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { Activity, BasicActivityInfo, BasicUserInfo } from 'src/app/features/dashboard/models/activity.model';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTraining } from 'src/ngrx/training-log/training.actions';

@Component({
  selector: 'app-training-feed-item',
  templateUrl: './training-feed-item.component.html',
})
export class TrainingFeedItemComponent implements OnInit {

  @Input() activity: BasicActivityInfo;
  @Input() user: BasicUserInfo;
  message: string;

  constructor(
    private translateService: TranslateService,
    private router: Router,
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    const params = {
      username: this.user.userName,
    };

    this.message = this.translateService.instant('DASHBOARD.FEED.TRAINING_MESSAGE', params);
  }

  navigate() {
    const queryParams = {
      viewAs: this.activity.entity.applicationUserId,
      trainingId: this.activity.entity.id
    };
  
    this.router.navigate(["/app/training-log/training-details"], { queryParams })
    .then(_ => this.store.dispatch(setSelectedTraining({id: this.activity.entity.id})))
  }
  

}
