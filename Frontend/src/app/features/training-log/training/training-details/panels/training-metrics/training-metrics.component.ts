import { Component, OnDestroy, OnInit } from '@angular/core';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ChartConfiguration } from 'chart.js';
import { take } from 'rxjs/operators';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { Theme } from 'src/business/shared/theme.enum';
import { AppState } from 'src/ngrx/app/app.state';
import { settingsUpdated } from 'src/ngrx/auth/auth.actions';
import { currentUserId, userSetting } from 'src/ngrx/auth/auth.selectors';
import { selectedTrainingId } from 'src/ngrx/training-log/training/training.selectors';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/response/get-training-metrics.response';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { SubSink } from 'subsink';
import { getNumberOfLiftsChartConfig } from './chart-configs/number-of-lifts.chart-config';
import { getTotalVolumeIntensityChartConfig } from './chart-configs/volume-intensity.chart-config';
import { getVolumeSplitChartConfig } from './chart-configs/volume-split.chart-config';

@Component({
  selector: 'app-training-metrics',
  templateUrl: './training-metrics.component.html',
  styleUrls: ['./training-metrics.component.scss']
})
export class TrainingMetricsComponent implements OnInit, OnDestroy {

  totalVolumeChart: ChartConfiguration[];
  volumeSplitChart: ChartConfiguration[];

  numberOfLiftsChart: ChartConfiguration[];
  weightedAverageIntensityChart: ChartConfiguration[];

  // max heavy medium light deload
  // total and per exercise
  // zoneOfIntensity: ChartConfiguration; // 5

  _subs = new SubSink();

  _theme: Theme;
  _unitSystem: UnitSystem;
  _trainingId: string;
  _userId: string;
  _metricsData: GetTrainingMetricsResponse;

  constructor(
    private store: Store<AppState>,
    private reportService: ReportService,
    private actions$: Actions
  ) { }

  ngOnInit() {

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);
    this.store.select(userSetting).pipe(take(1)).subscribe(setting => this._unitSystem = setting.unitSystem);

    this._subs.add(
      this.store.select(activeTheme).subscribe(theme => {
        this._theme = theme;
        this._metricsData && this.getChartConfigs(this._metricsData);
      }),
      this.actions$.pipe(ofType(settingsUpdated)).subscribe(setting => {
        this._unitSystem = setting.unitSystem;
        this._trainingId && this.loadTrainingMetrics(this._trainingId);
      }),
      this.store.select(selectedTrainingId).subscribe((id: string) => {
        this._trainingId = id;
        this.loadTrainingMetrics(id);
      })
    )
  }

  loadTrainingMetrics(trainingId: string) {
    this.reportService.getTrainingMetrics(trainingId, this._userId)
      .subscribe(
        (data: GetTrainingMetricsResponse) => {
          this._metricsData = data;
          this.getChartConfigs(data);
        },
        err => console.log(err)
      )
  }

  getChartConfigs(data: GetTrainingMetricsResponse) {

    const setting = { theme: this._theme, unitSystem: this._unitSystem };

    this.volumeSplitChart = [getVolumeSplitChartConfig(setting,
                                              data.volumeSplitChartData.dataSets[0].data,
                                              data.volumeSplitChartData.labels
                                              )];

    this.totalVolumeChart = [getTotalVolumeIntensityChartConfig(setting, data.totalVolumeChartData)];


    this.numberOfLiftsChart = [getNumberOfLiftsChartConfig(setting,
                                                       data.numberOfLiftsChartData.dataSets[0].data,
                                                       data.numberOfLiftsChartData.labels
                                                       )];


    // this.zoneOfIntensity = getPolarAreaChart(this._theme, data.relativeZoneOfIntensityChartData.dataSets[0].data, data.relativeZoneOfIntensityChartData.labels);
  }

  ngOnDestroy(): void {
    this._subs.unsubscribe();
  }

}
