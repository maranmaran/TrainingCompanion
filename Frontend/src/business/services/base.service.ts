import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

export abstract class BaseService {

  url: string;
  http: HttpClient;

  constructor(
    http: HttpClient,
    url: string
  ) {
    this.url = url + '/';
    this.http = http;
  }

  public handleError(err): Observable<Error> {
    console.log('API error:', err.message);
    return throwError(err);
  }

}
