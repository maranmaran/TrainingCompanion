import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ChatConfiguration } from 'src/app/features/chat/chat.configuration';
import { BaseService } from '../base.service';
import { ChatTheme } from './../../../app/features/chat/models/enums/chat-theme.enum';


@Injectable({ providedIn: 'root'})
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
}

