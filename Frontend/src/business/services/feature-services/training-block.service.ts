import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CrudService } from '../crud.service';
import { TrainingBlock } from './../../../server-models/entities/training-program.model';

@Injectable()
export class TrainingBlockService extends CrudService<TrainingBlock> {

    constructor(
        private httpDI: HttpClient
    ) {
        super(httpDI, 'TrainingBlock');
    }

}
