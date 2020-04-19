import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CrudService } from '../crud.service';
import { TrainingBlockDay } from './../../../server-models/entities/training-program.model';

@Injectable()
export class TrainingBlockDayService extends CrudService<TrainingBlockDay> {

    constructor(
        private httpDI: HttpClient
    ) {
        super(httpDI, 'TrainingBlockDay');
    }

}
