import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SanitizeHtmlPipe } from './../../../business/pipes/sanitize-html.pipe';
import { ChatRoutingModule } from './chat-routing.module';
import { ChatFullscreenComponent } from './components/chat-fullscreen/chat-fullscreen.component';
import { ChatSmallComponent } from './components/chat-small/chat-small.component';
import { EmojifyPipe } from './pipes/emojify.pipe';
import { LinkfyPipe } from './pipes/linkfy.pipe';


@NgModule({
  imports: [
    ChatRoutingModule,
    HttpClientModule,
    FormsModule,
    SharedModule,
  ],
  declarations: [
    ChatSmallComponent,
    ChatFullscreenComponent,
    EmojifyPipe,
    LinkfyPipe,
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
