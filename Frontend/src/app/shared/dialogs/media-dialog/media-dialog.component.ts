import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MessageType } from 'src/app/features/chat/models/enums/message-type.enum';
import { MediaType } from 'src/server-models/enums/media-type.enum';

@Component({
  selector: 'app-media-dialog',
  templateUrl: './media-dialog.component.html',
  styleUrls: ['./media-dialog.component.scss']
})
export class MediaDialogComponent implements OnInit {

  constructor(
    private dialogRef: MatDialogRef<MediaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { type: MessageType | MediaType, sourceUrl: string }) { }

  ngOnInit() {
  }

}
