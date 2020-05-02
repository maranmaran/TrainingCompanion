import { Component, OnDestroy, OnInit, ViewChild, HostListener } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { MatSidenav } from '@angular/material/sidenav';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { ChatTheme } from 'src/app/features/chat/models/enums/chat-theme.enum';
import { FeedSignalrService } from 'src/business/services/feature-services/feed-signalr.service';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { Theme } from 'src/business/shared/theme.enum';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { isAthlete } from 'src/ngrx/auth/auth.selectors';
import { isFullScreenChatActive } from 'src/ngrx/chat/chat.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { currentUserId } from './../../../ngrx/auth/auth.selectors';
import { ChatConfiguration } from './../../features/chat/chat.configuration';
import { ChatSignalrService } from './../../features/chat/services/chat-signalr.service';
import { ToolbarComponent } from './../navigation/toolbar/toolbar.component';

@Component({
  selector: 'app-app-container',
  templateUrl: './app-container.component.html',
  styleUrls: ['./app-container.component.scss'],
  providers: []
})
export class AppContainerComponent implements OnInit, OnDestroy {

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;
  @ViewChild(ToolbarComponent, { static: true }) toolbar: ToolbarComponent;

  isAthlete: boolean;
  showTabsNavigation: boolean;

  theme: ChatTheme;
  userId: string;

  // chat variables
  fullScreenChatActive: boolean;
  chatConfig: ChatConfiguration;

  private section: string; // for routing to settings
  private subs = new SubSink();

  constructor(
    public mediaObserver: MediaObserver,
    public store: Store<AppState>,
    private route: ActivatedRoute,
    private uiService: UIService,
    // public chatService: ChatService,
    private notificationService: NotificationSignalrService, // just here to be instantiated
    private feedSignalrService: FeedSignalrService, // just here to be instantiated
    private chatSignalrService: ChatSignalrService, // just here to be instantiated
  ) {
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);
    this.section = this.route.snapshot.data.section;
  }

  ngOnInit() {

    // chat configurations
    // this.chatConfig = this.chatService.getChatConfiguration(this.theme);

    // set sidenav
    this.uiService.addOrUpdateSidenav(UISidenav.App, this.sidenav);

    // chat theme subscription
    this.subs.add(
      this.store.select(activeTheme)
        .subscribe((theme: Theme) => {
          this.theme = ChatTheme[theme]
          // this.chatConfig.theme = ChatTheme[theme];
        }),
      this.store.select(isAthlete)
        .subscribe(isAthlete => this.isAthlete = isAthlete),
      this.store.select(isFullScreenChatActive)
        .subscribe(isFullScreenChatActive => this.fullScreenChatActive = isFullScreenChatActive),
    );

    // if routing to settings -> open dialog with specific section from route data
    if (this.section) {
      this.toolbar.onOpenSettings(this.section);
    }
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  // get showTabs() : boolean {
  //   return this.mediaObserver.isActive('lt-sm') && this.isAthlete;
  // }

  get showSmallChat(): boolean {
    return !this.fullScreenChatActive && !this.mediaObserver.isActive('lt-md')
  }


  @HostListener('swiperight', ['$event']) onSwipeRight = () => {
    if (!this.uiService.isSidenavOpened(UISidenav.App, true))
      this.uiService.doSidenavAction(UISidenav.App, UISidenavAction.Toggle)
  }

  @HostListener('swipeleft', ['$event']) onSwipeLeft = () => {
    if (this.uiService.isSidenavOpened(UISidenav.App, true))
      this.uiService.doSidenavAction(UISidenav.App, UISidenavAction.Toggle)
  }



}
