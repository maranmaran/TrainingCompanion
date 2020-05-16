import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { CrudService } from '../crud.service';
import { Injectable } from "@angular/core";

@Injectable()
export class ExerciseService extends CrudService<Exercise> {

  constructor(
    private httpDI: HttpClient
  ) {
    super(httpDI, 'Exercise');
  }

  public uploadMedia(userId: string, trainingId: string, exerciseId: string, file: File, extension: string, type: MediaType) {

    const formData: FormData = new FormData();
    formData.append('userId', userId);
    formData.append('trainingId', trainingId);
    formData.append('exerciseId', exerciseId);
    formData.append('file', file);
    formData.append('extension', extension);
    formData.append('type', type);

    return this.http
      .post<MediaFile>('Media/UploadExerciseMedia/', formData)
      .pipe(catchError(this.handleError));
  }

  public createWithSets(exercise: Exercise) {
    return this.http.post<Exercise>(`${this.url}CreateFull/`, exercise)
      .pipe(
        catchError(this.handleError)
      );
  }

  public updateWithSets(exercise: Exercise) {
    return this.http.put<Exercise>(`${this.url}UpdateFull/`, exercise)
      .pipe(
        catchError(this.handleError)
      );
  }

}
