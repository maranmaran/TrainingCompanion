import { Injectable, OnDestroy } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { AppSettingsService } from '../shared/app-settings.service';
import { Activity } from './../../../app/features/dashboard/models/activity.model';
import { AuthService } from './auth.service';

@Injectable()
export class FeedSignalrService implements OnDestroy {

  private hubConnection: signalR.HubConnection;

  private subs = new SubSink();

  constructor(
    private authService: AuthService,
    private store: Store<AppState>,
    private appSettingsService: AppSettingsService,
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
      .withUrl(this.appSettingsService.feedHubUrl)
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

  initializeListeners() {
    this.hubConnection.on('PushFeedActivity', (activity: Activity) => {
      console.log(activity);
    });
  }

  stopConnection() {
    console.log('Stopping feed hub connection');
    this.hubConnection.stop();
  }

  ngOnDestroy(): void {
    this.hubConnection.stop();
  }
}
