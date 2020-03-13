import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { combineLatest, Observable } from 'rxjs';
import { distinctUntilChanged, map, startWith, take } from 'rxjs/operators';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { settingsUpdated } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme, isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { GetBodyweightReportResponse } from 'src/server-models/cqrs/report/get-bodyweight-report.response';
import { SubSink } from 'subsink';
import { Theme } from './../../../../../business/shared/theme.enum';
import { currentUserId } from './../../../../../ngrx/auth/auth.selectors';
import { bodyweightIds } from './../../../../../ngrx/bodyweight/bodyweight.selectors';
import { UnitSystem } from './../../../../../server-models/enums/unit-system.enum';
import { MyChartConfiguration } from './../../../../shared/charts/chart.helpers';
import { GetBodyweightChartConfig } from './bodyweight-chart-config';

@Component({
  selector: 'app-bodyweight-chart',
  templateUrl: './bodyweight-chart.component.html',
  styleUrls: ['./bodyweight-chart.component.scss'],
  providers: [
    ReportService,
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] },
  ]
})
export class BodyweightChartComponent implements OnInit, OnDestroy {

  isMobile: Observable<boolean>;
  params: {
    userId: string,
    theme: Theme,
    unitSystem: UnitSystem,
    mobile: boolean
  }

  form: FormGroup;
  config: MyChartConfiguration[];

  subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private actions$: Actions,
    private reportService: ReportService
  ) { }

  ngOnInit() {

    this.createForm();

    this.subs.add(
      combineLatest(
        this.store.select(activeTheme),
        // listening to this action because first we need unit
        // system to be stored in db.. then fetch all new calculated data from server
        this.actions$.pipe(ofType(settingsUpdated), map(val => val.unitSystem), startWith(UnitSystem.Metric)),
        this.store.select(currentUserId),
        this.store.select(bodyweightIds),
        this.store.select(isMobile)
      )
        .pipe(
          distinctUntilChanged((a, b) => JSON.stringify(a) == JSON.stringify(b)),
        )
        .subscribe(val => this.prepareData(val))
    )
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  get dateFrom(): AbstractControl { return this.form.get('dateFrom'); }
  get dateTo(): AbstractControl { return this.form.get('dateTo'); }

  createForm() {
    this.form = new FormGroup({
      dateFrom: new FormControl(moment(new Date()).subtract(1, 'month').toDate(), Validators.required),
      dateTo: new FormControl(new Date(), Validators.required)
    });
  }

  prepareData([theme, system, userId, _, mobile]) {
    this.params = { theme, unitSystem: system, userId, mobile };

    if (!this.form.valid)
      return;

    this.getReportData();
  }

  getReportData() {
    this.reportService.getBodyweightReport(this.params.userId, this.dateFrom.value, this.dateTo.value)
      .pipe(take(1))
      .subscribe(
        (data: GetBodyweightReportResponse) => {
          this.config = [GetBodyweightChartConfig(this.params, data.values, data.dates.map(date => moment(date).format('L')))];
        },
        err => console.log(err)
      )
  }
}
