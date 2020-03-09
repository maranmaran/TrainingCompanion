import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { combineLatest, Observable } from 'rxjs';
import { distinctUntilChanged, map, startWith, take } from 'rxjs/operators';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { settingsUpdated } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme, isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { currentUserId } from './../../../../../ngrx/auth/auth.selectors';
import { UnitSystem } from './../../../../../server-models/enums/unit-system.enum';

@Component({
  selector: 'app-bodyweight-chart',
  templateUrl: './bodyweight-chart.component.html',
  styleUrls: ['./bodyweight-chart.component.scss'],
  providers: [
    ReportService,
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] }
  ]
})
export class BodyweightChartComponent implements OnInit, OnDestroy {

  userId: string;
  unitSystem = UnitSystem.Metric;
  isMobile: Observable<boolean>;

  form: FormGroup;

  subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private actions$: Actions,
    private reportService: ReportService
  ) { }

  ngOnInit() {

    this.createForm();

    this.isMobile = this.store.select(isMobile);

    this.subs.add(
      combineLatest(
        this.store.select(activeTheme),
        // listening to this action because first we need unit
        // system to be stored in db.. then fetch all new calculated data from server
        this.actions$.pipe(ofType(settingsUpdated), map(val => val.unitSystem), startWith(this.unitSystem)),
        this.store.select(currentUserId)
      )
        .pipe(distinctUntilChanged((a, b) => JSON.stringify(a) == JSON.stringify(b)))
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

  prepareData([theme, system, userId]) {
    console.log({theme, system, userId});
    this.userId = userId;

    this.getReportData();

  }

  getReportData() {
    if(!this.form.valid)
      return;

    this.reportService.getBodyweightReport(this.userId, this.dateFrom.value, this.dateTo.value)
    .pipe(take(1))
    .subscribe(
      data => {
        console.log(data)
      },
      err => console.log(err)
    )
  }

}
