import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../base.service';
import { ImportExerciseTypeRequest, ImportTrainingRequest } from './../../../server-models/cqrs/import/request/import.request';
import { ImportResponse } from './../../../server-models/cqrs/import/response/import.response';

export class ImportService extends BaseService {

  constructor(
    private httpDI: HttpClient,
  ) {
    super(httpDI, "Import");
  }

  public importExerciseType(request: ImportExerciseTypeRequest) {

    const formData: FormData = new FormData();
    for (const prop in request) {
      formData.append(prop, request[prop]);
    }

    return this.http
      .post<ImportResponse>(this.url + 'ImportExerciseTypes/', formData)
      .pipe(catchError(this.handleError));
  }

  public importTraining(request: ImportTrainingRequest) {

    const formData: FormData = new FormData();
    for (const prop in request) {
      formData.append('prop', request[prop]);
    }

    return this.http
      .post<ImportResponse>(this.url + 'ImportTraining/', formData)
      .pipe(catchError(this.handleError));
  }

}
