import { OnInit, Injectable } from '@angular/core';
import { NotificationToastComponent } from 'src/app/shared/notifications/notification-toast/notification-toast.component';

@Injectable({ providedIn: 'root' })
export class NotificationService implements OnInit {

  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }

  get systemNotificationToastConfig() {
    return {
      timeOut: 2000,
      disableTimeOut: false,
      positionClass: 'toast-bottom-right',
      preventDuplicates: false,
      toastComponent: NotificationToastComponent // added custom toast!
    };
  }

  get defaultNotificationConfig() {
    return {
      timeOut: 2000,
      disableTimeOut: false,
      positionClass: 'toast-bottom-right',
      preventDuplicates: false,
      enableHtml: true
    }
  }

}
