import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ChartConfiguration } from 'chart.js';
import { getBarChartConfig, getHorizontalStackedChartConfig, getPieChartConfig } from 'src/app/shared/charts/training-chart-config.factory';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { AppState } from 'src/ngrx/app/app.state';
import { selectedTrainingId } from 'src/ngrx/training-log/training/training.selectors';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/response/get-training-metrics.response';
import { SubSink } from 'subsink';
import { Theme } from './../../../../../../../business/shared/theme.enum';
import { activeTheme } from './../../../../../../../ngrx/user-interface/ui.selectors';

@Component({
  selector: 'app-training-metrics',
  templateUrl: './training-metrics.component.html',
  styleUrls: ['./training-metrics.component.scss']
})
export class TrainingMetricsComponent implements OnInit, OnDestroy {

  totalVolumeChart: ChartConfiguration; // 1
  volumeSplitChart: ChartConfiguration // 2

  numberOfLiftsChart: ChartConfiguration; // 3
  weightedAverageIntensityChart: ChartConfiguration; // 4

  // max heavy medium light deload
  // total and per exercise
  // zoneOfIntensity: ChartConfiguration; // 5

  _subs = new SubSink();
  _theme: Theme;
  _metricsData: GetTrainingMetricsResponse;

  constructor(
    private store: Store<AppState>,
    private reportService: ReportService
  ) { }

  ngOnInit() {
    this._subs.add(
      this.store.select(activeTheme).subscribe(theme => {
        this._theme = theme;
        this._metricsData && this.getChartConfigs(this._metricsData);
      }),
      this.store.select(selectedTrainingId).subscribe((id: string) => {
        this.loadTrainingMetrics(id);
      })
    )
  }

  loadTrainingMetrics(trainingId: string) {
    this.reportService.getTrainingMetrics(trainingId)
      .subscribe(
        (data: GetTrainingMetricsResponse) => {
          this._metricsData = data;
          this.getChartConfigs(data);
        },
        err => console.log(err)
      )
  }

  getChartConfigs(data: GetTrainingMetricsResponse) {

    this.volumeSplitChart = getPieChartConfig(this._theme,
                                              data.volumeSplitChartData.dataSets[0].data,
                                              data.volumeSplitChartData.labels
                                              );


    this.totalVolumeChart = getBarChartConfig(this._theme,
                                              data.totalVolumeChartData.dataSets[0].data,
                                              data.totalVolumeChartData.labels
                                              );

    this.numberOfLiftsChart = getBarChartConfig(this._theme,
                                                       data.numberOfLiftsChartData.dataSets[0].data,
                                                       data.numberOfLiftsChartData.labels
                                                       );

    this.weightedAverageIntensityChart = getHorizontalStackedChartConfig(this._theme,
                                                                         data.weightedAverageIntensityChartData.dataSets[0].data,
                                                                         data.weightedAverageIntensityChartData.labels
                                                                         );
    // this.zoneOfIntensity = getPolarAreaChart(this._theme, data.relativeZoneOfIntensityChartData.dataSets[0].data, data.relativeZoneOfIntensityChartData.labels);
  }

  ngOnDestroy(): void {
    this._subs.unsubscribe();
  }

}
