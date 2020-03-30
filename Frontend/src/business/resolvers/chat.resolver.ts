import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { combineLatest, Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { friends } from 'src/ngrx/chat/chat.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { isEmpty } from '../utils/utils';
import { IChatParticipant } from './../../app/features/chat/models/chat-participant.model';
import { ParticipantMetadata } from './../../app/features/chat/models/participant-metadata.model';
import { ParticipantResponse } from './../../app/features/chat/models/participant-response.model';
import { ChatSignalrService } from './../../app/features/chat/services/chat-signalr.service';
import { friendsFetched, setSelectedFriend } from './../../ngrx/chat/chat.actions';
import { friendsMetadata, selectedFriend } from './../../ngrx/chat/chat.selectors';

@Injectable()
export class ChatResolver implements Resolve<Observable<{ friends: IChatParticipant[], metadata: ParticipantMetadata[] } | void>> {

  constructor(
    private chatSignalrService: ChatSignalrService,
    private store: Store<AppState>
  ) { }


  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    this.chatSignalrService.init();

    return combineLatest(
      this.store.select(friends),
      this.store.select(friendsMetadata),
      this.store.select(selectedFriend)
    ).pipe(
      take(1),
      concatMap(([friends, metadata, selectedFriend]) => {

        if (isEmpty(friends) || isEmpty(metadata)) {
          return this.updateState()
        }

        if(!selectedFriend) {
          this.store.dispatch(setSelectedFriend({friend: friends[0]}))
        }

        return of({ friends, metadata });
      })
    )
  }

  private updateState() {
    return this.chatSignalrService.listFriends()
      .pipe(
        take(1),
        map((response: ParticipantResponse[]) => {
          this.store.dispatch(friendsFetched({ response }));
          this.store.dispatch(setSelectedFriend({friend: response[0].participant }))
        }))
  }
}
