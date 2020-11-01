import { ComponentType } from '@angular/cdk/portal';
import { HttpHeaders } from '@angular/common/http';
import { Inject, Injectable, InjectionToken } from '@angular/core';
import { environment } from 'src/environments/environment';

export const NOTIFICATION_TOAST_TOKEN: InjectionToken<ComponentType<any>> =
  new InjectionToken<ComponentType<any>>('NOTIFICATION_TOAST_TOKEN');

@Injectable({ providedIn: 'root' })
export class AppSettingsService {

  constructor(
    @Inject(NOTIFICATION_TOAST_TOKEN) private toastNotificationComponent: ComponentType<any>
  ) { }

  public get sslRequired(): boolean {
    return environment.sslRequired;
  }

  /**
   * Returns the base URL for the API.
   */
  public get apiUrl(): string {
    if(this.sslRequired)
      return `https://${environment.apiUrl}`

    return `http://${environment.apiUrl}`
  }

  /**
 * Returns the base URL for the Push notifications hub.
 */
  public get notificationHubUrl(): string {
    return this.apiUrl + 'notifications-hub';
  }

  /**
* Returns the base URL for the Push notifications hub.
*/
  public get feedHubUrl(): string {
    return this.apiUrl + 'feed-hub';
  }

  /**
* Returns the base URL for the Chat hub.
*/
  public get chatHubUrl(): string {
    return this.apiUrl + 'chat-hub';
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

  public get systemNotificationToastConfig() {
    return {
      timeOut: 2000,
      disableTimeOut: false,
      positionClass: 'toast-bottom-right',
      preventDuplicates: false,
      toastClass: 'toast-notification',
      toastComponent: this.toastNotificationComponent // added custom toast!
    };
  }

  public get defaultNotificationConfig() {
    return {
      timeOut: 2000,
      disableTimeOut: false,
      positionClass: 'toast-bottom-right',
      preventDuplicates: false,
      enableHtml: true,
      toastClass: 'toast-default'
    }
  }

}

export const APP_SETTINGS_PROVIDER = [
  { provide: AppSettingsService, useClass: AppSettingsService }
];
