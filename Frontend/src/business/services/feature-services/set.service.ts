import { HttpClient } from '@angular/common/http';
import { Set } from '../../../server-models/entities/set.model';
import { CrudService } from '../crud.service';
import { Injectable } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';

@Injectable()
export class SetService extends CrudService<Set> {

  constructor(
    private httpDI: HttpClient
  ) {
    super(httpDI, 'Set');
  }
}
