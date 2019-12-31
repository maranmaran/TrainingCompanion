import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../base.service';
import { ImportRequest } from './../../../server-models/cqrs/import/request/import.request';
import { ImportResponse } from './../../../server-models/cqrs/import/response/import.response';

export class ImportService extends BaseService {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "Import");
    }


    public import(userId: string, file: File) {

      var request = new ImportRequest();
      request.userId = userId;
      request.file = file;

      return this.http
        .post<ImportResponse>(this.url + 'ImportExerciseTypes/', request)
        .pipe(catchError(this.handleError));
    }

}

