import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { SubSink } from 'subsink';
import { PushNotification } from './../../../../server-models/entities/push-notification.model';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit, OnDestroy {

  constructor(
    private notificationService: NotificationSignalrService,
  ) {

  }

  @Input() fullName: string;
  @Input() loading$: Observable<boolean>;
  @Output() openSettingsEvent = new EventEmitter<string>();
  @Output() toggleSidenavEvent = new EventEmitter<void>();
  @Output() logoutEvent = new EventEmitter<void>();

  private subSink = new SubSink();
  private page = 0;
  protected pageSize = 10; // TODO: AppSettings -> NotificationsPageSize
  protected unreadNotificationCounter = 0;
  protected notifications: PushNotification[] = [];
  protected items = Array.from({ length: 100 }).map((_, i) => `Item #${i}`);

  stopFetch = false;

  ngOnInit(): void {

    // subscribe to notifications
    // this.notifications$ = this.notificationService.notifications$;
    this.subSink.add(
      this.notificationService.notifications$.subscribe(
        (notification: PushNotification) => {

          this.notifications = [...this.notifications, notification];
          !notification.read && this.unreadNotificationCounter++;

          //do stuff... Display some toastr or something
        },
        err => console.log(err)
      )
    );

    this.getHistory(this.page, this.pageSize);

  }

  ngOnDestroy(): void {
    this.subSink.unsubscribe();
  }

  loadMoreNotifications(index: number) {
    console.log(index);
    index += 7;

    if (index === this.notifications.length && !this.stopFetch) {
      this.getHistory(this.page++, this.pageSize);
    }
  }

  getHistory(page, pageSize) {

    this.notificationService.getHistory(page, pageSize)
      .pipe(take(1))
      .subscribe(notifications => {
        if (notifications.length == 0) {
          return this.stopFetch = true;
        }

        notifications.forEach(item => {
          this.notificationService.notifications$.next(item);
        });
      });
  }

  notificationClicked(notification: PushNotification) {

  }
}
