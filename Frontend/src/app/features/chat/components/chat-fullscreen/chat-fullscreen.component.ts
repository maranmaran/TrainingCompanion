import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { MatTabGroup } from '@angular/material/tabs';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { setFullscreenChatActive } from 'src/ngrx/chat/chat.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { ScrollDirection } from '../../models/enums/scroll-direction.enum';
import { selectedFriend } from './../../../../../ngrx/chat/chat.selectors';
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

  private subs = new SubSink();

  constructor(
    public mediaObserver: MediaObserver,
    private signalrService: ChatSignalrService,
    private store: Store<AppState>,
  ) { }

  ngOnInit(): void {
    setTimeout(() => this.store.dispatch(setFullscreenChatActive({active: true})))

    this.subs.add(
      this.store.select(selectedFriend)
      .pipe(filter(friend => {

        // change tab focus to friends if needed
        setTimeout(() => {
          if(!friend) {
             // disabled if no1 is selected
             this.tabs._tabs.first.disabled = !friend;
             this.tabs.selectedIndex = 1;
          }
        })

        return !!friend && this.mediaObserver.isActive('lt-md')
      }))
      .subscribe(_ => {
        this.tabs.selectedIndex = 0;
        this.chatBody?.scrollChatWindow(ScrollDirection.Bottom);
        this.tabs.realignInkBar()
      })
    )
    this.init();
  }

  ngOnDestroy() {
    this.store.dispatch(setFullscreenChatActive({active: false}));
    this.subs.unsubscribe();
  }

  private init() {
  }

}
