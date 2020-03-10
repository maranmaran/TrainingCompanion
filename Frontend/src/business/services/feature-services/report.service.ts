import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { GetBodyweightReportResponse } from 'src/server-models/cqrs/report/get-bodyweight-report.response';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/get-training-metrics.response';
import { BaseService } from '../base.service';

@Injectable()
export class ReportService extends BaseService {

  constructor(
    private httpDI: HttpClient,
    ) {
    super(httpDI, 'Report');
  }

  getTrainingMetrics(trainingId: string, userId: string) {
    return this.http.get<GetTrainingMetricsResponse>(this.url + 'GetTrainingMetrics/' + trainingId + '/' + userId)
        .pipe(
            catchError(this.handleError)
        );
  }

  getBodyweightReport(userId: string, dateFrom: Date, dateTo: Date) {
    return this.http.get<GetBodyweightReportResponse>(this.url + 'GetBodyweightReport/' + userId + '/' + dateFrom.toISOString() + '/' + dateTo.toISOString())
        .pipe(
            catchError(this.handleError)
        );
  }

}
