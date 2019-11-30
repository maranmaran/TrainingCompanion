import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Chart, ChartConfiguration } from 'chart.js';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.scss']
})
export class PieChartComponent implements OnInit {


  chart: Chart;
  canvasCtx: CanvasRenderingContext2D;

  @Input() configuration: ChartConfiguration;
  @ViewChild('pieChartCanvas', {static: true}) canvas2: ElementRef;

  constructor() { }

  ngOnInit() {

    const ctx = (<HTMLCanvasElement>this.canvas2.nativeElement).getContext('2d');

    this.chart = new Chart(ctx, this.configuration);

  }

}
