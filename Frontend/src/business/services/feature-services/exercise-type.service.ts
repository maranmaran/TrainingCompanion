import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { PagedList } from 'src/server-models/shared/paged-list.model';
import { CrudService } from '../crud.service';
import { Injectable } from "@angular/core";

@Injectable()
export class ExerciseTypeService extends CrudService<ExerciseType> {

    constructor(
      private httpDI: HttpClient
    ) {
      super(httpDI, 'ExerciseType');
    }

    public getPaged(id: string, paginationModel: PagingModel) {

      var request = {
        userId: id,
        paginationModel
      }

      return this.http.post<PagedList<ExerciseType>>(this.url + 'GetPaged/', request)
        .pipe(
          catchError(this.handleError)
        );

    }

}
