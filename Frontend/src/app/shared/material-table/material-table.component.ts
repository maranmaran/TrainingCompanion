import { animate, state, style, transition, trigger } from '@angular/animations';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnDestroy, OnInit, Output, Renderer2, ViewChild, ViewEncapsulation } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import _ from 'lodash-es';
import { Observable, Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { TableConfig } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { SubSink } from 'subsink';
import { CustomColumn } from "./table-models/custom-column.model";
import { PagingModel } from './table-models/paging.model';

@Component({
  selector: 'app-material-table',
  templateUrl: './material-table.component.html',
  styleUrls: [
    './material-table.component.scss',
    './../../features/athlete-management/athletes-home/athlete-list/athlete-list.component.scss',
    './../../features/exercise-properties/exercise-properties-home/types/types-list/types-list.component.scss',
    './../../features/exercise-types/exercise-types-home/exercise-type-list/exercise-type-list.component.scss',
    './../../features/bodyweight/bodyweight-home/bodyweight-list/bodyweight-list.component.scss',
    './../../features/training-program/training-program-home/training-program-components/training-program-list/training-program-list.component.scss',
  ],
  encapsulation: ViewEncapsulation.None,
  animations: [
    trigger('detailExpand', [
      state('collapsed, void', style({ height: '0px', minHeight: '0', visibility: 'hidden' })),
      state('expanded', style({ height: '*', visibility: 'visible' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
      transition('expanded <=> void', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)'))
    ])
  ],
})
export class MaterialTableComponent implements OnInit, AfterViewInit, OnDestroy {

  @Input() datasource: TableDatasource<any>;
  @Input() columns: CustomColumn[];
  @Input() config: TableConfig;

  @Output() selectEvent = new EventEmitter<any>();
  @Output() expandEvent = new EventEmitter<any>();
  @Output() collapseEvent = new EventEmitter<any>();
  @Output() dropEvent = new EventEmitter<any>();

  @Output() addEvent = new EventEmitter<any>();
  @Output() updateEvent = new EventEmitter<any>();
  @Output() deleteEvent = new EventEmitter<any>();
  @Output() disableEvent = new EventEmitter<any>();

  @Output() updateManyEvent = new EventEmitter<any>();
  @Output() disableManyEvent = new EventEmitter<any[]>();
  @Output() deleteManyEvent = new EventEmitter<any[]>();

  @Output() pagingChangeEvent = new EventEmitter<PagingModel>();

  displayColumns: string[] = [];
  pageSize: number;
  pageSizeOptions: number[];
  totalItems: Observable<number>;

  @ViewChild(MatTable, { static: true }) table: MatTable<any>;
  @ViewChild(MatTable, { static: true, read: ElementRef }) tableNative: ElementRef;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild('filter') filter: ElementRef;
  private applyFilterEvent = new Subject<string>();

  private pagingModel: PagingModel;

  expandedRow: any;

  private subs = new SubSink();

  constructor(
    private mediaObserver: MediaObserver,
    private renderer: Renderer2
  ) { }

  ngOnInit() {

    this.handlePaging();

    this.subs.add(
      // filter event
      this.onFilterEvent(),
      // do work on viewport change (mobile, tablet, desktop)
      this.onViewportChange(),
      // Outputs select events
      this.onSelectEvent()
    );
  }

  ngAfterViewInit() {
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  /**
   * Sets up pagination and sorting for table
   * Depends on serverSidePaging flag it may have two different
   * implementations
   */
  handlePaging() {

    // set pageSize and options
    this.pageSize = this.config.pagingOptions.pageSize;
    this.pageSizeOptions = this.config.pagingOptions.pageSizeOptions;

    // if we'r using server side paging we don't care about
    // how datasource manages paginator and sort internally..
    // we do it on backend and maintain our custom page model inside
    // our custom TableDatasource implementation of MatTableDatasource
    if (this.config.pagingOptions.serverSidePaging) {
      // setup paging model and variables
      return this.subs.add(
        this.onDatasourcePagingChange()
      );
    }

    // only if we'r not using server side paging
    // assign paginator and sort components to datasource
    return this.handleDefaultPaging();
  }

  /**
   * Lets datasource take care of paging and sorting internally
   * With sorting implementing custom accessor given through config
   */
  handleDefaultPaging() {

    // paginator
    this.datasource.paginator = this.paginator;

    // sort
    this.datasource.sort = this.sort
    this.datasource.sortingDataAccessor = this.customSortDataAccessor.bind(this);
    // this.datasource.sort.active = this.config.defaultSort;
    // this.datasource.sort.direction = this.config.defaultSortDirection;

    // // do default sort
    // setTimeout(_ => this.datasource.sort.sort({
    //   id: this.config.defaultSort,
    //   start: this.config.defaultSortDirection,
    //   disableClear: false
    // }));
  }

  /**
   * We handle everything serverside
   */
  handleServerSidePaging() {
    this.setTablePagingVariables(this.pagingModel, this.datasource.totalLength());
  }

  /**Pipes selection events from datasource to outside */
  onSelectEvent() {
    return this.datasource.selectionEvent.subscribe(e => this.selectEvent.emit(e))
  }

  onFilterEvent() {
    return this.applyFilterEvent
      .pipe(debounceTime(300))
      .subscribe(filter => this.applyFilter(filter));
  }

  onDatasourcePagingChange() {
    return this.datasource.pagingModel().subscribe(model => {
      this.pagingModel = model;
      this.setTablePagingVariables(model, this.datasource.totalLength());
    })
  }

  onViewportChange() {
    return this.mediaObserver.media$.subscribe(change => {
      var isMobile = change.mqAlias == 'xs';
      this.setupColumns(isMobile);
    })
  }

  setupColumns(isMobile: boolean) {
    const actions = [];

    if (this.config.multipleSelectEnabled)
      actions.push('select');

    if (isMobile) {
      actions.push(...this.columns.filter(x => x.displayOnMobile).map(x => x.definition));
    } else {
      actions.push(...this.columns.map(x => x.definition));
    }

    if (this.config.actionsEnabled)
      actions.push('actions');

    this.displayColumns = actions;
  }

  // sets custom sort by definition from columns config
  // if no custom sortFn is given.. defaults back to item
  customSortDataAccessor(data, prop) {
    let customSortDataFn = this.columns?.filter(x => x.sort && x.sortFn && x.definition == prop)?.map(x => x.sortFn)[0];

    if (customSortDataFn)
      return customSortDataFn(data);

    return data[prop];
  }

  setTablePagingVariables(model: PagingModel, totalItems: Observable<number>) {

    this.totalItems = totalItems;
    this.paginator.pageIndex = model.page;
    this.sort.active = model.sortBy;
    this.sort.direction = model.sortDirection;

    if (this.filter) {
      this.filter.nativeElement.value = model.filterQuery ? model.filterQuery : '';
    }

  }

  applyFilter(filterValue: string) {

    filterValue = filterValue.trim().toLocaleLowerCase();

    // TODO - filter this server side - send event for pagination change
    if (this.config.pagingOptions.serverSidePaging) {

      this.pagingModel.filterQuery = filterValue;
      this.pagingChangeEvent.emit(this.pagingModel);

    } else {

      if (this.config.filterFunction) {
        this.datasource.filterPredicate = this.config.filterFunction;
      }

      this.datasource.filter = filterValue;

      if (this.datasource.paginator) {
        this.datasource.paginator.firstPage();
      }
    }

  }

  clearSelection() {
    this.selection.clear();
  }

  masterToggle() {
    if (this.isAllSelected) {
      this.selection.clear();
      this.datasource.selectionEvent.emit(null);
    } else {
      this.datasource.data.forEach(row => this.selection.select(row.id));
    }
  }

  /* Retrieves selection data structure out of datasource*/
  get selection() {
    return this.datasource.selection;
  }

  get isOneSelected() {
    return this.selection.selected.length == 1;
  }

  get isMoreThanOneSelected() {
    return this.selection.selected.length > 1;
  }

  get isAllSelected() {
    return this.datasource.data.length === this.selection.selected.length;
  }

  oneSelected = (row) => this.isOneSelected && this.selection.isSelected(row.id)

  onSelect(entity: any, keepSelected: boolean = false, event: Event = null) {

    // Workaround for clicking item inside row and then dragging mouse outside
    // of that component and releasing it on row
    // which in turn triggered unwanted click event
    // Example: Dragging and sliding exercise tags inside material-table
    console.log(this.mousedownFired)
    if(this.mousedownFired) {
      this.mousedownFired = !this.mousedownFired;
    } else {
      // prevent this if mousedown event never bubbled from inner component up to material-table row
      return;
    }

    // selection is disabled
    if(!this.config.selectionEnabled)
      return;

    // handle row openings on selection (after everything is done hence timeout)
    setTimeout(_ => {
      if (this.config.usesExpandableRows) {
        this.expandRowOnSelect(entity);
      }
    })

    // select
    this.datasource.selectElement(entity, keepSelected);

    // update pages to jump on selected element
    this.updatePage(entity.id);
  }

  /* Updates paginator with page index of where the item is */
  updatePage(itemId) {

    const index = this.datasource.data.findIndex(x => x.id == itemId);
    const pageSize = this.config.pagingOptions.pageSize;

    if (index == -1 && this.config.pagingOptions.serverSidePaging) {
      // load page from server
      this.pagingModel.itemId = itemId;
      this.pagingChangeEvent.emit(this.pagingModel);

      return this.pagingModel.itemId = undefined;
    }

    const page = Math.floor(index / pageSize);

    const event = new PageEvent();
    event.pageSize = pageSize;
    event.pageIndex = page;
    event.length = this.datasource.data.length;
    event.previousPageIndex = page == 0 ? null : page - 1;

    if (this.datasource.paginator.pageIndex == page) {
      return;
    }

    this.datasource.paginator.pageIndex = page;
    this.datasource.paginator.page.next(event);
  }

  /**Handles row expanding if element is selected */
  expandRowOnSelect(row: any) {

    this.expandedRow = this.expandedRow?.id == row?.id ? null : row;

    if (this.expandedRow) {
      return this.expandEvent.emit();
    }

    return this.collapseEvent.emit();
  }

  onListDrop(event: CdkDragDrop<any[]>) {

    let from = this.paginator.pageIndex * this.paginator.pageSize;
    let to = from + this.paginator.pageSize;

    const array = [...this.datasource.data.slice(from, to)];

    moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);

    // needed for drag and drop to work properly inside table
    this.datasource.data = _.cloneDeep(event.container.data);
    this.table.renderRows();

    this.dropEvent.emit({ previous: array[event.previousIndex], current: array[event.currentIndex] });
  }

  renderRows = (execute: boolean) => execute && this.table.renderRows(); // because on first load we get error.. no data

  get datasourceEmpty(): boolean {
    return !this.datasource.data || this.datasource.data.length == 0;
  }

  get paginatorHidden(): boolean {
    return this.datasourceEmpty || !(this.datasource.data.length > this.pageSize);
  }

  onPageChange(page: PageEvent) {
    this.pagingModel.page = page.pageIndex;
    this.pagingModel.pageSize = page.pageSize;
    this.pagingChangeEvent.emit(this.pagingModel);
  }

  onSortChange(sort: Sort) {
    this.pagingModel.sortBy = sort.active;
    this.pagingModel.sortDirection = sort.direction;
    this.pagingChangeEvent.emit(this.pagingModel);
  }

  onDragStarted() {
    this.renderer.addClass(this.tableNative.nativeElement, 'pointer-events-none');
  }

  onDragEnded() {
    this.renderer.removeClass(this.tableNative.nativeElement, 'pointer-events-none');
  }

  trackByFn(item) {
    return item.id;
  }

  // Workarounds for when child item is clicked on
  // and mouse is dragged outside of child onto parent container
  // in this case material-table row
  // click event is fired on parent even though child
  // sent $event.stopPropagation() to stop bubbling
  // Example: Sliding tags from exercises and mouse runs outside of column into
  // neighbour column (mat-row) and it triggers select on row and routes you to details...
  mousedownFired = false
  handleMouseDown(event: Event) {
    this.mousedownFired = true;
  }

  handleMouseUp(event: Event) {
    setTimeout(_ => this.mousedownFired = false, 100);
  }
}
