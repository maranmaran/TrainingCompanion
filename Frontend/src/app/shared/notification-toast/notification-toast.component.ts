import { animate, keyframes, state, style, transition, trigger } from '@angular/animations';
import { Component } from '@angular/core';
import { Toast, ToastPackage, ToastrService } from 'ngx-toastr';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { PushNotification } from './../../../server-models/entities/push-notification.model';


@Component({
  selector: '[pink-toast-component]',
  styleUrls: ['./notification-toast.component.scss'],
    templateUrl: './notification-toast.component.html',
    animations: [
    trigger('flyInOut', [
      state('inactive', style({
        opacity: 0,
      })),
      transition('inactive => active', animate('400ms ease-out', keyframes([
        style({
          transform: 'translate3d(100%, 0, 0) skewX(-30deg)',
          opacity: 0,
        }),
        style({
          transform: 'skewX(20deg)',
          opacity: 1,
        }),
        style({
          transform: 'skewX(-5deg)',
          opacity: 1,
        }),
        style({
          transform: 'none',
          opacity: 1,
        }),
      ]))),
      transition('active => removed', animate('400ms ease-out', keyframes([
        style({
          opacity: 1,
        }),
        style({
          transform: 'translate3d(100%, 0, 0) skewX(30deg)',
          opacity: 0,
        }),
      ]))),
    ]),
  ],
  preserveWhitespaces: false,
})
export class NotificationToastComponent extends Toast {

  notification: PushNotification;

  // constructor is only necessary when not using AoT
  constructor(
    protected toastrService: ToastrService,
    public toastPackage: ToastPackage,
    private notificationService: NotificationSignalrService
  ) {
    super(toastrService, toastPackage);
    this.notification = JSON.parse(this.message);
  }

  readNotification() {
    // TODO: implement route on click... from notification.urlsomething
    this.notificationService.readNotification(this.notification.id);
  }

}
