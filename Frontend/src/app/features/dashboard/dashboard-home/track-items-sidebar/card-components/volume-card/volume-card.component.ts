import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ChartConfiguration } from 'chart.js';
import * as moment from 'moment';
import { ConnectableObservable, Observable } from 'rxjs';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { distinctUntilChanged, map, publish, startWith, switchMap, take } from 'rxjs/operators';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { Theme } from 'src/business/shared/theme.enum';
import { settingsUpdated } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme, isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { ChartData } from 'src/server-models/entities/chart-data';
import { SubSink } from 'subsink';
import { ExerciseTypeService } from './../../../../../../../business/services/feature-services/exercise-type.service';
import { currentUserId, unitSystem } from './../../../../../../../ngrx/auth/auth.selectors';
import { ExerciseType } from './../../../../../../../server-models/entities/exercise-type.model';
import { UnitSystem } from './../../../../../../../server-models/enums/unit-system.enum';
import { GetVolumeCardChartConfig } from './volume-card-chart.config';

@Component({
  selector: 'app-volume-card',
  templateUrl: './volume-card.component.html',
  styleUrls: ['./volume-card.component.scss'],
  providers: [ExerciseTypeService, ReportService]
})
export class VolumeCardComponent implements OnInit, OnDestroy {

  // template relevant things
  form: FormGroup;
  exerciseTypes: ExerciseType[];
  cardBootstrapped = false;
  error = false;
  isLoading = false;


  config: ChartConfiguration[]; // config is main driver of chart

  // params
  isMobile: boolean;
  _theme: Theme;
  _userId: string;
  _unitSystem: UnitSystem;

  _initializer$: Observable<any>; // kickstart listener for init
  _metricsData: ChartData<number, Date>; // actual data

  _subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private exerciseTypeService: ExerciseTypeService,
    private actions$: Actions,
    private reportService: ReportService
  ) { }

  ngOnInit() {
    this._initializer$ = this.getCardInitializer();

    // get props
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);
    this.store.select(unitSystem).pipe(take(1)).subscribe(system => this._unitSystem = system);

    // get all exercise types and initialize form
    this.getExerciseTypes().subscribe((types: ExerciseType[]) => {
        if(!types || types.length == 0) return;

        this.createForm(types);
        (this._initializer$ as ConnectableObservable<any>).connect() // now we can fetch card data
        this.cardBootstrapped = true;
      },
      _ => this.error = true
    );

    // listen to changes from initializer abd prepare data accordingly
    this._subs.add(
      this._initializer$.subscribe(val => this.prepareData(val))
    )
  }

  ngOnDestroy(): void {
    this._subs.unsubscribe();
  }

  getCardInitializer() {
    return combineLatest(
      this.store.select(activeTheme),
      // listening to this action because first we need unit
      // system to be stored in db.. then fetch all new calculated data from server
      this.actions$.pipe(ofType(settingsUpdated), map(val => val.unitSystem), startWith(this._unitSystem)),
      this.store.select(isMobile)
    )
    .pipe(
      distinctUntilChanged((a,b) => JSON.stringify(a) == JSON.stringify(b)),
      publish()
    );
  }

  /** Determines how data should be prepared for component
   * Should we fetch new data from server
   * or update existing chart configurations only
   */
  prepareData([theme, unitSystem, mobile]) {
    this._theme = theme;
    this.isMobile = mobile;

    let formData = this.validateAndGetFormData();
    if(!formData) return;

    // if we need to refresh data because we need additional calculations or transform
    if (this._unitSystem != unitSystem) {

      // get transformed data from server
      this._unitSystem = unitSystem;

      let formData = this.validateAndGetFormData();
      if(formData) {
        this.loadCardData(this._userId, this.exerciseType.value.id, this.dateFrom.value, this.dateTo.value);
      }

      return;
    }

    // if data already exists.. just setup configs
    if (this._metricsData) {
      this.getChartConfigs(this._metricsData);
      return;
    }
  }

  /** Fetches metric data from server */
  loadCardData(userId: string, exerciseTypeId: string, dateFrom: Date, dateTo: Date) {
    this.reportService.getDashboardVolumeReport(userId, exerciseTypeId, dateFrom, dateTo)
      .subscribe(
        (data: ChartData<number, Date>) => {
          this._metricsData = data;
          this.getChartConfigs(data);
        },
        err => console.log(err)
      )
  }

  /** Gets all ChartJS configs */
  getChartConfigs(chartData: ChartData<number, Date>) {

    // needed to create config for chat
    const labels = chartData.labels.map(date => moment(date).format('L'));
    const data = chartData.dataSets[0].data;
    const settings = { theme: this._theme, unitSystem: this._unitSystem, mobile: this.isMobile };

    this.config = [ GetVolumeCardChartConfig(settings, data, labels) ];
  }

  getExerciseTypes() {
    return this.store.select(currentUserId).pipe(
      switchMap(id => this.exerciseTypeService.getAll(id).pipe(take(1))),
      take(1),
    );
  }

  get dateFrom(): AbstractControl { return this.form.get('dateFrom'); }
  get dateTo(): AbstractControl { return this.form.get('dateTo'); }
  get exerciseType(): AbstractControl { return this.form.get('exerciseType'); }

  createForm(types: ExerciseType[]) {
    this.exerciseTypes = types;
    this.form = new FormGroup({
      exerciseType: new FormControl(types[0], Validators.required),
      dateFrom: new FormControl(moment(new Date()).subtract(1, 'month').toDate(), Validators.required),
      dateTo: new FormControl(new Date(), Validators.required)
    });
  }

  validateAndGetFormData() {
    if(!this.form.valid) return null;

    return (this.exerciseType.value.id, this.dateFrom.value, this.dateTo.value)
  }

  displayFunction = (exerciseType: ExerciseType) => exerciseType ? exerciseType.name : null;

}
