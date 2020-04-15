import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-personal-best-notification-body',
  template: '<p>{{message}}</p>',
})
export class PersonalBestNotificationBodyComponent implements OnInit {
  @Input() notification: PushNotification;
  @Input() unitSystem: UnitSystem;

  message: string;

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    console.log(this.notification);

    const params = {
      value: transformWeight(this.notification.entity.Value, this.unitSystem)
    }

    this.message = this.translateService.instant('NOTIFICATIONS.PERSONAL_BEST_MESSAGE', params);
  }

}