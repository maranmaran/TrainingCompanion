import { Injectable } from '@angular/core';
import { BaseStore } from './base.store';
import { MiniChatInfo } from 'src/server-models/cqrs/chat/responses/mini-chat-info';

@Injectable({ providedIn: 'root'})
export class MiniChatStore extends BaseStore<MiniChatInfo> {

    constructor() {
        super(undefined);
    }

  
}
