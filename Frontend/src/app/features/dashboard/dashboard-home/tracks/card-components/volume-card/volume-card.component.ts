import { Component, Input, OnInit } from '@angular/core';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { ChartConfiguration } from 'chart.js';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ChartData } from 'src/server-models/entities/chart-data';
import { ExerciseTypeService } from './../../../../../../../business/services/feature-services/exercise-type.service';
import { currentUserId } from './../../../../../../../ngrx/auth/auth.selectors';
import { CardParameters } from './../models/card-params';
import { GetVolumeCardChartConfig } from './volume-card-chart.config';

@Component({
  selector: 'app-volume-card',
  templateUrl: './volume-card.component.html',
  providers: [ExerciseTypeService, ReportService,
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] }]
})
export class VolumeCardComponent implements OnInit {

  // relevant things for dashboard card
  // which needs to remember user input
  // and also use fixed date spans
  @Input() cardId: string;
  @Input() jsonParams: string;

  title = this.translate.instant('DASHBOARD.CARDS.VOLUME_CARD_TITLE');
  config: ChartConfiguration[];
  params: CardParameters;

  _userId: string;
  _chartData: ChartData<number, Date>; // actual data

  constructor(
    private store: Store<AppState>,
    private reportService: ReportService,
    private translate: TranslateService
  ) { }

  ngOnInit() {
    // get props
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);

    this.params = new CardParameters(this.jsonParams);
  }

  /** Fetches metric data from server */
  onFetchData(params: CardParameters) {
    this.reportService
      .getDashboardVolumeReport(this._userId, params.exerciseTypes.map(x => x.id), params.dateFrom, params.dateTo)
      .pipe(take(1))
      .subscribe(
        (data: ChartData<number, Date>) => this.getChartConfigs(data, params),
        // err => this.error = true
      )
  }

  onFetchConfig(params: CardParameters) {
    this.getChartConfigs(this._chartData, params);
  }

  /** Gets all ChartJS configs */
  getChartConfigs(chartData: ChartData<number, Date>, params: CardParameters) {
    this._chartData = chartData;
    if (!this._chartData)
      return;

    // needed to create config for chat
    const labels = chartData.labels.map(date => moment(date).format('L'));

    this.config = [
      GetVolumeCardChartConfig(params.settings, chartData.dataSets, labels),
    ];
  }
}
