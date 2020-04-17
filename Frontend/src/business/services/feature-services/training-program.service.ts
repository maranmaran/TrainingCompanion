import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { CrudService } from '../crud.service';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';

@Injectable()
export class TrainingProgramService extends CrudService<TrainingProgram> {

    constructor(
        private httpDI: HttpClient
    ) {
        super(httpDI, 'TrainingProgram');
    }

}
