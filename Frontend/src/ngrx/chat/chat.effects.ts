import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { AppState } from '../global-setup.ngrx';


@Injectable()
export class ChatEffects {

    constructor(
        private store: Store<AppState>,
        private actions$: Actions,
        private chatService: ChatService
    ) { }

}
