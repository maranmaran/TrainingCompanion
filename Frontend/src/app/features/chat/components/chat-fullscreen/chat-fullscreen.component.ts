import { Component, OnDestroy, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { setFullscreenChatActive } from 'src/ngrx/chat/chat.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { IChatParticipant } from './../../models/chat-participant.model';
import { ParticipantMetadata } from './../../models/participant-metadata.model';
import { ChatSignalrService } from './../../services/chat-signalr.service';

@Component({
  selector: 'app-chat-fullscreen',
  templateUrl: './chat-fullscreen.component.html',
  styleUrls: ['./chat-fullscreen.component.scss']
})
export class ChatFullscreenComponent implements OnInit, OnDestroy {

  friends: Observable<IChatParticipant[]>;
  friendsMetadata: Observable<ParticipantMetadata[]>;

  private subs = new SubSink();

  constructor(
    public mediaObserver: MediaObserver,
    private signalrService: ChatSignalrService,
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    setTimeout(() => this.store.dispatch(setFullscreenChatActive({active: true})))

    this.init();
  }

  ngOnDestroy() {
    this.store.dispatch(setFullscreenChatActive({active: false}));
    this.subs.unsubscribe();
  }

  private init() {
  }

}
