import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { SubSink } from 'subsink';
import { AppSettingsService } from '../shared/app-settings.service';
import { NotificationType } from './../../../server-models/enums/notification-type.enum';
import { AuthService } from './auth.service';

@Injectable()
export class NotificationSignalrService implements OnDestroy {

  public notifications$ = new Subject<PushNotification>();

  hubConnection: signalR.HubConnection;
  subs = new SubSink();

  constructor(
    private authService: AuthService,
    private store: Store<AppState>,
    private http: HttpClient,
    private appSettingsService: AppSettingsService,
    private toastService: ToastrService
  ) {
    // subscribe to logout
    this.subs.add(
      this.authService.signOutEvent.subscribe(() => this.stopConnection())
    );

    // configure connection
    this.configureHubConnection();
  }

  configureHubConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.appSettingsService.notificationHubUrl)
      // { accessTokenFactory: () => this.authService.getToken() })
      .build();

    this.hubConnection.serverTimeoutInMilliseconds = 100000; // 100 sec
    this.hubConnection.start()
    .then(() => this.initializeListeners())
    .catch(err => console.log(`Error while starting SignalR connection: ${err}`));
  }

  initializeListeners() {
    this.hubConnection.on('SendNotification', (notification: PushNotification) => {
      notification = this.doWork(notification);
      this.notifications$.next(notification);
      this.toastService.show(JSON.stringify(notification), 'Notification')
    });
  }

  // do some specific work based on the received notification type
  doWork(notification: PushNotification) {
    notification.entity = JSON.parse(notification.jsonEntity);
    // switch(notification.type) {
    // }
    return notification;
  }

  // TODO: Add paging...
  getHistory(userId: string, page: number, pageSize: number = 10): Observable<PushNotification[]> {
    // This could be an API call to your web application that would go to the database
    // and retrieve a N amount of history messages between the users.
    return this.http
      .get<PushNotification[]>('pushNotifications/GetPushNotificationHistory/' + userId + '/' + page + '/' + pageSize)
      .pipe(
        catchError((error: any) => throwError(error.error || 'Server error')),
        map((notifications: PushNotification[]) => {
          notifications.forEach(notification => {
            notification.entity = JSON.parse(notification.jsonEntity);
            return notification;
          });

          return notifications;
        })
      );
  }

  readNotification(id: string) {
    if (this.hubConnection && this.hubConnection.state === signalR.HubConnectionState.Connected) {
      this.hubConnection.send('ReadNotification', id);
    }
  }

  sendNotification(type: NotificationType, payload: string, senderId: string, receiverId: string): void {
    if (this.hubConnection && this.hubConnection.state === signalR.HubConnectionState.Connected) {
      this.hubConnection.send('SendNotification', type, payload, senderId, receiverId);
    }
  }

  stopConnection() {
    console.log('Stopping notification hub connection');
    this.hubConnection.stop();
  }

  ngOnDestroy(): void {
    this.hubConnection.stop();
  }
}
