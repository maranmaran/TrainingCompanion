import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-import-notification-body',
  template: '<p>{{message}}</p>',
})
export class ImportNotificationBodyComponent implements OnInit {

  @Input() notification: PushNotification;
  @Input() unitSystem: UnitSystem;

  message: string;

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    const params = {

    }

    if(this.notification.entity.Success) {
      this.message = this.translateService.instant('NOTIFICATIONS.IMPORT_MESSAGE_SUCCESS', params);
    } else {
      this.message = this.translateService.instant('NOTIFICATIONS.IMPORT_MESSAGE_FAILURE', params);
    }
  }

}
