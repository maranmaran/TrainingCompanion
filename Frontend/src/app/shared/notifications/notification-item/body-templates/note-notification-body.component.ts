import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-note-notification-body',
  template: '<p>{{message}}</p>',
})
export class NoteNotificationBodyComponent implements OnInit {
  @Input() notification: PushNotification;
  @Input() unitSystem: UnitSystem;

  message: string;

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
    const params = {
    }

    this.message = this.translateService.instant('NOTIFICATIONS.NOTE_MESSAGE', params);
  }

}
