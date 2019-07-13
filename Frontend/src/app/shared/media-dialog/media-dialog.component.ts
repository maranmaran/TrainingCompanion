import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MessageType } from 'src/app/core/ng-chat/core/message-type.enum';

@Component({
  selector: 'app-media-dialog',
  templateUrl: './media-dialog.component.html',
  styleUrls: ['./media-dialog.component.scss']
})
export class MediaDialogComponent implements OnInit {

  constructor(
    protected dialogRef: MatDialogRef<MediaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { type: MessageType, sourceUrl: string }) { }

  ngOnInit() {
  }

}
