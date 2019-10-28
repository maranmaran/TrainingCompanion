import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { Training } from 'src/server-models/entities/training.model';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { CrudService } from '../crud.service';

export class TrainingService extends CrudService<Training> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, 'Training');
    }

    public getAllByMonth(userId: string, month: number, year: number) {
        return this.http.get<Training[]>(this.url + 'GetAllByMonth/' + userId + '/' + month + '/' + year)
            .pipe(
                catchError(this.handleError)
            );
    }

    public getAllByWeek(userId: string, weekStart: Date, weekEnd: Date) {
        return this.http.get<Training[]>(this.url + 'GetAll/' + userId + '/' + weekStart + '/' + weekEnd)
            .pipe(
                catchError(this.handleError)
            );
    }

    public uploadMedia(userId: string, trainingId: string, file: File, extension: string, type: MediaType) {

      const formData: FormData = new FormData();
      formData.append('userId', userId);
      formData.append('trainingId', trainingId);
      formData.append('file', file);
      formData.append('extension', extension);
      formData.append('type', type);

      return this.http
        .post<MediaFile>('Media/UploadMedia/', formData)
        .pipe(catchError(this.handleError));
    }

}

