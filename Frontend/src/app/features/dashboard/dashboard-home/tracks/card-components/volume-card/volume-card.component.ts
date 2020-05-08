import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { ChartConfiguration } from 'chart.js';
import { Guid } from 'guid-typescript';
import * as _ from 'lodash';
import * as moment from 'moment';
import { ConnectableObservable, forkJoin, Observable, of } from 'rxjs';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { debounceTime, distinct, distinctUntilChanged, filter, finalize, map, publish, skip, startWith, switchMap, take, tap, concatMap, shareReplay } from 'rxjs/operators';
import { DashboardService } from 'src/app/features/dashboard/services/dashboard.service';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { Theme } from 'src/business/shared/theme.enum';
import { settingsUpdated } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme, isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { ChartData } from 'src/server-models/entities/chart-data';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { PagedList } from 'src/server-models/shared/paged-list.model';
import { SubSink } from 'subsink';
import { ExerciseTypeService } from './../../../../../../../business/services/feature-services/exercise-type.service';
import { currentUserId } from './../../../../../../../ngrx/auth/auth.selectors';
import { trackItemUpdated } from './../../../../../../../ngrx/dashboard/dashboard.actions';
import { trackEditMode } from './../../../../../../../ngrx/dashboard/dashboard.selectors';
import { exerciseTypes } from './../../../../../../../ngrx/exercise-type/exercise-type.selectors';
import { ExerciseType } from './../../../../../../../server-models/entities/exercise-type.model';
import { UnitSystem } from './../../../../../../../server-models/enums/unit-system.enum';
import { PagingModel } from './../../../../../../shared/material-table/table-models/paging.model';
import { GetVolumeCardChartConfig } from './volume-card-chart.config';

@Component({
  selector: 'app-volume-card',
  templateUrl: './volume-card.component.html',
  providers: [ExerciseTypeService, ReportService,
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] }]
})
export class VolumeCardComponent implements OnInit, OnDestroy {

  @Input() cardId: string;
  @Input() jsonParams: string;
  @Input() exerciseTypes: ExerciseType[];
  params: { dateFrom: Date, dateTo: Date, exerciseType: ExerciseType }

  // template relevant things
  form: FormGroup;
  cardBootstrapped = false;
  error = false;
  details: string;
  isLoading = false;

  config: ChartConfiguration[]; // config is main driver of chart

  // params
  isMobile: boolean;
  _theme: Theme;
  _userId: string;
  _unitSystem: UnitSystem;
  _trackEditMode: boolean;

  _uiChange$: Observable<any>; // kickstart listener for init
  _metricsData: ChartData<number, Date>; // actual data
  _pagingModel = new PagingModel();

