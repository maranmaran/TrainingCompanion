import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-move-copy-dialog',
  templateUrl: './move-copy-dialog.component.html',
  styleUrls: ['./move-copy-dialog.component.scss']
})
export class MoveCopyDialogComponent implements OnInit {

  constructor(
    private dialogRef: MatDialogRef<MoveCopyDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
    }
  ) { }

  ngOnInit(): void {
  }

  onClose(reason?: 'MOVE' | 'COPY' ) {
    return this.dialogRef.close(reason);
  }

}
