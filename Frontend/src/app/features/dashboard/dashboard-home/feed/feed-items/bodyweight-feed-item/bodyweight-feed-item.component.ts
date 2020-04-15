import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Activity } from 'src/app/features/dashboard/models/activity.model';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-bodyweight-feed-item',
  templateUrl: './bodyweight-feed-item.component.html',
})
export class BodyweightFeedItemComponent implements OnInit {

  @Input() activity: Activity;
  @Input() unitSystem: UnitSystem;
  message: string;

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    const params = {
      username: this.activity.userName,
      value: transformWeight(this.activity.entity.Value, this.unitSystem)
    }

    this.message = this.translateService.instant('DASHBOARD.FEED.BODYWEIGHT_MESSAGE', params);
  }

}
