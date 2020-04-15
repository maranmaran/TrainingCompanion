import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { unitSystem } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-notification-item',
  templateUrl: './notification-item.component.html',
  styleUrls: ['./notification-item.component.scss']
})
export class NotificationItemComponent implements OnInit {

  @Input() model: PushNotification;
  unitSystem: UnitSystem;
  notificationType = NotificationType;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.store.select(unitSystem).subscribe(system => this.unitSystem = system);
  }


}
