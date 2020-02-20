import { Component, Input, OnInit } from '@angular/core';
import { PushNotification } from 'src/server-models/entities/push-notification.model';

@Component({
  selector: 'app-notification-item',
  templateUrl: './notification-item.component.html',
  styleUrls: ['./notification-item.component.scss']
})
export class NotificationItemComponent implements OnInit {

  @Input() model: PushNotification;

  constructor() { }

  ngOnInit() {
  }


}
