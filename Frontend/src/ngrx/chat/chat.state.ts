import { Message } from 'src/app/features/chat/models/message.model';
import { Window } from 'src/app/features/chat/models/window.model';
import { IChatParticipant } from './../../app/features/chat/models/chat-participant.model';
import { ParticipantMetadata } from './../../app/features/chat/models/participant-metadata.model';

export interface ChatState {
    windows: {[key: string]: Window},
    friends: IChatParticipant[],
    friendsMetadata: ParticipantMetadata[],
    selectedFriend: IChatParticipant,
    fullscreenChatActive: boolean,
    messages: Message[]
}

export const initialChatState: ChatState = {
    windows: undefined,
    friends: undefined,
    friendsMetadata: undefined,
    selectedFriend: undefined,
    fullscreenChatActive: false,
    messages: undefined
};
