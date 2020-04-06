import { Window } from 'src/app/features/chat/models/window.model';
import { IChatParticipant } from './../../app/features/chat/models/chat-participant.model';
import { ParticipantMetadata } from './../../app/features/chat/models/participant-metadata.model';

export interface ChatState {
    fullscreenChatActive: boolean,
    windows: {[key: string]: Window},
    friends: IChatParticipant[],
    friendsMetadata: ParticipantMetadata[],
    selectedFriend: IChatParticipant,
}

export const initialChatState: ChatState = {
    fullscreenChatActive: false,
    windows: undefined,
    friends: undefined,
    friendsMetadata: undefined,
    selectedFriend: undefined,
};
