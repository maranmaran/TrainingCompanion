import { animate, keyframes, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Toast, ToastPackage, ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map, take, tap } from 'rxjs/operators';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { currentUser, unitSystem } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: '[pink-toast-component]',
  // providers: [NotificationSignalrService],
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
export class NotificationToastComponent extends Toast implements OnInit {

  notification: PushNotification;
  unitSystem$: Observable<UnitSystem>;
  notificationType = NotificationType;
  avatar: Observable<string>;

  // constructor is only necessary when not using AoT
  constructor(
    public toastrService: ToastrService,
    public toastPackage: ToastPackage,
    private notificationService: NotificationSignalrService,
    private store: Store<AppState>
  ) {
    super(toastrService, toastPackage);
  }

  ngOnInit(): void {
    this.avatar = this.store.select(currentUser).pipe(map(user => user.avatar));
    this.unitSystem$ = this.store.select(unitSystem);
    this.notification = JSON.parse(this.message);
  }

  readNotification() {
    // TODO: implement route on click... from notification.urlsomething
    this.notificationService.readNotification(this.notification.id);
  }

}
