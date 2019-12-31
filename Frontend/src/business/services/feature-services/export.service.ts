import { ExportEntities } from './../../../server-models/enums/export-entities.enum';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../base.service';
import { catchError } from 'rxjs/operators';

export class ExportService extends BaseService {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "Export");
    }

    public export<TRequest, TResponse>(request: TRequest, entity: ExportEntities) {
        return this.http
            .post<TResponse>(this.url + 'Export' + entity + '/', request)
            .pipe(catchError(this.handleError));
    }

}
