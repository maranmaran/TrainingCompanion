import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaDialogComponent } from '../../media-dialog/media-dialog.component';

@Component({
  selector: 'app-media-list',
  templateUrl: './media-list.component.html',
  styleUrls: ['./media-list.component.scss']
})
export class MediaListComponent implements OnInit {

  @Input() fileTypesToAccept = 'image/*';
  @Input() mediaList: MediaFile[];

  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit() {
  }

  enlargeVideo(video: MediaFile) {
    this.dialog.open(MediaDialogComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '40rem',
      autoFocus: false,
      data: { type: video.type, sourceUrl: video.downloadUrl },
      panelClass: 'media-dialog-container'
    });
  }

  enlargeImage(image: MediaFile) {
    this.dialog.open(MediaDialogComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '40rem',
      autoFocus: false,
      data: { type: image.type, sourceUrl: image.downloadUrl },
      panelClass: 'media-dialog-container'
    });
}

}
