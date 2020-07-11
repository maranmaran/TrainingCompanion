import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { ChartConfiguration } from 'chart.js';
import { Guid } from 'guid-typescript';
import * as _ from 'lodash-es';
import * as moment from 'moment';
import { combineLatest, ConnectableObservable, forkJoin, Observable, of } from 'rxjs';
import { debounceTime, distinct, distinctUntilChanged, filter, finalize, map, publish, shareReplay, skip, startWith, switchMap, take, tap } from 'rxjs/operators';
import { DashboardService } from 'src/app/features/dashboard/services/dashboard.service';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { Theme } from 'src/business/shared/theme.enum';
import { settingsUpdated } from 'src/ngrx/auth/auth.actions';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { trackItemUpdated } from 'src/ngrx/dashboard/dashboard.actions';
import { trackEditMode } from 'src/ngrx/dashboard/dashboard.selectors';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme, isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { ChartData } from 'src/server-models/entities/chart-data';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { PagedList } from 'src/server-models/shared/paged-list.model';
import { SubSink } from 'subsink';
import { dateSpansDict } from '../models/card-date-span';
import { CardParameters } from '../models/card-params';
import { GetMaxCardChartConfig } from './max-card-chart.config';

@Component({
  selector: 'app-max-card',
  templateUrl: './max-card.component.html',
  providers: [ExerciseTypeService, ReportService,
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] }]
})
export class MaxCardComponent implements OnInit {

  // relevant things for dashboard card
  // which needs to remember user input
  // and also use fixed date spans
  @Input() cardId: string;
  @Input() jsonParams: string;
  @Input() useFixedDateSpans = true;
  @Input() persistParams = true;

  dateSpans = Object.values(dateSpansDict);
  exerciseTypes: ExerciseType[];

  params: CardParameters;
  @Output() saveParamsEvent = new EventEmitter<string>();

  // template relevant things
  form: FormGroup;
  cardBootstrapped = false;
  error = false;
  details: string;
  isLoading = false;

  config: ChartConfiguration[]; // config is main driver of chart

  // relevant for chart configuration
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
    if (this.persistParams) {
      this.params = new CardParameters(this.jsonParams, this.useFixedDateSpans);
    } else {
      this.params = new CardParameters(null, this.useFixedDateSpans);
    }

    // get initializer which will be kicked off and will fetch data once everything is set up
    this._uiChange$ = this.onUIChange();

    // listen to changes from initializer abd prepare data accordingly
    this._subs.add(
      this._uiChange$.subscribe(val => this.prepareData(val)),
    )

