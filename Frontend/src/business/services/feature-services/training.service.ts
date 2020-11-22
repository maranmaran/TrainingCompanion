import { TrainingDetailsResponse } from './../../../server-models/cqrs/training/training-details.response';
import { ComponentType } from '@angular/cdk/overlay';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { TranslateService } from '@ngx-translate/core';
import * as moment from 'moment';
import { catchError } from 'rxjs/operators';
import { UIService } from 'src/business/services/shared/ui.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { Training } from 'src/server-models/entities/training.model';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { CrudService } from '../crud.service';

@Injectable()
export class TrainingService extends CrudService<Training> {

  constructor(
    private httpDI: HttpClient,
    private UIService: UIService,
    private translateService: TranslateService
  ) {
    super(httpDI, 'Training');
  }

  getDetails(trainingId: string) {
    return this.http.get<TrainingDetailsResponse>(this.url + 'GetTrainingDetails/' + trainingId)
      .pipe(
        catchError(this.handleError)
      );
  }

  getAllByMonth(userId: string, month: number, year: number) {
    return this.http.get<Training[]>(this.url + 'GetAllByMonth/' + userId + '/' + month + '/' + year)
      .pipe(
        catchError(this.handleError)
      );
  }

  getAllByWeek(userId: string, weekStart: Date, weekEnd: Date) {
    return this.http.get<Training[]>(this.url + 'GetAllByWeek/' + userId + '/' + weekStart.toUTCString() + '/' + weekEnd.toUTCString())
      .pipe(
        catchError(this.handleError)
      );
  }

  copy(id: string, date: string) {
    const request = {
      trainingId: id,
      toDate: date
    };

    return this.http.post<Training>(this.url + 'Copy/', request)
      .pipe(
        catchError(this.handleError)
      )
  }

  uploadMedia(userId: string, trainingId: string, file: File, extension: string, type: MediaType) {

    const formData: FormData = new FormData();
    formData.append('userId', userId);
    formData.append('trainingId', trainingId);
    formData.append('file', file);
    formData.append('extension', extension);
    formData.append('type', type);

    return this.http
      .post<MediaFile>('Media/UploadTrainingMedia/', formData)
      .pipe(catchError(this.handleError));
  }


  onAdd(createEditComponent: ComponentType<any>, programDayId: string = null, day: moment.Moment = moment(new Date())) {

    const dialogRef = this.UIService.openDialogFromComponent(createEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '18rem',
      autoFocus: false,
      data: {
        title: this.translateService.instant('TRAINING_LOG.ADD_TRAINING_TITLE', { date: day.format("DD, MMM") }),
        action: CRUD.Create,
        day,
        timeOnly: true,
        programDayId
      },
      panelClass: ["dialog-container"]
    });

    return dialogRef;
  }

}
