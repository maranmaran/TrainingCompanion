import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import { catchError, finalize } from 'rxjs/operators';
import { ImportJob } from 'src/app/features/export-import/models/import-job.model';
import { addImportJob, removeImportJob, setImportResponse } from 'src/ngrx/export-import/export-import.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { BaseService } from '../base.service';
import { ImportExerciseTypeRequest, ImportTrainingRequest } from './../../../server-models/cqrs/import/import.request';
import { ImportResponse } from './../../../server-models/cqrs/import/import.response';
import { ServerStatusCodes } from './../../../server-models/error/status-codes/server.codes';
import { genericErrorMessage } from './../../utils/messages.utils';
import { NotificationSignalrService } from './notification-signalr.service';

@Injectable()
export class ImportService extends BaseService {

  constructor(
    private httpDI: HttpClient,
    private store: Store<AppState>,
    private notificationSignalRService: NotificationSignalrService
  ) {
    super(httpDI, "Import");
  }

  public importExerciseType(request: ImportExerciseTypeRequest) {

    let job = new ImportJob(ImportEntities.ExerciseTypes);
    this.store.dispatch(addImportJob({ job }));

    const formData: FormData = new FormData();
    for (const prop in request) {
      formData.append(prop, request[prop]);
    }

    this.http
      .post<ImportResponse>(this.url + 'ImportExerciseTypes/', formData)
      .pipe(
        catchError(this.handleError),
        finalize(() => this.store.dispatch(removeImportJob({ id: job.id })) )
      )
      .subscribe(
        (response: ImportResponse) => {
          this.store.dispatch(setImportResponse({ response }));
        },
        err => {
          let response = new ImportResponse();
          response.success = false;
          response.errors = [
            {
              status: ServerStatusCodes.InternalServerError,
              message: err?.message ?? genericErrorMessage()
            }
          ];
          this.store.dispatch(setImportResponse({ response }));
          this.notificationSignalRService.sendNotification(
            NotificationType.ImportFinished,
            "Exercise type import finished with errors. Check import page for more details",
            Guid.EMPTY,
            request.userId
          )
        }
      );
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
    return this.http.get(this.url + 'GetSample/' + importType + '/' + sampleType, { observe: 'response', responseType: 'blob' })
      .pipe(catchError(this.handleError));
  }

}
