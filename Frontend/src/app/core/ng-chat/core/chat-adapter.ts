import { Observable, Subject } from 'rxjs';
import { IChatParticipant } from './chat-participant';
import { Message } from "./message";
import { ParticipantResponse } from "./participant-response";

export abstract class ChatAdapter
{
    // ### Abstract adapter methods ###

    public bootstrap = new Subject<void>();

    public abstract listFriends(): Observable<ParticipantResponse[]>;

    public abstract getMessageHistory(destinataryId: any): Observable<Message[]>;

    public abstract sendMessage(message: Message): void;

    // ### Adapter/Chat income/ingress events ###

    public onFriendsListChanged(participantsResponse: ParticipantResponse[]): void
    {
        this.friendsListChangedHandler(participantsResponse);
    }

    public onMessageReceived(participant: IChatParticipant, message: Message): void
    {
        this.messageReceivedHandler(participant, message);
    }

    // Event handlers
    friendsListChangedHandler: (participantsResponse: ParticipantResponse[]) => void  = (participantsResponse: ParticipantResponse[]) => {};
    messageReceivedHandler: (participant: IChatParticipant, message: Message) => void = (participant: IChatParticipant, message: Message) => {};
}
