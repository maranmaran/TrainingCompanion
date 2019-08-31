import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { CreateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/requests/create-exercise-type.request';
import { UpdateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/requests/update-exercise-type.request';
import { BaseService } from '../base.service';
import { CrudService } from '../crud.service';

export class ExerciseTypeService extends CrudService<ExerciseType> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "ExerciseType");
    }
}