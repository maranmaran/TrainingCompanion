import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { SignalrNgChatAdapter } from 'src/app/core/ng-chat/signalr-ng-chat-adapter';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { UISidenav } from 'src/business/shared/ui-sidenavs.enum';
import { logout } from 'src/ngrx/auth/auth.actions';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme, getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { SubSink } from 'subsink';
import { Message } from '../ng-chat/core/message';
import { NgChatTheme } from '../ng-chat/core/ng-chat-theme.enum';
import { SettingsComponent } from '../settings/settings.component';
import { UISidenavAction } from './../../../business/shared/ui-sidenavs.enum';

@Component({
  selector: 'app-app-container',
  templateUrl: './app-container.component.html',
  styleUrls: ['./app-container.component.scss'],
  providers: [
    SignalrNgChatAdapter,
    NotificationSignalrService
  ]
})
export class AppContainerComponent implements OnInit, OnDestroy {

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;

  protected theme: NgChatTheme;
  protected userId: string;
  protected userFullName: string;
  protected loading$: Observable<boolean>;

  private section: string;
  private subs = new SubSink();


  constructor(
    public store: Store<AppState>,
    protected chatService: ChatService,
    private notificationService: NotificationSignalrService,
    protected chatAdapter: SignalrNgChatAdapter,
    private route: ActivatedRoute,
    private uiService: UIService,
  ) {
    this.userId = this.chatAdapter.userId;
    this.section = this.route.snapshot.data.section;
  }

  ngOnInit() {


    // get user full name from store
    this.store.select(currentUser).pipe(take(1)).subscribe((user: CurrentUser) => this.userFullName = user.fullName);

    // set observable for main progress bar
    this.loading$ = getLoadingState(this.store, UIProgressBar.MainAppScreen);;

    // set sidenav
    this.uiService.addOrUpdateSidenav(UISidenav.App, this.sidenav);

    // chat theme subscription
    this.subs.add(
      this.store.select(activeTheme)
        .subscribe((theme: Theme) => {
          this.theme = NgChatTheme[theme]
        })
      );

    // if routing to settings -> open dialog with specific section from route data
    this.section && this.onOpenSettings(this.section);

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  onMessagesSeen(messages: Message[]) {
    this.chatAdapter.sendOnMessagesSeenEvent(messages);
  }

  onOpenSettings(section: string) {

    this.uiService.openDialogFromComponent(SettingsComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '58rem',
      autoFocus: false,
      data: { title: 'Settings', section },
      panelClass: ['settings-dialog-container']
    });

  }

  onLogout() {
    this.store.dispatch(logout());
  }

  onToggleSidebar() {
    this.uiService.doSidenavAction(UISidenav.App, UISidenavAction.Toggle);
  }

}
