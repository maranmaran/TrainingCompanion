import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/response/get-training-metrics.response';
import { BaseService } from '../base.service';

@Injectable()
export class ReportService extends BaseService {

  constructor(
    private httpDI: HttpClient,
    ) {
    super(httpDI, 'Report');
  }

  public getTrainingMetrics(trainingId: string) {
    return this.http.get<GetTrainingMetricsResponse>(this.url + 'GetTrainingMetrics/' + trainingId)
        .pipe(
            catchError(this.handleError)
        );
}

}
