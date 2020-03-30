import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { MatTabGroup } from '@angular/material/tabs';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { ChatTheme } from 'src/app/features/chat/models/enums/chat-theme.enum';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { setFullscreenChatActive } from 'src/ngrx/chat/chat.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { ScrollDirection } from '../../models/enums/scroll-direction.enum';
import { selectedFriend } from './../../../../../ngrx/chat/chat.selectors';
import { setActiveProgressBar } from './../../../../../ngrx/user-interface/ui.actions';
import { activeTheme } from './../../../../../ngrx/user-interface/ui.selectors';
import { ChatConfiguration } from './../../chat.configuration';
import { IChatParticipant } from './../../models/chat-participant.model';
import { ParticipantMetadata } from './../../models/participant-metadata.model';
import { ChatSignalrService } from './../../services/chat-signalr.service';
import { ChatBodyComponent } from './chat-body/chat-body.component';

@Component({
  selector: 'app-chat-fullscreen',
  templateUrl: './chat-fullscreen.component.html',
  styleUrls: ['./chat-fullscreen.component.scss']
})
export class ChatFullscreenComponent implements OnInit, OnDestroy {


  @ViewChild('tabs') tabs: MatTabGroup;
  @ViewChild('chatBody') chatBody: ChatBodyComponent;

  friends: Observable<IChatParticipant[]>;
  friendsMetadata: Observable<ParticipantMetadata[]>;
  config: ChatConfiguration;

  selectedFriend: IChatParticipant;

  private subs = new SubSink();

  constructor(
    public mediaObserver: MediaObserver,
    private signalrService: ChatSignalrService,
    private store: Store<AppState>,
    private chatService: ChatService,
  ) { }

  ngOnInit(): void {
    this.store.dispatch(setActiveProgressBar({progressBar: UIProgressBar.None}));

    setTimeout(() => this.store.dispatch(setFullscreenChatActive({ active: true })))

    this.subs.add(
      // theme
      this.store.select(activeTheme)
        .subscribe(theme => {
          let chatTheme = ChatTheme.Light;
          if (theme == Theme.Dark) {
            chatTheme = ChatTheme.Dark;
          }

          this.config = this.chatService.getChatConfiguration(chatTheme);
        }),

      // tabs active state
      this.store.select(selectedFriend)
      .subscribe(friend => {
        this.selectedFriend = friend;
        this.handleTabs(!!friend);
      })
    )
  }

  handleTabs(friendSelected: boolean) {

    let tabsActive = this.mediaObserver.isActive('lt-md');
    if(!tabsActive) return;

    // change tab focus to friends if needed
    setTimeout(() => {

      if (!friendSelected) {
        // disabled if no1 is selected
        this.tabs._tabs.first.disabled = true;
        this.tabs.selectedIndex = 1;
      } else {
        this.tabs.selectedIndex = 0;
        this.chatBody?.scrollChatWindow(ScrollDirection.Bottom);
      }

      this.tabs.realignInkBar()
    })
  }

  ngOnDestroy() {
    this.store.dispatch(setActiveProgressBar({progressBar: UIProgressBar.MainAppScreen}));
    this.store.dispatch(setFullscreenChatActive({ active: false }));
    this.subs.unsubscribe();
  }

}
