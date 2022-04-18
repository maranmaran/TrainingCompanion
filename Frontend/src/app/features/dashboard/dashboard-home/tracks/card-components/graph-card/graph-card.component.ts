import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { ChartConfiguration } from 'chart.js';
import { Guid } from 'guid-typescript';
import * as _ from 'lodash-es';
import { forkJoin, Observable, of } from 'rxjs';
import { debounceTime, filter, finalize, map, startWith, switchMap, take, tap } from 'rxjs/operators';
import { DashboardService } from 'src/app/features/dashboard/services/dashboard.service';
import { backgroundColors } from 'src/app/shared/charts/chart.helpers';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { settingsUpdated } from 'src/ngrx/auth/auth.actions';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { removeTrackItem, trackItemUpdated } from 'src/ngrx/dashboard/dashboard.actions';
import { trackEditMode } from 'src/ngrx/dashboard/dashboard.selectors';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { PagedList } from 'src/server-models/shared/paged-list.model';
import { SubSink } from 'subsink';
import { dateSpansDict } from '../models/card-date-span';
import { ChartComponent } from './../../../../../../shared/charts/chart/chart.component';
import { CardParameters } from './../models/card-params';
import { GraphCardConfiguration } from './../models/graph-card-config';
@Component({
  selector: 'app-graph-card',
  templateUrl: './graph-card.component.html',
  styleUrls: ['./graph-card.component.scss'],
})
export class GraphCardComponent implements OnInit {

  // relevant things for dashboard card
  // which needs to remember user input
  // and also use fixed date spans
  @Input() title: string;
  @Input() cardId: string;
  @Input() params: CardParameters;
  @Input() config: ChartConfiguration[]; // config is main driver of chart
  @Input() cardConfig = new GraphCardConfiguration();

  @Output() saveParamsEvent = new EventEmitter<string>();
  @Output() fetchData = new EventEmitter<CardParameters>();
  @Output() fetchConfig = new EventEmitter<CardParameters>();

  // refactor this...so it goes through config
  dateSpans = Object.values(dateSpansDict);
  autocompleteExerciseTypesList: Set<ExerciseType>;
  @ViewChild('autocompleteInput') autocompleteInput: ElementRef;

  bulletColors: string[];

  // template relevant things
  form: FormGroup;
  cardBootstrapped = false;
  error = false;
  details: string;
  isLoading = false;
  editMode: Observable<boolean>;

  // relevant for chart configuration
  _trackEditMode: boolean;

