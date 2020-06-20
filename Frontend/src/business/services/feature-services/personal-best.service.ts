import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { PersonalBest } from 'src/server-models/entities/personal-best.model';
import { CrudService } from '../crud.service';

@Injectable()
export class PersonalBestService extends CrudService<PersonalBest> {

  constructor(
    private httpDI: HttpClient
  ) {
    super(httpDI, 'PersonalBest');
  }

  public getAll(id: string, lowerRepRange: number = null, upperRepRange: number = null) {
    let url = `${this.url}GetAll/${id}`;

    if(lowerRepRange && upperRepRange)
      url += `/${lowerRepRange}/${upperRepRange}`;

    return this.http.get<PersonalBest[]>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  public get(id: string) {
    return this.http.get<PersonalBest[]>(`${this.url}Get/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

}

