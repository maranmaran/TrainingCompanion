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
        return this.http
            .post<ImportResponse>(this.url + 'ImportExerciseType/', request)
            .pipe(catchError(this.handleError));
    }

    public importTraining(request: ImportTrainingRequest) {
      return this.http
          .post<ImportResponse>(this.url + 'ImportTraining/', request)
          .pipe(catchError(this.handleError));
  }

}
