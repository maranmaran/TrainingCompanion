import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
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
* Returns the base URL for the Push notifications hub.
*/
  public get feedHubUrl(): string {
    return environment.feedHubUrl;
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

}

export const APP_SETTINGS_PROVIDER = [
  { provide: AppSettingsService, useClass: AppSettingsService }
];
