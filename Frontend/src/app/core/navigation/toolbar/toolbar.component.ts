import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { currentUser } from './../../../../ngrx/auth/auth.selectors';
import { PushNotification } from './../../../../server-models/entities/push-notification.model';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit, OnDestroy {

  constructor(
    private notificationService: NotificationSignalrService,
    private store: Store<AppState>
  ) { }

  @Input() fullName: string;
  @Input() loading$: Observable<boolean>;
  @Output() openSettingsEvent = new EventEmitter<string>();
  @Output() toggleSidenavEvent = new EventEmitter<void>();
  @Output() logoutEvent = new EventEmitter<void>();

  avatar: string; // url

  private subSink = new SubSink();
  private page = 0;
  pageSize = 10; // TODO: AppSettings -> NotificationsPageSize
  unreadNotificationCounter = 0;
  notifications: PushNotification[] = [];
  items = Array.from({ length: 100 }).map((_, i) => `Item #${i}`);

  stopFetch = false;

  ngOnInit(): void {

    // subscribe to notifications
    // only new ones.. in real time
    // this.notifications$ = this.notificationService.notifications$;
    this.subSink.add(
      this.store.select(currentUser).pipe(map(x => x.avatar)).subscribe(avatar => this.avatar = avatar),
      this.notificationService.notifications$.subscribe(
        (notification: PushNotification) => {

          this.notifications = [notification, ...this.notifications];
          !notification.read && this.unreadNotificationCounter++;

          // do stuff... Display some toastr or something for new notifications while user is logged in
        },
        err => console.log(err)
      )
    );

    this.getHistory(this.page++, this.pageSize);

  }

  ngOnDestroy(): void {
    this.subSink.unsubscribe();
  }

  // BUG with mat menu integration https://github.com/angular/components/issues/10122
  // loadMoreNotifications(index: number) {
  //   console.log(index);
  //   index += 7;

  //   if (index === this.notifications.length && !this.stopFetch) {
  //     this.getHistory(this.page++, this.pageSize);
  //   }
  // }

  loadMoreNotifications() {
    this.getHistory(this.page++, this.pageSize);
  }

  getHistory(page, pageSize) {

    if (!this.stopFetch) {
      this.notificationService.getHistory(page, pageSize)
        .pipe(take(1))
        .subscribe(notifications => {

          if (!notifications || notifications.length == 0) {
            return this.stopFetch = true;
          }

          notifications.forEach(n => !n.read && this.unreadNotificationCounter++);
          this.notifications = [...this.notifications, ...notifications];

        });
    }
  }

  // TODO: Route probably
  onClickNotification(notification: PushNotification) {
    console.log('click');
    return;
  }

  // TODO: Update notification
  onHoverNotification(notification: PushNotification) {
    notification.read = true;
    this.unreadNotificationCounter--;
    this.notificationService.readNotification(notification.id);
    return;
  }
}
