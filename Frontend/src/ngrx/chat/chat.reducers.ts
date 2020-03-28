import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { IChatParticipant } from './../../app/features/chat/models/chat-participant.model';
import { ParticipantResponse } from './../../app/features/chat/models/participant-response.model';
import * as ChatActions from './chat.actions';
import { ChatState, initialChatState } from './chat.state';

export const chatReducer: ActionReducer<ChatState, Action> = createReducer(
    initialChatState,

    on(ChatActions.friendsFetched, (state: ChatState, payload: { response: ParticipantResponse[] }) => {
      return {
          ...state,
          friendsMetadata: payload.response.map(x => x.metadata),
          friends: payload.response.map(x => x.participant),
      }
    }),
    on(ChatActions.setFullscreenChatActive, (state: ChatState, payload: { active: boolean }) => {
        return {
            ...state,
            fullscreenChatActive: payload.active
        }
    }),
    on(ChatActions.setSelectedFriend, (state: ChatState, payload: { friend: IChatParticipant }) => {
        return {
            ...state,
            selectedFriend: state.selectedFriend?.id == payload.friend.id ? null : payload.friend
        }
    }),

);
