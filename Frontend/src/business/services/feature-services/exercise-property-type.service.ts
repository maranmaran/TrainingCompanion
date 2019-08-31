import { CreateExercisePropertyTypeRequest } from 'src/server-models/cqrs/exercise-property-type/requests/create-exercise-property-type.request';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../base.service';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { catchError } from 'rxjs/operators';
import { UpdateExercisePropertyTypeRequest } from 'src/server-models/cqrs/exercise-property-type/requests/update-exercise-property-type.request';
import { CrudService } from '../crud.service';

export class ExercisePropertyTypeService extends CrudService<ExercisePropertyType> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "ExercisePropertyType");
    }

}