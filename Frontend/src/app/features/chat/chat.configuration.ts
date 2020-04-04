import { ChatTheme } from './models/enums/chat-theme.enum';
import { Localization } from './models/localization.model';

export class ChatConfiguration {

  constructor(config: Partial<ChatConfiguration>) {
    Object.assign(this, config);
  }

  theme = ChatTheme.Light;
  fileUploadUrl: string;
  isCollapsed = localStorage.getItem('chat-collapsed') ? localStorage.getItem('chat-collapsed') as unknown as boolean : false;
  historyPageSize = 10;
  messageDatePipeFormat = "short";

  localization: Localization = {
    title: "Friends",
    messagePlaceholder: "Type a message",
    searchPlaceholder: "Search",
    loadMessageHistoryPlaceholder: "Load older messages",
    statusDescription: {
      online: "Online",
      busy: "Busy",
      away: "Away",
      offline: "Offline",
      // [key: string]: string;
    },
  };

  // TODO: This might need a better content strategy
  audioEnabled = true;
  audioSource = 'https://raw.githubusercontent.com/rpaschoal/ng-chat/master/src/ng-chat/assets/notification.wav';
}
