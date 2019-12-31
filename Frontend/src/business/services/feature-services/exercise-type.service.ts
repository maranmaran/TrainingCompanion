import { HttpClient } from '@angular/common/http';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { CrudService } from '../crud.service';

export class ExerciseTypeService extends CrudService<ExerciseType> {

    constructor(
      private httpDI: HttpClient
    ) {
      super(httpDI, 'ExerciseType');
    }
}
