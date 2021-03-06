import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { NavigationStart, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, take } from 'rxjs/operators';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { logout } from 'src/ngrx/auth/auth.actions';
import { currentUser, unitSystem } from 'src/ngrx/auth/auth.selectors';
import { totalUnreadChatMessages } from 'src/ngrx/chat/chat.selectors';
import { setTrackEditMode } from 'src/ngrx/dashboard/dashboard.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { SubSink } from 'subsink';
import { SettingsComponent } from '../../settings/settings.component';
import { UIService } from './../../../../business/services/shared/ui.service';
import { dashboardActive } from './../../../../ngrx/dashboard/dashboard.selectors';
import { PushNotification } from './../../../../server-models/entities/push-notification.model';
import { AccountType } from './../../../../server-models/enums/account-type.enum';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit, OnDestroy {

  constructor(
    private notificationService: NotificationSignalrService,
    private store: Store<AppState>,
    private UIService: UIService,
    public mediaObserver: MediaObserver,
    private router: Router
  ) { }

  subSink = new SubSink();

  unitSystem$: Observable<UnitSystem>;

  // chat
  unreadChatMessages: Observable<number>

  // notifications
  page = 0;
  pageSize = 10; // TODO: AppSettings -> NotificationsPageSize
  unreadNotificationCounter = 0;
  notifications: PushNotification[] = [];
  stopFetch = false;

  userInfo: {
    userId: string;
    avatar: string;
    fullName: string;
    isCoach: boolean;
    isAthlete: boolean;
  }

  loading$: Observable<boolean>;
  dashboardActive$: Observable<boolean>;

  @ViewChild("notificationsTrigger", {read: MatMenuTrigger}) notificationMenu: MatMenuTrigger;

  ngOnInit(): void {

    
    // set observable for main progress bar
    this.loading$ = getLoadingState(this.store, UIProgressBar.MainAppScreen);
    this.dashboardActive$ = this.store.select(dashboardActive);
    
    this.unreadChatMessages = this.store.select(totalUnreadChatMessages);
    
    this.unitSystem$ = this.store.select(unitSystem);
    
    // subscribe to notifications
    // only new ones.. in real time
    // this.notifications$ = this.notificationService.notifications$;
    this.subSink.add(
      this.router.events.subscribe(events => events instanceof NavigationStart && this.closeMenusOnRoute()),

      this.store.select(currentUser)
        .subscribe(user => {
          this.userInfo = {
            userId: user.id,
            isCoach: user.accountType == AccountType.Coach || user.accountType == AccountType.Admin,
            isAthlete: user.accountType == AccountType.Athlete,
            fullName: user.fullName,
            avatar: user?.avatar,
          }
        }),

      this.notificationService.notifications$
        .subscribe((notification: PushNotification) => {

          this.notifications = [notification, ...this.notifications];
          !notification.read && this.unreadNotificationCounter++;

        }),
    );

    setTimeout(_ => this.getHistory(this.userInfo.userId, this.page++, this.pageSize));
  }

  closeMenusOnRoute(){
    this.notificationMenu?.closeMenu();
  }

  ngOnDestroy(): void {
    this.subSink.unsubscribe();
  }

  // BUG with mat menu integration https://github.com/angular/components/issues/10122
  // loadMoreNotifications(index: number) {
  //   console.log(index);
  //   index += 7;

  //   if (index === this.notifications.length && !this.stopFetch) {
  //     this.getHistory(this.page++, this.pageSize);
  //   }
  // }

  loadMoreNotifications() {
    this.getHistory(this.userInfo.userId, this.page++, this.pageSize);
  }

  getHistory(userId, page, pageSize) {

    if (!this.stopFetch) {
      this.notificationService.getHistory(userId, page, pageSize)
        .pipe(take(1))
        .subscribe(notifications => {

          if (!notifications || notifications.length == 0) {
            return this.stopFetch = true;
          }

          notifications.forEach(n => !n.read && this.unreadNotificationCounter++);
          this.notifications = [...this.notifications, ...notifications];

        });
    }
  }

  // TODO: Route probably
  onClickNotification(notification: PushNotification) {
    console.log('click');
    return;
  }

  // TODO: Update notification
  onHoverNotification(notification: PushNotification) {
    notification.read = true;
    this.unreadNotificationCounter--;
    this.notificationService.readNotification(notification.id);
    return;
  }

  onOpenSettings(section: string = null) {
    this.UIService.openDialogFromComponent(SettingsComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '58rem',
      autoFocus: false,
      data: { title: 'SETTINGS.SETTINGS_LABEL', section },
      panelClass: ['settings-dialog-container', 'dialog-container'],
      closeOnNavigation: true
    });
  }

  onLogout() {
    this.store.dispatch(logout());
  }

  onToggleSidebar() {
    this.UIService.doSidenavAction(UISidenav.App, UISidenavAction.Toggle);
  }

  toggleDashboardEdit() {
    this.store.dispatch(setTrackEditMode());
    this.UIService.doSidenavAction(UISidenav.DashboardComponents, UISidenavAction.Toggle);
  }


}
