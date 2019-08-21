import { CreateExercisePropertyTypeRequest } from 'src/server-models/cqrs/exercise-property-type/requests/create-exercise-property-type.request';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { catchError } from 'rxjs/operators';
import { UpdateExercisePropertyTypeRequest } from 'src/server-models/cqrs/exercise-property-type/requests/update-exercise-property-type.request';

export class ExercisePropertyTypeService extends BaseService {

    private url = '/ExercisePropertyType/';

    constructor(
        private http: HttpClient,
    ) {
        super();
    }

    public getAll(userId: string) {
        return this.http.get<ExercisePropertyType[]>(this.url + 'GetAll/' + userId)
            .pipe(
                catchError(this.handleError)
            );
    }

    public create(request: CreateExercisePropertyTypeRequest) {
        return this.http.post<ExercisePropertyType>(this.url + 'Create/', request)
        .pipe(
            catchError(this.handleError)
        );
    }

    public update(request: UpdateExercisePropertyTypeRequest) {
        return this.http.post<ExercisePropertyType>(this.url + 'Update/', request)
            .pipe(
                catchError(this.handleError)
            );
    }

    public updateMany(types: ExercisePropertyType[]) {
        return this.http.post<ExercisePropertyType[]>(this.url + 'UpdateMany/', types)
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