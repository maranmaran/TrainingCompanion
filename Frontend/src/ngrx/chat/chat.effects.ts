import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { AppState } from '../global-setup.ngrx';
import { ChatSignalrService } from './../../app/features/chat/services/chat-signalr.service';


@Injectable()
export class ChatEffects {

    constructor(
        private store: Store<AppState>,
        private actions$: Actions,
        private chatService: ChatService,
        private signalrService: ChatSignalrService
    ) { }


    // fetchMessageHistoryForSelectedFriend$ = createEffect(() =>
    //     this.actions$
    //         .pipe(
    //             ofType(ChatActions.fetchMessageHistory),
    //             switchMap((request: { friend: IChatParticipant  }) => {
    //                 return this.signalrService.getMessageHistory(request.friend.id).pipe(take(1));
    //             }, (request, response) => [request.friend, response]),
    //             map(([friend, messages]: [IChatParticipant, Message[]]) => {
    //               messages.forEach((message) => this.chatService.assertMessageType(message));
    //               this.store.dispatch(ChatActions.messageHistoryFetched({messages}));
    //               this.store.dispatch(ChatActions.setSelectedFriend({friend}));
    //             })
    //         )
    //     , { dispatch: false });
}
