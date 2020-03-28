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

  // Asserts if a user avatar is visible in a chat cluster
  isAvatarVisible(userId: string, messages: Message[], message: Message, index: number): boolean {

    // if i'm sending the message... don't show my avatar to me
    if(message.fromId == userId) return false;

    // ========= other person is only relevant for avatar showing ==========

    // last message
    if(index >= messages?.length) return true;

    // if I sent more messages... i want avatar to show on last one
    // so if my streak is done... ie next message is from other user.. show avatar
    if(messages[index + 1].fromId != message.fromId)
      return true;

    // otherwise don't
    return false
  }
}

