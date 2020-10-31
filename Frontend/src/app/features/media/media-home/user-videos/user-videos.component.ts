import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { MediaService } from 'src/business/services/feature-services/media.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { videos } from 'src/ngrx/media/media.selectors';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-user-videos',
  templateUrl: './user-videos.component.html',
  styleUrls: ['./user-videos.component.scss']
})
export class UserVideosComponent implements OnInit, OnDestroy {

  fileTypesToAccept = "video/*";
  mediaType = MediaType.Video;

  videos: MediaFile[];
  private subs = new SubSink();

  constructor(
    private mediaService: MediaService,
    private store: Store<AppState>,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.subs.add(this.store
      .select(videos)
      .subscribe((videos: MediaFile[]) => this.videos = videos));
  }


  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  enlargeVideo(video: MediaFile) {

    this.dialog.open(MediaDialogComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '40rem',
      autoFocus: false,
      data: { type: video.type, sourceUrl: video.downloadUrl },
      panelClass: ['media-dialog-container', "dialog-container"]
    });

  }



}
