import { HttpClient } from '@angular/common/http';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import { CrudService } from '../crud.service';
import { catchError } from 'rxjs/operators';

export class ExercisePropertyService extends CrudService<ExerciseProperty> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "ExerciseProperty");
    }

    public getAll(userId?: string, typeId?: string) {
        return this.http.get<ExerciseProperty[]>(this.url + 'GetAll/' + userId + '/' + typeId)
            .pipe(
                catchError(this.handleError)
            );
    }
}