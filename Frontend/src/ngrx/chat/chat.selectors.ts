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
