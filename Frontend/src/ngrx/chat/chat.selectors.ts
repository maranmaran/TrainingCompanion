import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ChatState } from './chat.state';

export const selectChatState = createFeatureSelector<ChatState>("chat");

export const friends = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.friends
);
export const friendsMetadata = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.friendsMetadata
);
export const isFullScreenChatActive = createSelector(
    selectChatState,
    (chatState: ChatState) => chatState.fullscreenChatActive
);
export const selectedFriend = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.selectedFriend
);
export const totalUnreadChatMessages = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.friendsMetadata.reduce((prev, cur) => prev + cur.totalUnreadMessages, 0)
)
export const chatMessages = createSelector(
  selectChatState,
  (chatState: ChatState) => chatState.messages
)
