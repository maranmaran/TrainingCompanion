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
    title: "CHAT.SMALL.TITLE_LABEL",
    messagePlaceholder: "CHAT.SMALL.MESSAGE_PLACEHOLDER",
    searchPlaceholder: "CHAT.SMALL.SEARCH_PLACEHOLDER",
    loadMessageHistoryPlaceholder: "CHAT.SMALL.LOAD_HISTORY",
    statusDescription: {
      online: "CHAT.SMALL.STATUS.ONLINE",
      busy: "CHAT.SMALL.STATUS.BUSY",
      away: "CHAT.SMALL.STATUS.AWAY",
      offline: "CHAT.SMALL.STATUS.OFFLINE",
      // [key: string]: string;
    },
  };

  // TODO: This might need a better content strategy
  audioEnabled = true;
  audioSource = 'https://raw.githubusercontent.com/rpaschoal/ng-chat/master/src/ng-chat/assets/notification.wav';
}
