import { Component, Input, OnInit } from '@angular/core';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';

@Component({
  selector: 'app-notification-type-icon',
  templateUrl: './notification-type-icon.component.html',
  styleUrls: ['./notification-type-icon.component.scss']
})
export class NotificationTypeIconComponent implements OnInit {

  @Input() notificationType: NotificationType;
  @Input() entity: any;

  constructor() { }

  ngOnInit() {
  }

}
