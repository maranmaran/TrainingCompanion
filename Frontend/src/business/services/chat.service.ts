import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MiniChatInfo } from 'src/server-models/cqrs/chat/responses/mini-chat-info';
import { MiniChatAdapter } from '../adapters/mini-chat.adapter';
import { BaseService } from './base.service';


@Injectable({ providedIn: 'root'})
export class ChatService extends BaseService {

    private url = '/Chat/';

    constructor(
    ) {
        super();
    }
}