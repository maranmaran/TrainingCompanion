import { Component, OnInit } from '@angular/core';
import { getTestBarChartConfig, getTestLineChartConfig, getTestPieChartConfig, getTestPolarAreaChart, getTestHorizontalChartConfig, getTestHorizontalStackedChartConfig } from 'src/app/shared/charts/chart-config.factory';

@Component({
  selector: 'app-training-metrics',
  templateUrl: './training-metrics.component.html',
  styleUrls: ['./training-metrics.component.scss']
})
export class TrainingMetricsComponent implements OnInit {

  totalVolumeChart = getTestBarChartConfig(); // 1
  volumeSplitChart = getTestPieChartConfig(); // 2

  numberOfLiftsChart = getTestHorizontalChartConfig(); // 3
  weightedAverageIntensityChart = getTestHorizontalStackedChartConfig(); // 4

  // max heavy medium light deload
  // total and per exercise
  zoneOfIntensity = getTestPolarAreaChart(); // 5

  constructor() { }

  ngOnInit() {
  }

}
