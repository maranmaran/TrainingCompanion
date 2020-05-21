import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { MediaCarouselComponent } from './../../media-carousel/media-carousel.component';

@Component({
  selector: 'app-media-list',
  templateUrl: './media-list.component.html',
  styleUrls: ['./media-list.component.scss']
})
export class MediaListComponent implements OnInit {

  @Input() fileTypesToAccept = 'image/*';
  @Input() mediaList: MediaFile[];
  // @Input() uploadInput: ComponentPortal<UploadInputComponent>;


  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    // console.log(this.uploadInput);
  }

  enlargeCarousel(media: MediaFile, index: number) {

    // handle single image
    // TODO what if we implement comments
    if (this.mediaList.length == 1) {

      if (media.type == MediaType.Image)
        return this.enlargeImage(media);

      if (media.type == MediaType.Video)
        return this.enlargeVideo(media);
    }

    this.dialog.open(MediaCarouselComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '41rem',
      autoFocus: false,
      data: { media: this.mediaList, selectedMedia: media, index },
      panelClass: 'media-carousel-container'
    });
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
