import { HttpClient } from '@angular/common/http';
import { Store } from '@ngrx/store';
import { catchError } from 'rxjs/operators';
import { ImportJob } from 'src/app/features/export-import/models/import-job.model';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { AppState } from 'src/ngrx/app/app.state';
import { addImportJob, removeImportJob } from 'src/ngrx/export-import/export-import.actions';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { BaseService } from '../base.service';
import { ImportExerciseTypeRequest, ImportTrainingRequest } from './../../../server-models/cqrs/import/request/import.request';
import { ImportResponse } from './../../../server-models/cqrs/import/response/import.response';

export class ImportService extends BaseService {

  constructor(
    private httpDI: HttpClient,
    private store: Store<AppState>
  ) {
    super(httpDI, "Import");
  }

  public importExerciseType(request: ImportExerciseTypeRequest) {

    const formData: FormData = new FormData();
    for (const prop in request) {
      formData.append(prop, request[prop]);
    }

    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.None }))

    var job = new ImportJob(ImportEntities.ExerciseTypes);
    this.store.dispatch(addImportJob({job}));

    this.http
      .post<ImportResponse>(this.url + 'ImportExerciseTypes/', formData)
      .pipe(catchError(this.handleError))
      .subscribe(
        (response: ImportResponse) => {
          console.log(response);
        },
        err => {
          console.log(err);
        },
        () => {
          this.store.dispatch(removeImportJob({ id: job.id }));
          this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.MainAppScreen }))
        });
  }

  public importTraining(request: ImportTrainingRequest) {

    const formData: FormData = new FormData();
    for (const prop in request) {
      formData.append('prop', request[prop]);
    }

    return this.http
      .post<ImportResponse>(this.url + 'ImportTraining/', formData)
      .pipe(catchError(this.handleError));
  }

  public getSample(importType: ImportEntities, sampleType: string) {
    return this.http.get(this.url + 'GetSample/' + importType + '/' + sampleType, { responseType: 'blob' })
      .pipe(catchError(this.handleError));
  }

}
