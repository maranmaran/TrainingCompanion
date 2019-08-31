import { SelectionModel } from '@angular/cdk/collections';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { AfterViewInit, Component, EventEmitter, Input, OnDestroy, OnInit, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Store } from '@ngrx/store';
import _ from "lodash";
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { TableConfig, TableDatasource } from 'src/business/shared/table-data';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { SubSink } from 'subsink';
import { CustomColumn } from './../../../business/shared/table-data';

@Component({
  selector: 'app-material-table',
  templateUrl: './material-table.component.html',
  styleUrls: [
    './material-table.component.scss',
    './../../features/athlete-management/athletes-home/athlete-list/athlete-list.component.scss'
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
  @Output() updateManyEvent = new EventEmitter<any>();
  @Output() updateEvent = new EventEmitter<any>();
  @Output() deleteEvent = new EventEmitter<any>();
  @Output() deleteSelectionEvent = new EventEmitter<any[]>();

  protected displayColumns: string[] = [];
  protected selection = new SelectionModel<string>(true, []);
  protected pageSize: number;
  protected pageSizeOptions: number[];
  
  @ViewChild(MatTable, { static: true }) table: MatTable<any>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  private applyFilterEvent = new Subject<string>();
  

  private subs = new SubSink();

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.pageSize = this.config.pageSize;
    this.pageSizeOptions = this.config.pageSizeOptions;

    this.subs.add(
      this.applyFilterEvent.pipe(debounceTime(300)).subscribe(filter => this.applyFilter(filter)),
      this.store.select(isMobile).subscribe((isMobile: boolean) => this.setupColumns(isMobile))
    );
  }

  ngAfterViewInit() {
    this.datasource.paginator = this.paginator;
    this.datasource.sort = this.sort;
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  setupColumns(isMobile: boolean) {
    const actions = [];

    if(this.config.selectionEnabled)
      actions.push('select');

    if(isMobile) {
      actions.push(...this.columns.filter(x => x.displayOnMobile).map(x => x.definition));
    } else {
      actions.push(...this.columns.map(x => x.definition));
    }

    if(this.config.actionsEnabled)
      actions.push('actions');
    
    this.displayColumns = actions;
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim().toLocaleLowerCase();

    if(this.config.filterFunction) {
      this.datasource.filterPredicate = this.config.filterFunction;
    } 
      
    this.datasource.filter = filterValue;

    if (this.datasource.paginator) {
      this.datasource.paginator.firstPage();
    }
  }

  public clearSelection() {
    this.selection.clear();
  }

  masterToggle() {
    if (this.isAllSelected) {
      this.selection.clear();
      this.selectEvent.emit(null);
    } else {
      this.datasource.data.forEach(row => this.selection.select(row.id));
    }
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
    
    this.dropEvent.emit({previous: array[event.previousIndex], current: array[event.currentIndex]});
  }

  onDeleteSelection() {
    this.deleteSelectionEvent.emit(this.selection.selected);
  }

  public renderRows = (execute: boolean) => execute && this.table.renderRows(); // because on first load we get error.. no data
  
  public get datasourceEmpty() : boolean {
    return !this.datasource.data || this.datasource.data.length == 0;
  }

  public get deleteManyVisible() : boolean {
    return (this.isMoreThanOneSelected || this.isAllSelected) && !this.isOneSelected && this.config.deleteManyEnabled && !this.datasourceEmpty;
  }

  public oneSelected = (row) => this.isOneSelected && this.selection.isSelected(row.id)

  public get paginatorHidden() : boolean {
    return this.datasourceEmpty || !(this.datasource.data.length > this.pageSize);
  }

  // if only one header action is available replace menu button with that action button
  public get oneHeaderAction(): boolean {
    const add = this.config.addEnabled ? 1 : 0;
    const editMany = this.config.editManyEnabled ? 1 : 0;
    const deleteMany = this.config.deleteManyEnabled ? 1 : 0;
    return add + editMany + deleteMany === 1;
  }

  // hide all header buttons if no header action is available
  public get noHeaderAction(): boolean {
    const add = this.config.addEnabled ? 1 : 0;
    const editMany = this.config.editManyEnabled ? 1 : 0;
    const deleteMany = this.config.deleteManyEnabled ? 1 : 0;
    return add + editMany + deleteMany === 0;
  }

  // if no cell actions are available hide the buttons
  public get noCellAction(): boolean {
    const editActive  = this.config.editEnabled ? 1 : 0;
    const deleteActive = this.config.deleteEnabled ? 1 : 0;
    return editActive + deleteActive  === 0;
  }


}