  _pagingModel = new PagingModel();
  _subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private exerciseTypeService: ExerciseTypeService,
    private actions$: Actions,
    private dashboardService: DashboardService,
    private translationService: TranslateService,
    public mediaObserver: MediaObserver
  ) { }

  ngOnInit() {

    this.editMode = this.store.select(trackEditMode);

    // some internal props
    this._subs.add(
      this.store.select(trackEditMode).subscribe(editMode => this._trackEditMode = editMode),
    )

    // bootstrap component and kickstart everything
    this.init();
  }

  ngOnDestroy() {
    this._subs.unsubscribe();
  }

  /** Initial entry point of component
   * Fetch data for it to operate
   * Bootstrap component and kick start it with hooking on to uiChanges
   */
  init() {

    forkJoin(
      // get all known exercise types from store
      this.store.select(exerciseTypes).pipe(take(1)),
      // resolve selected exercise types from server in case some tags changed or something
      this.getExerciseTypes(this.params?.exerciseTypeIds).pipe(take(1))
    ).pipe(take(1)).subscribe(([allTypes, monitoredTypes]) => {

      // if we get errors handle it
      if (allTypes instanceof Error || monitoredTypes instanceof Error) {
        return this.error = true;
      }

      // no exercises in store.. means user has no exercises.. add some 
      if (!allTypes || allTypes.length == 0) {
        this.error = true;
        this.details = this.translationService.instant('DASHBOARD.MISSING_EXERCISES');
        return;
      }

      this.autocompleteExerciseTypesList = new Set(allTypes.filter(x => monitoredTypes.findIndex(y => y.id == x.id) == -1));

      // create form and initialize listeners
      this.createForm();

      // map found types to params.. and fetch all chart data
      this.params.setExerciseTypes(monitoredTypes);
      if (this.params.exerciseTypes.length >= this.cardConfig.maxNumberOfExerciseTypes) {
        this.exerciseType.disable({ emitEvent: false });
      }

      this.fetchData.emit(this.params);

      //listen to changes from initializer and prepare data accordingly
      this.initListeners();

      // we are done... do bootstrap
      this.cardBootstrapped = true;
    },
      _ => this.error = true
    );
  }

  getExerciseTypes(typeIds: string[]): Observable<ExerciseType[]> {
    if (!typeIds || typeIds?.length == 0) {
      return of([]);
    }

    let httpCalls = [];
    for (let i = 0; i < typeIds.length; i++) {
      httpCalls.push(this.exerciseTypeService.getOne(typeIds[i]));
    }

    (`Calling GetExerciseType for ${this.cardId}`);

    return forkJoin([...httpCalls]);
  }

  get exerciseType(): AbstractControl { return this.form.get('exerciseType'); }
  get dateSpan(): AbstractControl { return this.form.get('dateSpan'); }

  get exerciseTypeVal(): ExerciseType { return this.exerciseType.value; }
  get dateFromVal(): Date { return this.dateSpan.value?.dateFrom as Date }
  get dateToVal(): Date { return new Date(); }

  createForm() {

    this.form = new FormGroup({
      exerciseType: new FormControl(null),
      dateSpan: new FormControl(dateSpansDict[this.params.dateSpanType], Validators.required)
    });

    this.form.updateValueAndValidity();
  }

  /* Listeners for form changes
   * Every time something changes we fetch new data
   * Also we listen for autocomplete typing and fetch found 
   * exercises to display to user
   */
  initListeners() {
    this._subs.add(
      this.onThemeChange(),
      this.onUnitSystemChange(),
      this.onExerciseTypeSelected(),
      this.onSearchValueChanged(),
      this.onDateSpanChanged(),
    )
  }

  removeExerciseType(exerciseType) {
    if (!exerciseType)
      return;

    // remove from params
    this.params.removeExerciseType(exerciseType);

    // add back to autocomplete results
    this.autocompleteExerciseTypesList.add(exerciseType);

    // update params
    this.saveParams();

    // refetch chart data and config
    this.fetchData.emit(this.params);

    // enable autocomplete input if possible
    if (this.params.exerciseTypes.length < this.cardConfig.maxNumberOfExerciseTypes) {
      this.exerciseType.enable({ emitEvent: false });
    }
  }

  /* Theme change needs only new config */
  onThemeChange() {
    return this.store.select(activeTheme)
      .pipe(
        map(theme => this.params.settings.theme = theme),
        tap(theme => this.bulletColors = backgroundColors(0, this.cardConfig.maxNumberOfExerciseTypes, theme))
      )
      .subscribe(
        _ => this.fetchConfig.emit(this.params),
        err => console.log(err)
      )
  }

  /* Unit system change needs server to recalculate.. 
  // TODO this could be done on frontend to reduce cost of calling DB again */
  onUnitSystemChange() {
    return this.actions$.pipe(ofType(settingsUpdated), map(val => val.unitSystem), startWith(UnitSystem.Metric))
      .pipe(
        map(system => this.params.settings.unitSystem = system)
      )
      .subscribe(
        _ => this.fetchData.emit(this.params),
        err => console.log(err)
      )
  }

  /*When exercise type is selected we need to add it and fetch new data */
  onExerciseTypeSelected() {
    // exercise types change.. fetch new data
    return this.exerciseType.valueChanges
      .pipe(filter(val => !!val?.id))
      .subscribe(typeToAdd => {

        if (this.params.exerciseTypes.length < this.cardConfig.maxNumberOfExerciseTypes) {
          this.params.addExerciseType(typeToAdd);
        }

        // remove from autocomplete results
        this.autocompleteExerciseTypesList.delete(typeToAdd);

        this.saveParams();
        this.fetchData.emit(this.params);

        setTimeout(_ => {
          this.exerciseType.reset(null, { emitEvent: false });
          this.exerciseType.disable({ emitEvent: false });
          if (this.params.exerciseTypes.length < this.cardConfig.maxNumberOfExerciseTypes) {
            this.exerciseType.enable({ emitEvent: false });
          }
        });
      });
  }

  /* When search value changes we need to fetch suggestions for autocomplete dropdown */
  onSearchValueChanged() {
    // autocomplete input changes.. fetch data for dropdown
    return this.exerciseType.valueChanges
      .pipe(
        debounceTime(300),
        filter(val => _.isString(val) || !val),
        tap(() => this.isLoading = true),
        switchMap(_ => this.store.select(currentUserId).pipe(take(1)), (val, userId) => [val, userId]),
        switchMap(([val, userId]) => {

          this._pagingModel.filterQuery = val;

          return this.exerciseTypeService.getPaged(userId, this._pagingModel)
            .pipe(
              take(1),
              finalize(() => this.isLoading = false)
            );
        }),
        map((data: PagedList<ExerciseType>) => {
          return data.list.filter(x => this.params.exerciseTypes.findIndex(y => y.id == x.id) == -1);
        }),
      ).subscribe((data: ExerciseType[]) => {
        this.autocompleteExerciseTypesList.clear();
        data.forEach(d => this.autocompleteExerciseTypesList.add(d as ExerciseType));
      });
  }

  /* When date span changes we need to fetch new data for that date span */
  onDateSpanChanged() {
    return this.dateSpan.valueChanges
      .subscribe(dateSpan => {

        this.params.dateFrom = dateSpan.dateFrom;

        this.saveParams();
        this.fetchData.emit(this.params);
      });
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
  exerciseTypeDisplayFunction = (exerciseType: ExerciseType) => exerciseType ? exerciseType.name : null;

  /* Saves current parameter configuration so user can have it's dashboard persistent */
  saveParams() {

    if (!this.cardBootstrapped || !this.form.valid)
      return;

    if (this.cardId == Guid.EMPTY || this._trackEditMode)
      return;

    const formData = this.validateAndGetFormData();
    if (!formData)
      return;

    let params = JSON.stringify({
      dateFrom: formData.dateFrom,
      dateTo: formData.dateTo,
      exerciseTypeIds: this.params.exerciseTypeIds
    });

    this.saveParamsEvent.emit(params);

    this.dashboardService.updateTrackItem(this.cardId, params)
      .pipe(take(1))
      .subscribe((trackItem: TrackItem) => this.store.dispatch(trackItemUpdated({ trackItem })))
  }

  hidden: boolean[] = new Array().fill(false, 0, this.cardConfig.maxNumberOfExerciseTypes);
  @ViewChild('chart') chartComponent: ChartComponent;
  onToggleLegend(index: number) {

    var prev = this.chartComponent.charts[0].getDatasetMeta(index).hidden ?? false;

    this.chartComponent.charts[0].getDatasetMeta(index).hidden = !prev;
    this.hidden[index] = !prev;

    this.chartComponent.updateChart(0);
  }

  removeFromDashboard() {
    this.store.dispatch(removeTrackItem({ cardId: this.cardId }))
  }

}
