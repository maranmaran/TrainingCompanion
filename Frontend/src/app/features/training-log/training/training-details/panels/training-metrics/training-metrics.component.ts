import { Component, OnInit } from '@angular/core';
import { getTestBarChartConfig, getTestLineChartConfig, getTestPieChartConfig } from 'src/app/shared/charts/chart-config.factory';

@Component({
  selector: 'app-training-metrics',
  templateUrl: './training-metrics.component.html',
  styleUrls: ['./training-metrics.component.scss']
})
export class TrainingMetricsComponent implements OnInit {

  pieChartConfig = getTestPieChartConfig();
  lineChartConfig = getTestLineChartConfig();
  barChartConfig = getTestBarChartConfig();

  constructor() { }

  ngOnInit() {
  }

}
