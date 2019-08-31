import { MediaType } from '../../../server-models/enums/media-type.enum';
import { BaseService } from '../base.service';

import { url } from 'inspector';

import { constructor } from 'assert';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { MediaFile } from 'src/server-models/entities/media-file.model';


export class MediaService extends BaseService {

    private url = '/Media/';

    constructor(
        private http: HttpClient,
    ) {
        super();
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


}