  _subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private exerciseTypeService: ExerciseTypeService,
    private actions$: Actions,
    private reportService: ReportService,
    private dashboardService: DashboardService,
    private translationService: TranslateService
  ) { }

  ngOnInit() {

    // get props
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);
    this.store.select(trackEditMode).pipe(take(1)).subscribe(editMode => this._trackEditMode = editMode);

    // parse saved json params from user specific dashboard
    this.initParams();

    // get initializer which will be kicked off and will fetch data once everything is set up
    this._uiChange$ = this.onUIChange();

    // listen to changes from initializer abd prepare data accordingly
    this._subs.add(
      this._uiChange$.subscribe(val => this.prepareData(val)),
      // this.dashboardService.saveTrackItemParams.subscribe(_ => this.saveParams())
    )

    // bootstrap component and kickstart everything
    this.onInit();
  }

  ngOnDestroy(): void {
    if (this.cardId != Guid.EMPTY && !this._trackEditMode && this.cardBootstrapped && this.form.valid)
      this.saveParams();

    this._subs.unsubscribe();
  }

  /**
   * Construct params from stringified json params.. 
   * or init new if component is new
   */
  initParams() {
    this.params = JSON.parse(this.jsonParams) ?? {
      dateFrom: new Date(),
      dateTo: new Date(),
      exerciseType: null
    };
  }

  /**
   * Initial entry point of component
   * Fetch data for it to operate
   * Bootstrap component and kick start it with hooking on to uiChanges
   */
  onInit() {
    // get first exercise types page and initialize form
    // also refresh exerciseType from jsonParams because it may be outdated (this could be expensive)
    forkJoin(
      this.store.select(exerciseTypes).pipe(take(1)),
      this.getExerciseType(this.params?.exerciseType?.id).pipe(take(1))
    ).pipe(take(1)).subscribe(([types, type]) => {

      if (types instanceof Error) return;
      if (type instanceof Error) return;

      type = type as ExerciseType;
      this.params.exerciseType = type;

      if (!types || types.entities.length == 0) {
        this.error = true;
        this.details = this.translationService.instant('DASHBOARD.MISSING_EXERCISES');
        return;
      }

      this.createForm(types.entities);
      (this._uiChange$ as ConnectableObservable<any>).connect() // now we can fetch card data
      this.cardBootstrapped = true;
    },
      _ => this.error = true
    );
  }

  /**
   * UI Change for things char configuration uses
   * Theme colors 
   * unit system values (fetch new data for this)
   * User id (who's data)
   * Mobile version or non mobile version
   */
  onUIChange() {
    return combineLatest(
      this.store.select(activeTheme),
      // listening to this action because first we need unit
      // system to be stored in db.. then fetch all new calculated data from server
      this.actions$.pipe(ofType(settingsUpdated), map(val => val.unitSystem), startWith(UnitSystem.Metric)),
      this.store.select(currentUserId),
      this.store.select(isMobile)
    ).pipe(
      // distinctUntilChanged((a, b) => a[1] == b[1]), // we fetch new data only for updated unit system
      shareReplay(),
      publish(),
    );
  }

  /** Determines how data should be prepared for component
   * Should we fetch new data from server
   * or update existing chart configurations only
   */
  prepareData([theme, unitSystem, userId, mobile]) {

    this._theme = theme;
    this._unitSystem = unitSystem;
    this._userId = userId;
    this.isMobile = mobile;

    if (!this.validateAndGetFormData()) return;

    // if data already exists.. just setup configs
    // if (this._metricsData)
    //   return this.getChartConfigs(this._metricsData);

    this.loadCardData(this._userId, this.exerciseType.value.id, this.dateFrom.value, this.dateTo.value);
  }

  /** Fetches metric data from server */
  loadCardData(userId: string, exerciseTypeId: string, dateFrom: Date, dateTo: Date) {
    this.reportService.getDashboardVolumeReport(userId, exerciseTypeId, dateFrom, dateTo)
      .subscribe(
        (data: ChartData<number, Date>) => {
          this._metricsData = data;
          this.getChartConfigs(data);
        },
        err => this.error = true
      )
  }

  /** Gets all ChartJS configs */
  getChartConfigs(chartData: ChartData<number, Date>) {

    // needed to create config for chat
    const labels = chartData.labels.map(date => moment(date).format('L'));
    const data = chartData.dataSets[0].data;
    const settings = { theme: this._theme, unitSystem: this._unitSystem, mobile: this.isMobile };

    this.config = [GetVolumeCardChartConfig(settings, data, labels)];
  }

  getExerciseType(typeId: string) {
    if (!typeId) return of(null);

    return this.exerciseTypeService.getOne(typeId);
  }

  get dateFrom(): AbstractControl { return this.form.get('dateFrom'); }
  get dateTo(): AbstractControl { return this.form.get('dateTo'); }
  get exerciseType(): AbstractControl { return this.form.get('exerciseType'); }

  createForm(types: ExerciseType[]) {
    this.form = new FormGroup({
      exerciseType: new FormControl(this.params?.exerciseType ?? types[0], Validators.required),
      dateFrom: new FormControl(this.params?.dateFrom ? new Date(this.params?.dateFrom) : moment(new Date()).subtract(1, 'month').toDate(), Validators.required),
      dateTo: new FormControl(this.params?.dateTo ? new Date(this.params?.dateTo) : new Date(), Validators.required)
    });

    this.form.updateValueAndValidity();
    this.initListeners();
  }

  /**
   * Listeners for form changes
   * Every time something changes we fetch new data
   * Also we listen for autocomplete typing and fetch found 
   * exercises to display to user
   */
  initListeners() {
    this._subs.add(
      // changes on inputs to fetch chart data if inputs change
      this.dateFrom.valueChanges.subscribe(dateFrom => this.loadCardData(this._userId, this.exerciseType.value.id, dateFrom, this.dateTo.value)),
      this.dateTo.valueChanges.subscribe(dateTo => this.loadCardData(this._userId, this.exerciseType.value.id, this.dateFrom.value, dateTo)),
      this.exerciseType.valueChanges
        .pipe(filter(val => !!val.id), map(type => type.id))
        .subscribe(typeId => {
          this.loadCardData(this._userId, typeId, this.dateFrom.value, this.dateTo.value)
        }),
      // autocomplete input changes.. for paging of dropdown
      this.exerciseType.valueChanges
        .pipe(
          debounceTime(500),
          distinct(),
          skip(1),
          filter(val => _.isString(val) || !val),
          tap(() => {
            this.isLoading = true;
          }),
          switchMap(val => {
            this._pagingModel.filterQuery = val;
            return this.exerciseTypeService.getPaged(this._userId, this._pagingModel).pipe(finalize(() => this.isLoading = false));
          })).subscribe((data: PagedList<ExerciseType>) => {
            this.exerciseTypes = data.list;
          })
    )
  }

  /**
   * Validates form and retrieves it's data if it's valid
   */
  validateAndGetFormData() {
    if (!this.form.valid) return null;

    return (this.exerciseType.value.id, this.dateFrom.value, this.dateTo.value)
  }

  // display for exercise type input
  displayFunction = (exerciseType: ExerciseType) => exerciseType ? exerciseType.name : null;

  /**
   * Saves current parameter configuration so user can have it's dashboard persistent
   */
  saveParams() {
    let params = {
      dateFrom: this.dateFrom.value,
      dateTo: this.dateTo.value,
      exerciseType: { id: this.exerciseType.value.id }
    };

    let jsonParams = JSON.stringify(params);
    // this.store.dispatch(updateTrackItemParams({trackItemId: this.cardId, jsonParams }));
    this.dashboardService.updateTrackItem(this.cardId, jsonParams)
      .pipe(take(1))
      .subscribe((trackItem: TrackItem) => this.store.dispatch(trackItemUpdated({ trackItem })))
  }
}
