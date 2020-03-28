import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { ChatTheme } from 'src/app/features/chat/models/enums/chat-theme.enum';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { FeedSignalrService } from 'src/business/services/feature-services/feed-signalr.service';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { UISidenav } from 'src/business/shared/ui-sidenavs.enum';
import { logout } from 'src/ngrx/auth/auth.actions';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { isFullScreenChatActive } from 'src/ngrx/chat/chat.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme, getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { SubSink } from 'subsink';
import { SettingsComponent } from '../settings/settings.component';
import { UISidenavAction } from './../../../business/shared/ui-sidenavs.enum';
import { currentUserId } from './../../../ngrx/auth/auth.selectors';
import { ChatConfiguration } from './../../features/chat/chat.configuration';
import { ChatSignalrService } from './../../features/chat/services/chat-signalr.service';

@Component({
  selector: 'app-app-container',
  templateUrl: './app-container.component.html',
  styleUrls: ['./app-container.component.scss'],
  providers: []
})
export class AppContainerComponent implements OnInit, OnDestroy {

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;

  theme: ChatTheme;
  userId: string;
  userFullName: string;
  loading$: Observable<boolean>;

  // chat variables
  fullScreenChatActive: Observable<boolean>;
  chatConfig: ChatConfiguration;

  private section: string; // for routing to settings
  private subs = new SubSink();

  constructor(
    public store: Store<AppState>,
    private route: ActivatedRoute,
    private uiService: UIService,
    public chatService: ChatService,
    private notificationService: NotificationSignalrService, // just here to be instantiated
    private feedSignalrService: FeedSignalrService, // just here to be instantiated
    private chatSignalrService: ChatSignalrService, // just here to be instantiated
  ) {
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);
    this.section = this.route.snapshot.data.section;
  }

  ngOnInit() {

    // chat configurations
    setTimeout(() => this.fullScreenChatActive = this.store.select(isFullScreenChatActive));
    this.chatConfig = this.chatService.getChatConfiguration(this.theme);

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
          this.theme = ChatTheme[theme]
          this.chatConfig.theme = ChatTheme[theme];
        }),
    );

    // if routing to settings -> open dialog with specific section from route data
    this.section && this.onOpenSettings(this.section);

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
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

  onLogout(event) {
    this.store.dispatch(logout());
  }

  onToggleSidebar(event) {
    this.uiService.doSidenavAction(UISidenav.App, UISidenavAction.Toggle);
  }

}
