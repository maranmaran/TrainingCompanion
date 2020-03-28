import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ChatConfiguration } from 'src/app/features/chat/chat.configuration';
import { MessageType } from 'src/app/features/chat/models/enums/message-type.enum';
import { Message } from 'src/app/features/chat/models/message.model';
import { BaseService } from '../base.service';
import { ChatTheme } from './../../../app/features/chat/models/enums/chat-theme.enum';


@Injectable({ providedIn: 'root' })
export class ChatService extends BaseService {

  constructor(
    private httpDI: HttpClient
  ) {
    super(httpDI, 'Chat');
  }

  getChatConfiguration(theme: ChatTheme) {
    const chatConfig = new ChatConfiguration();
    chatConfig.fileUploadUrl = `${this.url}UploadChatFile`;
    chatConfig.theme = theme;
    return chatConfig;
  }

  assertMessageType(message: Message): void {
    // Always fallback to "Text" messages to avoid rendenring issues
    if (!message.type) {
      message.type = MessageType.Text;
    }
  }

  markMessagesAsRead(messages: Message[]): void {
    let currentDate = new Date();

    messages.forEach((msg) => {
      msg.dateSeen = currentDate;
    });
  }
}

