import { SelectionModel } from '@angular/cdk/collections';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnDestroy, OnInit, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Store } from '@ngrx/store';
import _ from "lodash";
import { Observable, Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { TableConfig } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { CustomColumn } from "./table-models/custom-column.model";
import { PagingModel } from './table-models/paging.model';

@Component({
  selector: 'app-material-table',
  templateUrl: './material-table.component.html',
  styleUrls: [
    './material-table.component.scss',
    './../../features/athlete-management/athletes-home/athlete-list/athlete-list.component.scss',
    './../../features/exercise-properties/exercise-properties-home/types/types-list/types-list.component.scss'
  ],
  encapsulation: ViewEncapsulation.None,
})
export class MaterialTableComponent implements OnInit, AfterViewInit, OnDestroy {


  @Input() datasource: TableDatasource<any>;
  @Input() columns: CustomColumn[];
  @Input() config: TableConfig;

  @Output() selectEvent = new EventEmitter<any>();
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
  selection = new SelectionModel<string>(true, []);
  pageSize: number;
  pageSizeOptions: number[];
  totalItems: Observable<number>;
  page: Observable<number>;

  @ViewChild(MatTable, { static: true }) table: MatTable<any>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild('filter') filter: ElementRef;
  private applyFilterEvent = new Subject<string>();

  private pagingModel: PagingModel;

  private subs = new SubSink();

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.pageSize = this.config.pageSize;
    this.pageSizeOptions = this.config.pageSizeOptions;

    this.subs.add(
      this.applyFilterEvent.pipe(debounceTime(300)).subscribe(filter => this.applyFilter(filter)),
      this.store.select(isMobile).subscribe((isMobile: boolean) => this.setupColumns(isMobile)),
      this.datasource.pagingModel().subscribe(model => {
        this.pagingModel = model;
        this.setTablePagingVariables(model, this.datasource.totalLength());
      })
    );
  }

  ngAfterViewInit() {
    // assign paginator and sort components to datasource only if we'r not using server side paging
    if (!this.config.serverSidePaging) {
      this.datasource.paginator = this.paginator;
      this.datasource.sort = this.sort;
    } else {
      setTimeout(() => this.setTablePagingVariables(this.pagingModel, this.datasource.totalLength()));
    }

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

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  setupColumns(isMobile: boolean) {
    const actions = [];

    if (this.config.selectionEnabled)
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

  applyFilter(filterValue: string) {

    filterValue = filterValue.trim().toLocaleLowerCase();

    // TODO - filter this server side - send event for pagination change
    if (this.config.serverSidePaging) {

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

  public clearSelection() {
    this.selection.clear();
  }

  masterToggle() {
    if (this.isAllSelected) {
      console.log('clear emit');
      this.selection.clear();
      this.selectEvent.emit(null);
    } else {
      console.log('foreach');
      this.datasource.data.forEach(row => this.selection.select(row.id));
    }

    console.log(this.isAllSelected);
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

  onSelect(entity: any, keepSelected: boolean = false) {

    var selectedTemp = this.selection.isSelected(entity.id);
    this.selection.clear();

    if (!selectedTemp || keepSelected) { // if it wasn't selected
      this.selection.toggle(entity.id); // toggle
    } else { // else don't
      this.selectEvent.emit(null);
      return;
    }

    // // if multiple or none selected - remove details
    // if (this.selection.selected.length > 1 || this.selection.isEmpty()) {
    //   this.selectEvent.emit(null);
    //   return;
    // }

    // new selection
    this.selectEvent.emit(entity);
  }

  onListDrop(event: CdkDragDrop<any[]>) {

    const array = [...this.datasource.data];

    moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);

    // needed for drag and drop to work properly inside table
    this.datasource.data = _.cloneDeep(event.container.data);
    this.table.renderRows();

    this.dropEvent.emit({ previous: array[event.previousIndex], current: array[event.currentIndex] });
  }

  onDeleteSelection() {
    this.deleteManyEvent.emit(this.selection.selected);
  }

  public renderRows = (execute: boolean) => execute && this.table.renderRows(); // because on first load we get error.. no data

  public get datasourceEmpty(): boolean {
    return !this.datasource.data || this.datasource.data.length == 0;
  }

  public get deleteManyVisible(): boolean {
    return (this.isMoreThanOneSelected || this.isAllSelected) && !this.isOneSelected && this.config.deleteManyEnabled && !this.datasourceEmpty;
  }
  public get disableManyVisible(): boolean {
    return (this.isMoreThanOneSelected || this.isAllSelected) && !this.isOneSelected && this.config.disableManyEnabled && !this.datasourceEmpty;
  }

  public oneSelected = (row) => this.isOneSelected && this.selection.isSelected(row.id)

  public get paginatorHidden(): boolean {
    return this.datasourceEmpty || !(this.datasource.data.length > this.pageSize);
  }

  // if only one header action is available replace menu button with that action button
  public get oneHeaderAction(): boolean {
    const add = this.config.addEnabled ? 1 : 0;
    const editMany = this.config.editManyEnabled ? 1 : 0;
    const deleteMany = this.config.deleteManyEnabled && this.deleteManyVisible ? 1 : 0;
    const disableMany = this.config.disableManyEnabled && this.disableManyVisible ? 1 : 0;
    return add + editMany + deleteMany + disableMany === 1;
  }

  // hide all header buttons if no header action is available
  public get noHeaderAction(): boolean {
    const add = this.config.addEnabled ? 1 : 0;
    const editMany = this.config.editManyEnabled ? 1 : 0;
    const deleteMany = this.config.deleteManyEnabled ? 1 : 0;
    const disableMany = this.config.disableManyEnabled ? 1 : 0;
    return add + editMany + deleteMany + disableMany === 0;
  }

  // if no cell actions are available hide the buttons
  public get noCellAction(): boolean {
    const editActive = this.config.editEnabled ? 1 : 0;
    const deleteActive = this.config.deleteEnabled ? 1 : 0;
    const disableActive = this.config.disableEnabled ? 1 : 0;
    return editActive + deleteActive + disableActive === 0;
  }

  public onPageChange(page: PageEvent) {
    this.pagingModel.page = page.pageIndex;
    this.pagingModel.pageSize = page.pageSize;
    this.pagingChangeEvent.emit(this.pagingModel);
  }

  public onSortChange(sort: Sort) {
    this.pagingModel.sortBy = sort.active;
    this.pagingModel.sortDirection = sort.direction;
    this.pagingChangeEvent.emit(this.pagingModel);
  }


}
