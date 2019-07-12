import { throwError, Observable } from 'rxjs';

export abstract class BaseService {

    public handleError(err): Observable<Error> {
        console.log('API error:', err.message);
        return throwError(err);
    }

}