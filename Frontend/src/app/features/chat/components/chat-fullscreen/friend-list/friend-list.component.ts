import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { setSelectedFriend } from 'src/ngrx/chat/chat.actions';
import { friends, friendsMetadata } from 'src/ngrx/chat/chat.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { IChatParticipant } from './../../../models/chat-participant.model';
import { ParticipantMetadata } from './../../../models/participant-metadata.model';

@Component({
  selector: 'app-friend-list',
  templateUrl: './friend-list.component.html',
  styleUrls: ['./friend-list.component.scss']
})
export class FriendListComponent implements OnInit {

  friends: Observable<IChatParticipant[]>;
  metadata: Observable<ParticipantMetadata[]>;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this.friends = this.store.select(friends);
    this.metadata = this.store.select(friendsMetadata);
  }

  onFriendClicked(friend: IChatParticipant) {
    this.store.dispatch(setSelectedFriend({friend}))
  }
}
