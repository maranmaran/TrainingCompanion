import { BaseService } from './base.service';
import { catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

export abstract class CrudService<T> extends BaseService {
 
    protected url: string;
    protected http: HttpClient;

    constructor(
        http: HttpClient,
        url: string
    ) {
        super();
        this.http = http;
        this.url = url + '/';
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
        return this.http.get(this.url + 'Delete/' + id)
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