import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { catchError } from 'rxjs/operators';
import { MediaDialogComponent } from 'src/app/shared/dialogs/media-dialog/media-dialog.component';
import { MediaCarouselComponent } from 'src/app/shared/media/media-carousel/media-carousel.component';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaType } from '../../../server-models/enums/media-type.enum';
import { BaseService } from '../base.service';

@Injectable({providedIn: 'root'})
export class MediaService extends BaseService {

  constructor(
    private httpDI: HttpClient,
    private dialog: MatDialog
  ) {
    super(httpDI, 'Media');
  }


  public getUserMediaByType(userId: string, type: MediaType) {

    return this.http.get<MediaFile[]>(this.url + 'GetUserMediaByType/' + userId + '/' + type)
      .pipe(catchError(this.handleError));
  }

  public uploadMedia(userId: string, file: File, extension: string, type: MediaType) {

    const formData: FormData = new FormData();
    formData.append('userId', userId);
    formData.append('file', file);
    formData.append('extension', extension);
    formData.append('type', type);

    return this.http
      .post<MediaFile>(this.url + 'uploadMedia/', formData)
      .pipe(catchError(this.handleError));
  }

  public enlargeCarousel(media: MediaFile, list: MediaFile[], index: number) {
    this.dialog.open(MediaCarouselComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '41rem',
      autoFocus: false,
      data: { media: list, selectedMedia: media, index },
      panelClass: ['media-carousel-container', "dialog-container"]
    });
  }

  public enlargeSingle(type: MediaType, sourceUrl: string) {
    this.dialog.open(MediaDialogComponent, {
      height: 'auto',
      width: 'auto',
      maxWidth: '58rem',
      maxHeight: '40rem',
      autoFocus: false,
      data: { type, sourceUrl },
      panelClass: ['media-dialog-container', "dialog-container"]
    });
  }

}
