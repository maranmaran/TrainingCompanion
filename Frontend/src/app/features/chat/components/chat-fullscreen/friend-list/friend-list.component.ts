import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { debounceTime, map } from 'rxjs/operators';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { setSelectedFriend } from 'src/ngrx/chat/chat.actions';
import { friends, friendsMetadata } from 'src/ngrx/chat/chat.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { selectedFriend } from './../../../../../../ngrx/chat/chat.selectors';
import { IChatParticipant } from './../../../models/chat-participant.model';
import { ParticipantMetadata } from './../../../models/participant-metadata.model';
import { ChatSignalrService } from './../../../services/chat-signalr.service';

@Component({
  selector: 'app-friend-list',
  templateUrl: './friend-list.component.html',
  styleUrls: ['./friend-list.component.scss']
})
export class FriendListComponent implements OnInit, OnDestroy {

  selectedFriend: Observable<IChatParticipant>;
  friends: Observable<IChatParticipant[]>;
  metadata: Observable<ParticipantMetadata[]>;

  searchField: FormControl;
  private subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private chatService: ChatService,
    private signalrService: ChatSignalrService
  ) { }

  ngOnInit(): void {
    this.selectedFriend = this.store.select(selectedFriend);
    this.friends = this.store.select(friends);
    this.metadata = this.store.select(friendsMetadata);

    this.searchField = new FormControl('');

    this.subs.add(
      this.searchField.valueChanges.pipe(debounceTime(500), map(val => val.toLocaleLowerCase())).subscribe(
        val => {
          let allFriends = this.store.select(friends);
          if(val) {
            this.friends = allFriends.pipe(map(friends => this.filterFn(friends, val)));
          } else {
            this.friends = allFriends;
          }
        }
      )
    )
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  filterFn = (friends, val) => friends.filter(friend => friend.displayName.toLocaleLowerCase().indexOf(val) != -1);

  onFriendClicked(friend: IChatParticipant) {
    this.store.dispatch(setSelectedFriend({friend}))
  }

}
