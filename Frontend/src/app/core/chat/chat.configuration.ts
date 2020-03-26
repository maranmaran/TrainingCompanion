import { ChatParticipantStatus } from './models/enums/chat-participant-status.enum';
import { NgChatTheme } from './models/enums/ng-chat-theme.enum';
import { Localization } from './models/localization.model';

export class ChatConfiguration {

  theme = NgChatTheme.Light;
  fileUploadUrl: string;

  isCollapsed: boolean = localStorage.getItem('chat-collapsed') ? localStorage.getItem('chat-collapsed') as unknown as boolean : false;

  persistWindowsState = true;
  maximizeWindowOnNewMessage = true;

  hideFriendsList = false;
  hideFriendsListOnUnsupportedViewport = true;
  closeFriendList = false;

  pollFriendsList = false;
  pollingInterval = 5000;

  historyEnabled = true;
  historyPageSize = 10;

  emojisEnabled = true;
  linkfyEnabled = true;
  searchEnabled = true;

  showMessageDate = true;
  messageDatePipeFormat = "short";

  localization: Localization = {
    title: "Friends",
    messagePlaceholder: "Type a message",
    searchPlaceholder: "Search",
    browserNotificationTitle: "New message from",
    loadMessageHistoryPlaceholder: "Load older messages",
    statusDescription: {
      online: ChatParticipantStatus.Online,
      busy: ChatParticipantStatus.Busy,
      away: ChatParticipantStatus.Away,
      offline: ChatParticipantStatus.Offline,
      // [key: string]: string;
    },
  };

  // TODO: This might need a better content strategy
  browserNotificationsEnabled = true;
  browserNotificationIconSource = 'https://raw.githubusercontent.com/rpaschoal/ng-chat/master/src/ng-chat/assets/notification.png';
  audioEnabled = true;
  audioSource = 'https://raw.githubusercontent.com/rpaschoal/ng-chat/master/src/ng-chat/assets/notification.wav';
}
