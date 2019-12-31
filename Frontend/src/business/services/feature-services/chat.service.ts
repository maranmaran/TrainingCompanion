import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';


@Injectable({ providedIn: 'root'})
export class ChatService extends BaseService {

    constructor(
      private httpDI: HttpClient
    ) {
      super(httpDI, 'Chat');
    }
}
