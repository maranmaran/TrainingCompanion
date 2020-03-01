import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PersonalBest } from 'src/server-models/entities/personal-best.model';
import { CrudService } from '../crud.service';

@Injectable()
export class PersonalBestService extends CrudService<PersonalBest> {

  constructor(
    private httpDI: HttpClient
  ) {
    super(httpDI, 'PersonalBest');
  }

}

