import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SanitizeHtmlPipe } from './../../../business/pipes/sanitize-html.pipe';
import { ChatEffects } from './../../../ngrx/chat/chat.effects';
import { chatReducer } from './../../../ngrx/chat/chat.reducers';
import { ChatRoutingModule } from './chat-routing.module';
import { ChatBodyComponent } from './components/chat-fullscreen/chat-body/chat-body.component';
import { ChatFullscreenComponent } from './components/chat-fullscreen/chat-fullscreen.component';
import { FriendListComponent } from './components/chat-fullscreen/friend-list/friend-list.component';
import { ChatSmallComponent } from './components/chat-small/chat-small.component';
import { EmojifyPipe } from './pipes/emojify.pipe';
import { LinkfyPipe } from './pipes/linkfy.pipe';


@NgModule({
  imports: [
    ChatRoutingModule,
    HttpClientModule,
    FormsModule,
    SharedModule,
    StoreModule.forFeature('chat', chatReducer),
    EffectsModule.forFeature([ChatEffects]),
  ],
  declarations: [
    ChatSmallComponent,
    ChatFullscreenComponent,
    EmojifyPipe,
    LinkfyPipe,
    ChatBodyComponent,
    FriendListComponent,
  ],
  providers: [
  ],
  exports: [
    ChatSmallComponent,
    SanitizeHtmlPipe,
    MatDialogModule,
    MediaDialogComponent
  ],
  entryComponents: [
  ]
})
export class ChatModule {
}
