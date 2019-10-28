import { HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { map, take } from 'rxjs/operators';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { mediaUploaded } from 'src/ngrx/media/media.actions';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaService } from '../../../../business/services/feature-services/media.service';
import { MediaType } from './../../../../server-models/enums/media-type.enum';

@Component({
  selector: 'app-media-uploader2',
  templateUrl: './media-uploader.component.html',
  styleUrls: ['./media-uploader.component.scss']
})
export class MediaUploaderComponent implements OnInit {


  @Input() fileTypesToAccept: string;
  @Input() mediaType: MediaType;
  @Input() mediaExtensionToSaveTo: string;

  private userId: string;

  @ViewChild('uploadInput', {static: false}) uploadInput: ElementRef;

  constructor(
    private mediaService: MediaService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.store
      .select(currentUser)
      .pipe(take(1), map(user => user.id))
      .subscribe(userId => this.userId = userId);
  }

  triggerUploadMediaInput() {
    this.uploadInput.nativeElement.click();
  }

  uploadMedia(files: FileList) {

    if(files.item(0)) {
      this.mediaService.uploadMedia(this.userId, files.item(0), this.mediaExtensionToSaveTo, this.mediaType)
      .pipe(take(1))
      .subscribe(
        (media: MediaFile) => {
          console.log('Media uploaded');
          this.store.dispatch(mediaUploaded({media}));
        },
        (err: HttpErrorResponse) => console.log(err)
      );

      // clear input file because the filepath remains the same
      this.uploadInput.nativeElement.value = '';
    }

    // else cancelled..
  }

}