    // bootstrap component and kickstart everything
    this.init();
  }

  ngOnDestroy() {

    if (this.persistParams && this.cardBootstrapped && this.form.valid)
      this.saveParams();

    this._subs.unsubscribe();

  }

  /** Initial entry point of component
   * Fetch data for it to operate
   * Bootstrap component and kick start it with hooking on to uiChanges
   */
  init() {
    // get first exercise types page and initialize form
    // also refresh exerciseType from jsonParams because it may be outdated (this could be expensive)
    forkJoin(
      this.store.select(exerciseTypes).pipe(take(1)),
      this.getExerciseType(this.params?.exerciseType?.id).pipe(take(1))
    ).pipe(take(1)).subscribe(([types, type]) => {

      if (types instanceof Error || type instanceof Error) {
        return this.error = true;
      }

      if (!types || types.entities.length == 0) {
        this.error = true;
        this.details = this.translationService.instant('DASHBOARD.MISSING_EXERCISES');
        return;
      }

      type = type as ExerciseType;
      this.params.exerciseType = type;

      this.createForm(types.entities);
      (this._uiChange$ as ConnectableObservable<any>).connect() // now we can fetch card data
      this.cardBootstrapped = true;
    },
      _ => this.error = true
    );
  }

  /** UI Change for things chart configuration uses
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
      distinctUntilChanged((a, b) => JSON.stringify(a) == JSON.stringify(b)), // we fetch new data only for updated unit system
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

    this.loadCardData(this._userId, this.exerciseType.value.id, this.dateFromVal, this.dateToVal);
  }

  /** Fetches metric data from server */
  loadCardData(userId: string, exerciseTypeId: string, dateFrom: Date, dateTo: Date) {
    this.reportService.getDashboardMaxReport(userId, exerciseTypeId, dateFrom, dateTo).pipe(take(1))
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

    this.config = [GetMaxCardChartConfig(settings, data, labels)];
  }

  getExerciseType(typeId: string) {
    if (!typeId) return of(null);

    return this.exerciseTypeService.getOne(typeId);
  }

  get exerciseType(): AbstractControl { return this.form.get('exerciseType'); }
  get dateFrom(): AbstractControl { return this.form.get('dateFrom'); }
  get dateTo(): AbstractControl { return this.form.get('dateTo'); }
  get dateSpan(): AbstractControl { return this.form.get('dateSpan'); }

  get exerciseTypeVal(): ExerciseType { return this.exerciseType.value; }
  get dateFromVal(): Date { return this.useFixedDateSpans ? this.dateSpan.value?.dateFrom as Date : this.dateFrom.value as Date; }
  get dateToVal(): Date { return this.useFixedDateSpans ? new Date() : this.dateTo.value as Date; }

  createForm(types: ExerciseType[]) {

    this.form = new FormGroup({
      exerciseType: new FormControl(this.params.exerciseType ?? types[0], Validators.required),
    });

    // if we use fixed date intervals we only have one dropdown to choose from options
    // like on dashboard
    if (this.useFixedDateSpans) {
      this.form.addControl('dateSpan', new FormControl(dateSpansDict[this.params.dateSpanType] ?? dateSpansDict[0], Validators.required))
    }
    // else we use any date interval so user can choose which one he wants to monitor
    // like on reports..
    else {
      this.form.addControl('dateFrom', new FormControl(new Date(this.params.dateFrom), Validators.required))
      this.form.addControl('dateTo', new FormControl(new Date(this.params.dateTo), Validators.required))
    }

    this.form.updateValueAndValidity();
    this.initListeners();
  }

  /* Listeners for form changes
   * Every time something changes we fetch new data
   * Also we listen for autocomplete typing and fetch found 
   * exercises to display to user
   */
  initListeners() {
    this._subs.add(

      // changes on inputs to fetch chart data if inputs change
      this.exerciseType.valueChanges
        .pipe(filter(val => !!val.id), map(type => type.id))
        .subscribe(typeId => this.loadCardData(this._userId, typeId, this.dateFromVal, this.dateToVal)),

      !this.useFixedDateSpans && this.dateFrom.valueChanges
        .subscribe(dateFrom => this.loadCardData(this._userId, this.exerciseTypeVal.id, dateFrom, this.dateTo.value)),

      !this.useFixedDateSpans && this.dateTo.valueChanges
        .subscribe(dateTo => this.loadCardData(this._userId, this.exerciseTypeVal.id, this.dateFrom.value, dateTo)),

      this.useFixedDateSpans && this.dateSpan.valueChanges.pipe(map(span => span.dateFrom))
        .subscribe(dateFrom => this.loadCardData(this._userId, this.exerciseTypeVal.id, dateFrom, new Date())),

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

  /* Validates form and retrieves it's data if it's valid */
  validateAndGetFormData() {

    if (!this.form.valid) return null;

    const exerciseTypeId = this.exerciseTypeVal;
    const dateFrom = this.dateFromVal;
    const dateTo = this.dateToVal;

    return { exerciseTypeId, dateFrom, dateTo };
  }

  // display for exercise type input
  displayFunction = (exerciseType: ExerciseType) => exerciseType ? exerciseType.name : null;

  /* Saves current parameter configuration so user can have it's dashboard persistent */
  saveParams() {
    let params = {
      dateFrom: this.dateFromVal,
      dateTo: this.dateToVal,
      exerciseType: { id: this.exerciseType.value.id }
    };
    let jsonParams = JSON.stringify(params);

    // TODO outsource this out..
    // conditions for cardId and trackEditMode will be outside..
    if (this.cardId != Guid.EMPTY && !this._trackEditMode) {
      this.saveParamsEvent.emit(jsonParams);

      this.dashboardService.updateTrackItem(this.cardId, jsonParams)
        .pipe(take(1))
        .subscribe((trackItem: TrackItem) => this.store.dispatch(trackItemUpdated({ trackItem })))
    }
  }
}
