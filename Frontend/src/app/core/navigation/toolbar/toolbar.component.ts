import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit, OnDestroy {

  @Input() fullName: string;
  @Input() loading$: Observable<boolean>;
  @Output() openSettingsEvent = new EventEmitter<string>();
  @Output() toggleSidenavEvent = new EventEmitter<void>();
  @Output() logoutEvent = new EventEmitter<void>();

  protected unreadNotificationCounter = 0;
  private notifications$: Observable<PushNotification>;
  private subSink = new SubSink();

  constructor(
    private notificationService: NotificationSignalrService,
  ) {

  }

  ngOnInit(): void {
    this.notifications$ = this.notificationService.notifications$;
    this.subSink.add(
      this.notifications$.subscribe(
        (notification: PushNotification) => {
          this.unreadNotificationCounter++;
          //do stuff... Display some toastr or something
        },
        err => console.log(err)
      )
    )
  }

  onOpenNotificationsWindow() {

  }

  ngOnDestroy(): void {
    this.subSink.unsubscribe();
  }
}
