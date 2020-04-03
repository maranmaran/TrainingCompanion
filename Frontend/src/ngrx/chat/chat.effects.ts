import { Injectable } from '@angular/core';


@Injectable()
export class ChatEffects {

    constructor(
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
