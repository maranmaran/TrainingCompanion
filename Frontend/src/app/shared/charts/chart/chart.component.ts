import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import * as Chart from 'chart.js';
import { ChartConfiguration } from 'chart.js';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {

  chart: Chart;
  canvasCtx: CanvasRenderingContext2D;

  @Input() configuration: ChartConfiguration;
  @ViewChild('chartCanvas', { static: true }) canvas: ElementRef;

  constructor() { }

  ngOnInit() {

    const ctx = (<HTMLCanvasElement>this.canvas.nativeElement).getContext('2d');

    this.chart = new Chart(ctx, this.configuration);

  }


}
