import { AuthService } from 'src/business/services/auth.service';
import { OnDestroy, Injectable } from '@angular/core';
import { AppSettingsService } from './shared/app-settings.service';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';

@Injectable({ providedIn: 'root'})
export class PushNotificationsService implements OnDestroy {

    private _notificationHubConn: HubConnection;
    public notifications: { type: string, payload: string }[] = [];

    constructor(
        private authService: AuthService,
        private appSettingsService: AppSettingsService
    ) {
        this.configurePushNotificationHubConnection();
    }

    private configurePushNotificationHubConnection() {
        this._notificationHubConn = new signalR.HubConnectionBuilder()
            .withUrl(this.appSettingsService.notificationHubUrl,
                { accessTokenFactory: () => this.authService.getToken() })
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