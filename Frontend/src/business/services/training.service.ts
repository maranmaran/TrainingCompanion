import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';
import { Training } from 'src/server-models/entities/training.model';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/requests/create-training.request';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/requests/update-training.request';

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