import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { CreateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/requests/create-exercise-type.request';
import { UpdateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/requests/update-exercise-type.request';

export class ExerciseTypeService extends BaseService {

    private url = '/ExerciseType/';

    constructor(
        private http: HttpClient,
    ) {
        super();
    }

    public getAll(userId: string) {
        return this.http.get<ExerciseType[]>(this.url + 'GetAll/' + userId)
            .pipe(
                catchError(this.handleError)
            );
    }

    public create(request: CreateExerciseTypeRequest) {
        return this.http.post<ExerciseType>(this.url + 'Create/', request)
        .pipe(
            catchError(this.handleError)
        );
    }

    public update(request: UpdateExerciseTypeRequest) {
        return this.http.post<ExerciseType>(this.url + 'Update/', request)
            .pipe(
                catchError(this.handleError)
            );
    }

    public updateMany(types: ExerciseType[]) {
        return this.http.post<ExerciseType[]>(this.url + 'UpdateMany/', types)
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