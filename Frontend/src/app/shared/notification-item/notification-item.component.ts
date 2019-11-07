import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PushNotification } from './../../../server-models/entities/push-notification.model';

@Component({
  selector: 'app-notification-item',
  templateUrl: './notification-item.component.html',
  styleUrls: ['./notification-item.component.scss']
})
export class NotificationItemComponent implements OnInit {

  @Input() model: PushNotification;
  @Output() clickEvent = new EventEmitter<PushNotification>();

  constructor() { }

  ngOnInit() {
  }

}
