import { Injectable, OnDestroy } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { AppSettingsService } from '../shared/app-settings.service';

@Injectable({ providedIn: 'root' })
export class PushNotificationsService implements OnDestroy {

    private _notificationHubConn: signalR.HubConnection;
    public notifications: { type: string, payload: string }[] = [];

    constructor(
        private appSettingsService: AppSettingsService
    ) {
        this.configurePushNotificationHubConnection();
    }

    private configurePushNotificationHubConnection() {
        this._notificationHubConn = new signalR.HubConnectionBuilder()
            .withUrl(this.appSettingsService.notificationHubUrl)
            // { accessTokenFactory: () => this.authService.getToken() })
            .build();

        this._notificationHubConn.start()
            .catch(err => console.log(`Error while establishing chat connection. ${err}`));

        this._notificationHubConn
            .on('BroadcastMessage', (type: string, payload: string) => {
                this.notifications.push({ type, payload });
            });
    }

    ngOnDestroy(): void {
        this._notificationHubConn.stop();
    }


}