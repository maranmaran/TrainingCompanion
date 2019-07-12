import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders } from '@angular/common/http';

@Injectable({ providedIn: 'root'})
export class AppSettingsService {

    /**
     * Returns the base URL for the API.
     */
    public get apiUrl(): string {
        return environment.apiUrl;
    }

      /**
     * Returns the base URL for the Push notifications hub.
     */
    public get notificationHubUrl(): string {
        return environment.notificationHubUrl;
    }

       /**
     * Returns the base URL for the Chat hub.
     */
    public get chatHubUrl(): string {
        return environment.chatHubUrl;
    }

    /**
     * Returns http headers for the API.
     */
    public get apiHeaders(): HttpHeaders {
        const headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
        return headers;
    }

    /**
     * Returns the current environment name.
     */
    public get environmentName(): string {
        return environment.name;
    }

    /**
     * Flags whether stack traces will be shown when displaying errors.
     */
    public get showStackTrace(): boolean {
        return environment.showStackTrace;
    }

    /**
     * Gets colors scheme for active and available plans for subscription
     */
    public get planColors(): string[] {
        return environment.planColors;
    }
}

export const APP_SETTINGS_PROVIDER = [
    { provide: AppSettingsService, useClass: AppSettingsService }
];
