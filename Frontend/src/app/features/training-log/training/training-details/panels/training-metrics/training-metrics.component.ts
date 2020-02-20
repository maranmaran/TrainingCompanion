import { Component, OnDestroy, OnInit } from '@angular/core';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ChartConfiguration } from 'chart.js';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { distinctUntilChanged, map, startWith, take } from 'rxjs/operators';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { Theme } from 'src/business/shared/theme.enum';
import { AppState } from 'src/ngrx/app/app.state';
import { settingsUpdated } from 'src/ngrx/auth/auth.actions';
import { currentUserId, unitSystem } from 'src/ngrx/auth/auth.selectors';
import { selectedTrainingId } from 'src/ngrx/training-log/training/training.selectors';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/get-training-metrics.response';
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
    this.store.select(unitSystem).pipe(take(1)).subscribe(system => this._unitSystem = system);

    this._subs.add(
      combineLatest(
        this.store.select(activeTheme),
        // listening to this action because first we need unit
        // system to be stored in db.. then fetch all new calculated data from server
        this.actions$.pipe(ofType(settingsUpdated), map(val => val.unitSystem), startWith(this._unitSystem)),
        this.store.select(selectedTrainingId)
      )
      .pipe(distinctUntilChanged((a,b) => JSON.stringify(a) == JSON.stringify(b)))
      .subscribe(val => this.prepareData(val))
    )
  }

  /** Determines how data should be prepared for component
   * Should we fetch new data from server
   * or update existing chart configurations only
   */
  prepareData([theme, unitSystem, trainingid]) {
    this._theme = theme;
    this._trainingId = trainingid as string;

    // if we need to refresh data because we need additional calculations
    if (this._unitSystem != unitSystem) {
      // get transformed data from server
      this._unitSystem = unitSystem;
      this.loadTrainingMetrics(this._trainingId);
      return;
    } else {
      this._unitSystem = unitSystem;
    }

    // if training data already exists.. just setup configs
    if (this._metricsData) {
      this.getChartConfigs(this._metricsData);
      return;
    }

    this.loadTrainingMetrics(this._trainingId);
  }

  /** Fetches metric data from server */
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

  /** Gets all ChartJS configs */
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
