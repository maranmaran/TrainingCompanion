import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SanitizeHtmlPipe } from './../../../business/pipes/sanitize-html.pipe';
import { ChatComponent } from './chat.component';
import { EmojifyPipe } from './pipes/emojify.pipe';
import { LinkfyPipe } from './pipes/linkfy.pipe';


@NgModule({
  imports: [
    HttpClientModule,
    SharedModule,
  ],
  declarations: [
    ChatComponent,
    EmojifyPipe,
    LinkfyPipe,
  ],
  providers: [],
  exports: [
    ChatComponent,
    SanitizeHtmlPipe,
    MatDialogModule,
    MediaDialogComponent
  ],
  entryComponents: [
  ]
})
export class ChatModule {
}
