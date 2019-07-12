import { Injectable } from '@angular/core';
import { plainToClass } from "class-transformer";
import { MiniChatInfo } from 'src/server-models/cqrs/chat/responses/mini-chat-info';
import { IBaseAdapter } from './base.adapter.interface';

@Injectable({
    providedIn: 'root'
})
export class MiniChatAdapter implements IBaseAdapter<MiniChatInfo> {

    adaptToModel(plainObject: Object): MiniChatInfo {
        return plainToClass(MiniChatInfo, plainObject, {
            excludeExtraneousValues: true
        });
    }

}
