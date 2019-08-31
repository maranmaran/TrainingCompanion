import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../base.service';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { CrudService } from '../crud.service';
import { Training } from 'src/server-models/entities/training.model';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/requests/create-training.request';

export class ExerciseService extends CrudService<Exercise> {
   
    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "Exercise");
    }

}