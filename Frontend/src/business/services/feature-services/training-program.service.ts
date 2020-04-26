import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { CrudService } from '../crud.service';

@Injectable()
export class TrainingProgramService extends CrudService<TrainingProgram> {

    constructor(
        private httpDI: HttpClient
    ) {
        super(httpDI, 'TrainingProgram');
    }

}




