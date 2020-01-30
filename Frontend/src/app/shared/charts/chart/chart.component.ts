import { Component, ElementRef, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import * as Chart from 'chart.js';
import { MyChartConfiguration } from '../chart.helpers';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit, OnChanges {

  chart: Chart;
  canvasCtx: CanvasRenderingContext2D;

  @Input() configuration: MyChartConfiguration;
  @ViewChild('chartCanvas', { static: true }) canvas: ElementRef;

  constructor() { }

  ngOnInit() {
    if(this.configuration)
      this.initChart();
  }


  ngOnChanges(changes: SimpleChanges) {

    var cur = changes.configuration.currentValue;
    var prev = changes.configuration.previousValue;

    if(cur && prev && cur.generationId.value != prev.generationId.value)
      this.updateChart();

    if(!prev && cur)
      this.initChart();
  }

  initChart() {
    const ctx = (<HTMLCanvasElement>this.canvas.nativeElement).getContext('2d');

    this.chart = new Chart(ctx, this.configuration);
  }

  updateChart() {
    this.chart.options = this.configuration.options;
    this.chart.data = this.configuration.data;
    this.chart.update();
  }


}
