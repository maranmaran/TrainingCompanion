import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { GetBodyweightReportResponse } from 'src/server-models/cqrs/report/get-bodyweight-report.response';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/get-training-metrics.response';
import { BaseService } from '../base.service';
import { ChartData } from './../../../server-models/entities/chart-data';

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

  getDashboardVolumeReport(userId: string, exerciseTypeIds: string[], dateFrom: Date, dateTo: Date) {

    const params = {
      userId,
      exerciseTypeIds,
      dateFrom: dateFrom,
      dateTo: dateTo
    };

    return this.http.post<ChartData<number, Date>>(this.url + 'GetDashboardVolumeReport/', params)
      .pipe(
        catchError(this.handleError)
      );
  }

  getDashboardMaxReport(userId: string, exerciseTypeIds: string[], dateFrom: Date, dateTo: Date) {
    const params = {
      userId,
      exerciseTypeIds,
      dateFrom: dateFrom,
      dateTo: dateTo
    };

    return this.http.post<ChartData<number, Date>>(this.url + 'GetDashboardMaxReport/', params)
      .pipe(
        catchError(this.handleError)
      );
  }

}
