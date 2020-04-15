import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-bodyweight-notification-body',
  template: '<p>{{message}}</p>',
})
export class BodyweightNotificationBodyComponent implements OnInit {

  @Input() notification: PushNotification;
  @Input() unitSystem: UnitSystem;

  message: string;

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    const params = {
      value: transformWeight(this.notification.entity.Value, this.unitSystem)
    }

    this.message = this.translateService.instant('NOTIFICATIONS.BODYWEIGHT_MESSAGE', params);
  }

}