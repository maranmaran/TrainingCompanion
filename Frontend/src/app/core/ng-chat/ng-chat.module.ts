import { SharedModule } from 'src/app/shared/shared.module';
import { MediaDialogComponent } from './../../shared/media-dialog/media-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { NgChat } from './ng-chat.component';
import { EmojifyPipe } from './pipes/emojify.pipe';
import { LinkfyPipe } from './pipes/linkfy.pipe';
import { GroupMessageDisplayNamePipe } from './pipes/group-message-display-name.pipe';
import { NgChatOptionsComponent } from './components/ng-chat-options/ng-chat-options.component';
import { SanitizeHtmlPipe } from 'src/business/pipes/sanitize-html.pipe';
import { MaterialModule } from 'src/app/shared/angular-material.module';

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
