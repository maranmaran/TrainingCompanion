import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Activity } from 'src/app/features/dashboard/models/activity.model';

@Component({
  selector: 'app-training-feed-item',
  templateUrl: './training-feed-item.component.html',
})
export class TrainingFeedItemComponent implements OnInit {

  @Input() activity: Activity;
  message: string;

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    const params = {
      username: this.activity.userName,
    };

    this.message = this.translateService.instant('DASHBOARD.FEED.TRAINING_MESSAGE', params);
  }
}
