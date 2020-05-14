import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Activity, BasicActivityInfo, BasicUserInfo } from 'src/app/features/dashboard/models/activity.model';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-personal-best-feed-item',
  templateUrl: './personal-best-feed-item.component.html',
})
export class PersonalBestFeedItemComponent implements OnInit {


  @Input() activity: BasicActivityInfo;
  @Input() user: BasicUserInfo;
  @Input() unitSystem: UnitSystem;
  message: string;

  constructor(
    private translateService: TranslateService,
  ) { }

  ngOnInit(): void {
    const params = {
      username: this.user.userName,
      value: transformWeight(this.activity.entity.value, this.unitSystem)
    }

    this.message = this.translateService.instant('DASHBOARD.FEED.PERSONAL_BEST_MESSAGE', params);
  }
}
