import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { SignalrNgChatAdapter } from 'src/app/core/ng-chat/signalr-ng-chat-adapter';
import { ChatService } from 'src/business/services/chat.service';
import { PushNotificationsService } from 'src/business/services/push-notification.service';
import { ThemeService } from 'src/business/services/shared/theme.service';
import { SubSink } from 'subsink';
import { ToolbarComponent } from '../navigation/toolbar/toolbar.component';
import { SidebarService } from './../../../business/services/shared/sidebar.service';
import { Theme } from 'src/business/models/theme.enum';
import { Message } from '../ng-chat/core/message';

@Component({
  selector: 'app-app-container',
  templateUrl: './app-container.component.html',
  styleUrls: ['./app-container.component.scss'],
  providers: [ChatService, PushNotificationsService, SignalrNgChatAdapter]
})
export class AppContainerComponent implements OnInit, OnDestroy {

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;
  @ViewChild(ToolbarComponent, { static: true }) toolbar: ToolbarComponent;

  private theme: Theme;
  private userId: string;

  private section: string;
  private subs = new SubSink();


  constructor(
    protected chatAdapter: SignalrNgChatAdapter,
    private themeService: ThemeService,
    private route: ActivatedRoute,
    public sidebarService: SidebarService,
    protected chatService: ChatService
  ) {
    this.userId = this.chatAdapter.userId;
    this.section = this.route.snapshot.data.section;
  }

  ngOnInit() {
    this.setSidenavPanel();
    this.themeService.setCurrentUserTheme();

    this.subs.add(this.themeService.theme$
      .pipe(map((theme: string) => this.themeService.getChatTheme(theme)))
      .subscribe((theme: Theme) => { this.theme = theme }));

    // if routing to settings -> open dialog with specific section from route data
    this.section && this.toolbar.openSettings(this.section);
  }

  setSidenavPanel() {
    this.sidebarService.setAppSidenav(this.sidenav);
  }

  onMessagesSeen(messages: Message[]) {
    this.chatAdapter.sendOnMessagesSeenEvent(messages);
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
