import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import * as Chart from 'chart.js';
import { ChartConfiguration } from 'chart.js';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.scss']
})
export class BarChartComponent implements OnInit {

  chart: Chart;
  canvasCtx: CanvasRenderingContext2D;

  @Input() configuration: ChartConfiguration;
  @ViewChild('barChartCanvas', {static: true}) canvas2: ElementRef;

  constructor() { }

  ngOnInit() {

    const ctx = (<HTMLCanvasElement>this.canvas2.nativeElement).getContext('2d');

    this.chart = new Chart(ctx, this.configuration);

  }


}
