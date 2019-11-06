import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/app/app.state';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { SubSink } from 'subsink';
import { NotificationType } from '../../../server-models/enums/notification-type.enum';
import { AppSettingsService } from '../shared/app-settings.service';
import { PushNotification } from './../../../server-models/entities/push-notification.model';
import { AuthService } from './auth.service';

@Injectable({ providedIn: 'root' })
export class NotificationSignalrService implements OnDestroy {

  private hubConnection: signalR.HubConnection;
  public notifications$ = new Subject<PushNotification>();

  private userId: string;
  private subs = new SubSink();

  constructor(
    private authService: AuthService,
    private store: Store<AppState>,
    private http: HttpClient,
    private appSettingsService: AppSettingsService
  ) {
    // subscribe to logout
    this.subs.add(
      this.authService.signOutEvent.subscribe(() => this.stopConnection())
    );

    // get some necessary data
    this.store
      .select(currentUserId)
      .pipe(take(1))
      .subscribe(userId => (this.userId = userId));

    // configure connection
    this.configureHubConnection();
  }

  private configureHubConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.appSettingsService.notificationHubUrl)
      // { accessTokenFactory: () => this.authService.getToken() })
      .build();

    this.hubConnection.serverTimeoutInMilliseconds = 100000; // 100 sec
    this.hubConnection
      .start()
      .then(() => {
        this.initializeListeners();
      })
      .catch(err =>
        console.log(`Error while establishing chat connection. ${err}`)
      );
  }

  // all listeners we react to
  initializeListeners() {
    this.hubConnection.on('SendNotification', (notification: PushNotification) => {
      console.log('Notification received');
      console.log(notification);
      this.notifications$.next(notification);
    });
  }

  // TODO: Add paging...
  getHistory(userId: any): Observable<PushNotification[]> {
    // This could be an API call to your web application that would go to the database
    // and retrieve a N amount of history messages between the users.
    return this.http
      .get('notification/GetNotificationHistory/' + this.userId)
      .pipe(
        map((res: any) => res),
        catchError((error: any) => throwError(error.error || 'Server error'))
      );
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
