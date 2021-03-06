import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { ExportExerciseTypeRequest, ExportTrainingRequest } from 'src/server-models/cqrs/export/export.request';
import { BaseService } from '../base.service';
import { ExportResponse } from './../../../server-models/cqrs/export/export.response';

@Injectable()
export class ExportService extends BaseService {

  constructor(
    private httpDI: HttpClient,
  ) {
    super(httpDI, "Export");
  }

  public exportTraining(request: ExportTrainingRequest) {
    return this.http
      .post<ExportResponse>(this.url + 'ExportTraining/', request)
      .pipe(catchError(this.handleError));
  }

  public exportExerciseType(request: ExportExerciseTypeRequest) {
    return this.http
      .post<ExportResponse>(this.url + 'ExportExerciseType/', request)
      .pipe(catchError(this.handleError));
  }

}
