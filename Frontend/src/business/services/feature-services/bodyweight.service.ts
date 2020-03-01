import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { CrudService } from '../crud.service';

@Injectable()
export class BodyweightService extends CrudService<Bodyweight> {

  constructor(
    private httpDI: HttpClient
  ) {
    super(httpDI, 'Bodyweight');
  }

}

