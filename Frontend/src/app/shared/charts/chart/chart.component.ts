import { Component, Directive, ElementRef, Input, OnChanges, QueryList, SimpleChanges, ViewChildren } from '@angular/core';
import * as Chart from 'chart.js';
import 'chartjs-plugin-labels';
import { MyChartConfiguration } from '../chart.helpers';

@Directive({selector: '[chartCanvas]'})
export class ChartCanvasDirective {
  @Input() id !: string;

  element: ElementRef;

  constructor(el: ElementRef) {
    this.element = el;
 }

}

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnChanges {

  charts: Chart[] = [];
  contexts: CanvasRenderingContext2D[];

  @ViewChildren(ChartCanvasDirective) canvases!: QueryList<ChartCanvasDirective>;

  selectedTab: number = 0;
  @Input() tabs: string[];
  @Input('configuration') configurations: MyChartConfiguration[];

  constructor() { }

  ngOnChanges(changes: SimpleChanges) {
    const configurations = changes.configurations;
    if(!configurations)
      return;

    const cur = configurations.currentValue;
    const prev = configurations.previousValue;

    // this needs to update chart because current change is different than previous potentially.
    // We see that by comparing generationIds to see which charts needs update
    if(prev && cur) {
      cur.forEach((currentConfig, index) => {

        const previousConfig = prev[index];

        if(!currentConfig || !previousConfig)
          return;

        if(currentConfig.generationId.value != previousConfig.generationId.value)
          this.updateChart(index);

      });
      return;
    }

    // new change.. no previous update. This needs to initialize charts
    if(!prev && cur) {
      cur.forEach((currentConfig, index) => {

        if(!currentConfig)
          return;

        this.initChart(currentConfig, index);
      });
    }
  }

  initChart(config: MyChartConfiguration, index: number) {
    if (!this.canvases)
      return;

    const canvasDirective = this.canvases.toArray()[index];
    if(!canvasDirective)
      return;

    const canvas = <HTMLCanvasElement> canvasDirective.element.nativeElement;
    const ctx = canvas.getContext('2d');
    this.charts.push(new Chart(ctx, config));
  }

  updateChart(index) {
    if(!this.charts || !this.configurations)
      return;

    this.charts[index].options = this.configurations[index].options;
    this.charts[index].data = this.configurations[index].data;
    this.charts[index].update();
  }


}
