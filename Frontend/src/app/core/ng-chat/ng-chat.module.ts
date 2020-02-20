import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SanitizeHtmlPipe } from 'src/business/pipes/sanitize-html.pipe';
import { NgChatOptionsComponent } from './components/ng-chat-options/ng-chat-options.component';
import { NgChat } from './ng-chat.component';
import { EmojifyPipe } from './pipes/emojify.pipe';
import { GroupMessageDisplayNamePipe } from './pipes/group-message-display-name.pipe';
import { LinkfyPipe } from './pipes/linkfy.pipe';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    MatDialogModule,
    SharedModule,
  ],
  declarations: [
    NgChat,
    EmojifyPipe,
    LinkfyPipe,
    GroupMessageDisplayNamePipe,
    NgChatOptionsComponent,
  ],
  providers: [],
  exports: [
    NgChat,
    SanitizeHtmlPipe,
    MatDialogModule,
    MediaDialogComponent
  ],
  entryComponents: [
  ]
})
export class NgChatModule {
}
