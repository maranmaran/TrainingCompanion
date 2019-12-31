import { ImportEntities } from './../../../server-models/enums/import-entities.enum';
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

    public import<TRequest, TResponse>(request: TRequest, entity: ImportEntities) {
        return this.http
            .post<TResponse>(this.url + 'Import' + entity + '/', request)
            .pipe(catchError(this.handleError));
    }

}
