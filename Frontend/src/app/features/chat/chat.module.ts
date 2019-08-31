import { ChatRoutingModule } from './chat-routing.module';
import { ChatService } from 'src/business/services/feature-services/chat.service';
import { NgModule } from '@angular/core';
import { ChatHomeComponent } from './chat-home/chat-home.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
    imports: [
        ChatRoutingModule,
        SharedModule
    ],
    declarations: [
        ChatHomeComponent
    ],
    exports: [
    ],
    providers: [
        ChatService,
    ],
    entryComponents: [
    ]
})
export class ChatModule { }
