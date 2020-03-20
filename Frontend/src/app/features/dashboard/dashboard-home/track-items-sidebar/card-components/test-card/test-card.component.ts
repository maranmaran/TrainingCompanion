import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ChartConfiguration } from 'chart.js';
import { getHorizontalChartConfig, getHorizontalStackedChartConfig, getPolarAreaChart } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-test-card',
  templateUrl: './test-card.component.html',
  styleUrls: ['./test-card.component.scss']
})
export class TestCardComponent implements OnInit, OnDestroy {

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

  ngOnDestroy(): void {
    this._subs.unsubscribe();
  }

  config: ChartConfiguration[];
  data = [1,2,3]
  labels = ['Exercise 1', 'Exercise 2', 'Exercise 3']
  getChartConfigs() {
    var rand = Math.floor(Math.random() * (5 - 0) + 0);
    switch(rand)
    {
      case 0:
      case 1:
      case 2:
        this.config = [getHorizontalChartConfig(this._theme, this.data, this.labels)];
        break;
      case 3:
        this.config = [getHorizontalStackedChartConfig(this._theme, this.data, this.labels)];
        break;
      case 4:
        this.config = [getPolarAreaChart(this._theme, this.data, this.labels)];
        break;
    }
  }

}
