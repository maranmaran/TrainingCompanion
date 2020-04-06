import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as _ from 'lodash';
import { ChatState } from './chat.state';

export const selectChatState = createFeatureSelector<ChatState>("chat");

export const isFullScreenChatActive = createSelector(
    selectChatState,
    (chatState: ChatState) => chatState.fullscreenChatActive
);

export const friends = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.friends
);
export const friendsMetadata = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.friendsMetadata
);

export const selectedFriend = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.selectedFriend
);
export const selectedFriendWindow = createSelector(
  selectChatState,
  (chatState: ChatState) => _.cloneDeep(chatState.windows[chatState.selectedFriend.id])
);



export const totalUnreadChatMessages = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.friendsMetadata.reduce((prev, cur) => prev + cur.totalUnreadMessages, 0)
)
export const totalUnreadChatMessagesForFriend = createSelector(
  selectChatState,
  (chatState: ChatState, id: string) => {
    let friendIdx = chatState.friends.findIndex(x => x.id == id);
    return chatState.friendsMetadata[friendIdx].totalUnreadMessages;
  }
)
export const totalUnreadChatMessagesByFriend = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.friendsMetadata.map(x => x.totalUnreadMessages)
)
