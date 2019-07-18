import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { map, take } from 'rxjs/operators';
import { SignalrNgChatAdapter } from 'src/app/core/ng-chat/signalr-ng-chat-adapter';
import { Theme } from 'src/business/models/theme.enum';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';
import { ChatService } from 'src/business/services/chat.service';
import { PushNotificationsService } from 'src/business/services/push-notification.service';
import { logout } from 'src/ngrx/auth/auth.actions';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeProgressBar, activeTheme, requestLoading } from 'src/ngrx/user-interface/ui.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { SubSink } from 'subsink';
import { Message } from '../ng-chat/core/message';
import { NgChatTheme } from '../ng-chat/core/ng-chat-theme.enum';
import { SettingsComponent } from '../settings/settings.component';
import { SidebarService } from './../../../business/services/shared/sidebar.service';

@Component({
  selector: 'app-app-container',
  templateUrl: './app-container.component.html',
  styleUrls: ['./app-container.component.scss'],
  providers: [ChatService, PushNotificationsService, SignalrNgChatAdapter]
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
    private dialog: MatDialog,
    protected chatAdapter: SignalrNgChatAdapter,
    private route: ActivatedRoute,
    public sidebarService: SidebarService,
    protected chatService: ChatService,
    public store: Store<AppState>,
  ) {
    this.userId = this.chatAdapter.userId;
    this.section = this.route.snapshot.data.section;
  }

  ngOnInit() {

    this.store.select(currentUser).pipe(take(1)).subscribe((user: CurrentUser) => this.userFullName = user.fullName);

    this.loading$ = combineLatest(
      this.store.select(requestLoading),
      this.store.select(activeProgressBar)
    ).pipe(map(([isLoading, progressBar]) => isLoading && progressBar == UIProgressBar.LoginScreen));
    
    this.setSidenavPanel();

    // chat theme subscription
    this.subs.add( 
      this.store.select(activeTheme)
        .subscribe((theme: Theme) => {
          this.theme = NgChatTheme[theme]
        }) 
      );

    // if routing to settings -> open dialog with specific section from route data
    this.section && this.openSettings(this.section);
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  setSidenavPanel() {
    // You cannot dispatch object reference so you must sent copy..
    // const sidenav = Object.assign({}, this.sidenav)
    // this.store.dispatch(addSidenav({ name: UISidenav.App, sidenav}));
  }

  onMessagesSeen(messages: Message[]) {
    this.chatAdapter.sendOnMessagesSeenEvent(messages);
  }

  openSettings(section: string) {
    this.dialog.open(SettingsComponent, {
        height: 'auto',
        width: '98%',
        maxWidth: '58rem',
        autoFocus: false,
        data: { title: 'Settings', section },
        panelClass: 'settings-dialog-container'
      });
  }
  
  logout() {
    this.store.dispatch(logout());
  }

  toggleSidebar() {
    this.sidebarService.toggleApp();
  }

}
