import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { BasicUserInfo } from 'src/app/features/dashboard/models/activity.model';

@Component({
  selector: 'app-import-notification-body',
  template: `<span *ngIf="showSender" [innerHtml]="message"></span>`,
})
export class ImportNotificationBodyComponent implements OnInit {

  @Input() notification: PushNotification;
  @Input() unitSystem: UnitSystem;

  message: string;
  showSender: boolean;

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    this.showSender = !this.notification.systemNotification;

    if (this.notification.entity.Success) {
      this.message = this.translateService.instant('NOTIFICATIONS.IMPORT_MESSAGE_SUCCESS');
    } else {
      this.message = this.translateService.instant('NOTIFICATIONS.IMPORT_MESSAGE_FAILURE');
    }
  }

}
