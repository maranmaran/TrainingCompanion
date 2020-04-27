import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrainingProgramUser } from 'src/server-models/entities/training-program.model';
import { CrudService } from '../crud.service';
@Injectable()
export class TrainingProgramUserService extends CrudService<TrainingProgramUser> {
  constructor(private httpDI: HttpClient) {
    super(httpDI, 'TrainingProgramUser');
  }
}
