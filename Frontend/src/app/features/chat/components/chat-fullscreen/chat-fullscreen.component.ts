import { Component, OnDestroy, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setFullscreenChatActive } from 'src/ngrx/user-interface/ui.actions';
import { SubSink } from 'subsink';
import { IChatParticipant } from './../../models/chat-participant.model';
import { ParticipantMetadata } from './../../models/participant-metadata.model';
import { ParticipantResponse } from './../../models/participant-response.model';
import { ChatSignalrService } from './../../services/chat-signalr.service';

@Component({
  selector: 'app-chat-fullscreen',
  templateUrl: './chat-fullscreen.component.html',
  styleUrls: ['./chat-fullscreen.component.scss']
})
export class ChatFullscreenComponent implements OnInit, OnDestroy {

  friends: IChatParticipant[];
  participantMetadata: ParticipantMetadata[];

  private subs = new SubSink();

  constructor(
    public mediaObserver: MediaObserver,
    private signalrService: ChatSignalrService,
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    setTimeout(() => this.store.dispatch(setFullscreenChatActive({active: true})))
  }

  ngOnDestroy() {
    this.store.dispatch(setFullscreenChatActive({active: false}));
    this.subs.unsubscribe();
  }

  private init() {
    this.fetchFriendsList();
  }

  private fetchFriendsList(): void {
    this.signalrService.listFriends()
      .pipe(
        take(1)
      ).subscribe((participantsResponse: ParticipantResponse[]) => {
        this.participantMetadata = participantsResponse.map(x => x.metadata);

        this.friends = participantsResponse.map((response: ParticipantResponse) => {
          return response.participant;
        });
      });
  }

}
