import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { MediaService } from 'src/business/services/feature-services/media.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { images } from 'src/ngrx/media/media.selectors';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-user-images',
  templateUrl: './user-images.component.html',
  styleUrls: ['./user-images.component.scss']
})
export class UserImagesComponent implements OnInit, OnDestroy {

  fileTypesToAccept = "image/*";
  mediaType = MediaType.Image;

  images: MediaFile[];
  private subs = new SubSink();

  constructor(
    private mediaService: MediaService,
    private store: Store<AppState>,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.subs.add(this.store
      .select(images)
      .subscribe((images: MediaFile[]) => this.images = images));
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
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
