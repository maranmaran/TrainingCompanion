import { HttpErrorResponse } from '@angular/common/http';
import { MediaService } from './../../../../business/services/media.service';
import { MediaType } from './../../../../server-models/enums/media-type.enum';
import { Component, OnInit, ViewChild, ElementRef, Input, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { map, take } from 'rxjs/operators';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { mediaUploaded } from 'src/ngrx/media/media.actions';
import { images } from 'src/ngrx/media/media.selectors';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-media-uploader',
  templateUrl: './media-uploader.component.html',
  styleUrls: ['./media-uploader.component.scss']
})
export class MediaUploaderComponent implements OnInit {
  

  @Input() fileTypesToAccept: string;
  @Input() mediaType: MediaType; 
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
    this.mediaService.uploadMedia(this.userId, files.item(0), "jpg", MediaType.Image)
      .pipe(take(1))
      .subscribe(
        (media: MediaFile) => {
          this.store.dispatch(mediaUploaded({media}));
        },
        (err: HttpErrorResponse) => console.log(err)
      );
  }

}
