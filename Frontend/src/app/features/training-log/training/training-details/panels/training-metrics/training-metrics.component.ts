import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ChartConfiguration } from 'chart.js';
import { getBarChartConfig, getHorizontalChartConfig, getHorizontalStackedChartConfig, getPieChartConfig, getPolarAreaChart } from 'src/app/shared/charts/training-chart-config.factory';
import { AppState } from 'src/ngrx/app/app.state';
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
  zoneOfIntensity: ChartConfiguration; // 5

  _subs = new SubSink();
  _theme: Theme;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this._subs.add(
      this.store.select(activeTheme).subscribe(theme => {
        this._theme = theme;
        this.getChartConfigs();
      })
    )

  }

  data = [1,2,3]
  labels = ['Exercise 1', 'Exercise 2', 'Exercise 3']
  getChartConfigs() {
    this.volumeSplitChart = getPieChartConfig(this._theme, this.data, this.labels);
    this.totalVolumeChart = getBarChartConfig(this._theme, this.data, this.labels);
    this.numberOfLiftsChart = getHorizontalChartConfig(this._theme, this.data, this.labels);
    this.weightedAverageIntensityChart = getHorizontalStackedChartConfig(this._theme, this.data, this.labels);
    this.zoneOfIntensity = getPolarAreaChart(this._theme, this.data, this.labels);
  }

  ngOnDestroy(): void {
    this._subs.unsubscribe();
  }

}
