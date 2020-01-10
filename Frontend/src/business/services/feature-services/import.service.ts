import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../base.service';
import { ImportExerciseTypeRequest, ImportTrainingRequest } from './../../../server-models/cqrs/import/request/import.request';
import { ImportResponse } from './../../../server-models/cqrs/import/response/import.response';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';

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

  public getSample(importType: ImportEntities, sampleType: string) {
    return this.http.get(this.url + 'GetSample/' + importType + '/' + sampleType)
      .pipe(catchError(this.handleError));
  }

}
