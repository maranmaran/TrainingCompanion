import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';


@Injectable({ providedIn: 'root'})
export class ChatService extends BaseService {

    private url = 'Chat/';

    constructor(
    ) {
        super();
    }
}