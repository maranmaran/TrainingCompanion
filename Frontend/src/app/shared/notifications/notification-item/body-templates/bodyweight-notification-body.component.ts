import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { BasicUserInfo } from 'src/app/features/dashboard/models/activity.model';

@Component({
  selector: 'app-bodyweight-notification-body',
  template: `<span *ngIf="showSender" [innerHtml]="message"></span>`,
})
export class BodyweightNotificationBodyComponent implements OnInit {

  @Input() notification: PushNotification;
  @Input() unitSystem: UnitSystem;

  message: string;
  showSender: boolean;

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    this.showSender = !this.notification.systemNotification;

    const params = {
      username: this.notification.sender.fullName,
      value: transformWeight(this.notification.entity.value, this.unitSystem)
    }

    this.message = this.translateService.instant('NOTIFICATIONS.BODYWEIGHT_MESSAGE', params);
  }

}
