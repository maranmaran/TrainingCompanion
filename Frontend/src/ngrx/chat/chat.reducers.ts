import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import * as _ from 'lodash';
import { Message } from 'src/app/features/chat/models/message.model';
import { IChatParticipant } from './../../app/features/chat/models/chat-participant.model';
import { ParticipantResponse } from './../../app/features/chat/models/participant-response.model';
import { Window } from './../../app/features/chat/models/window.model';
import * as ChatActions from './chat.actions';
import { ChatState, initialChatState } from './chat.state';

export const chatReducer: ActionReducer<ChatState, Action> = createReducer(
    initialChatState,

    on(ChatActions.friendsFetched, (state: ChatState, payload: { response: ParticipantResponse[] }) => {

      let windows = {};
      for(let res of payload.response) {
        windows[res.participant.id] = new Window(res.participant, false, false);
      }

      return {
          ...state,
          windows: windows,
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
            selectedFriend: payload.friend
        }
    }),
    on(ChatActions.allMessagesSeen , (state: ChatState, payload: { friendId: string }) => {
      let friendsMetadata = _.cloneDeep(state.friendsMetadata);
      let friendIdx = state.friends?.findIndex(x => x.id == payload.friendId);

      if(friendIdx != -1)
        friendsMetadata[friendIdx].totalUnreadMessages = 0;

      return {
            ...state,
            friendsMetadata: friendsMetadata
        }
    }),
    on(ChatActions.messageFromAnotherFriend, (state: ChatState, payload: { friend: IChatParticipant }) => {
      let friendsMetadata = _.cloneDeep(state.friendsMetadata);
      let friendIdx = state.friends?.findIndex(x => x.id == payload.friend.id);

      if(friendIdx != -1)
        friendsMetadata[friendIdx].totalUnreadMessages += 1;

      return {
            ...state,
            friendsMetadata: friendsMetadata
        }
    }),
    on(ChatActions.messageHistoryFetched, (state: ChatState, payload: { messages: Message[] }) => {
      return {
            ...state,
            messages: [...payload.messages]
        }
    }),
    // on(ChatActions.pushMessage, (state: ChatState, payload: { message: Message }) => {
    //   return {
    //         ...state,
    //         messages: [...state.messages, payload.message]
    //     }
    // }),

);
