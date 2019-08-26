import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';
import { Training } from 'src/server-models/entities/training.model';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/requests/update-training.request';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/requests/create-training.request';

export class TrainingService extends BaseService {

    private url = '/Training/';

    constructor(
        private http: HttpClient,
    ) {
        super();
    }

    public getAll(userId: string) {
        return this.http.get<Training[]>(this.url + 'GetAll/' + userId)
            .pipe(
                catchError(this.handleError)
            );
    }

    public getAllByMonth(userId: string, month: number, year: number) {
        return this.http.get<Training[]>(this.url + 'GetAllByMonth/' + userId + '/' + month + '/' + year)
            .pipe(
                catchError(this.handleError)
            );
    }

    public getAllByWeek(userId: string, weekStart: Date, weekEnd: Date) {
        return this.http.get<Training[]>(this.url + 'GetAll/' + userId + '/' + weekStart + '/' + weekEnd)
            .pipe(
                catchError(this.handleError)
            );
    }

    public create(request: CreateTrainingRequest) {
        return this.http.post<Training>(this.url + 'Create/', request)
        .pipe(
            catchError(this.handleError)
        );
    }

    public update(request: UpdateTrainingRequest) {
        return this.http.post<Training>(this.url + 'Update/', request)
            .pipe(
                catchError(this.handleError)
            );
    }

    public updateMany(types: Training[]) {
        return this.http.post<Training[]>(this.url + 'UpdateMany/', types)
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
}