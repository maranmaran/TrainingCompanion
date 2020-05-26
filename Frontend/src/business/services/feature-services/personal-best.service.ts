import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { BaseService } from 'src/business/services/base.service';
import { PersonalBest } from 'src/server-models/entities/personal-best.model';

@Injectable()
export class PersonalBestService extends BaseService {

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

  public create(entity: PersonalBest) {
    return this.http.post<PersonalBest>(`${this.url}Create/`, entity)
      .pipe(
        catchError(this.handleError)
      );
  }

}

