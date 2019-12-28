import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';

export abstract class CrudService<T> extends BaseService {

  constructor(
    http: HttpClient,
    url: string
  ) {
    super(http, url);
  }

  public getAll(id: string) {
    return this.http.get<T[]>(this.url + 'GetAll/' + id)
      .pipe(
        catchError(this.handleError)
      );
  }

  public getOne(id: string) {
    return this.http.get<T>(this.url + 'Get/' + id)
      .pipe(
        catchError(this.handleError)
      );
  }

  public create<TRequest>(request: TRequest) {
    return this.http.post<T>(this.url + 'Create/', request)
      .pipe(
        catchError(this.handleError)
      );
  }

  public update<TRequest, TResponse = T>(request: TRequest) {
    return this.http.post<TResponse>(this.url + 'Update/', request)
      .pipe(
        catchError(this.handleError)
      );
  }

  public updateMany<TRequest, TResponse = T[]>(request: TRequest) {
    return this.http.post<TResponse>(this.url + 'UpdateMany/', request)
      .pipe(
        catchError(this.handleError)
      );
  }

  public delete(id: string) {
    return this.http.delete(this.url + 'Delete/' + id)
      .pipe(
        catchError(this.handleError)
      );
  }

  public deleteMany(ids: string[]) {
    return this.http.post(this.url + 'DeleteMany/', ids)
      .pipe(
        catchError(this.handleError)
      );
  }
}
