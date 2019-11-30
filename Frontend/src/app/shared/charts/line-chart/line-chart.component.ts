import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import * as Chart from 'chart.js';
import { ChartConfiguration } from 'chart.js';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.scss']
})
export class LineChartComponent implements OnInit {

  chart: Chart;
  canvasCtx: CanvasRenderingContext2D;

  @Input() configuration: ChartConfiguration;
  @ViewChild('lineChartCanvas', {static: true}) canvas2: ElementRef;

  constructor() { }

  ngOnInit() {

    const ctx = (<HTMLCanvasElement>this.canvas2.nativeElement).getContext('2d');

    this.chart = new Chart(ctx, this.configuration);

  }

}
