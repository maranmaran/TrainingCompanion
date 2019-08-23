import { CustomColumn } from './../../../business/shared/table-data';
import { Component, OnInit, Input, Output, EventEmitter, ViewChild, OnDestroy, AfterViewInit, ViewEncapsulation } from '@angular/core';
import { TableData, TableDatasource, TableConfig } from 'src/business/shared/table-data';
import { SubSink } from 'subsink';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Type } from '@angular/compiler';
import { Observable, Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { UIService } from 'src/business/services/shared/ui.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';

@Component({
  selector: 'app-material-table',
  templateUrl: './material-table.component.html',
  styleUrls: [
    './material-table.component.scss',
    './../../features/exercise-properties/exercise-properties-home/types-list/types-list.component.scss',
    './../../features/athlete-management/athletes-home/athlete-list/athlete-list.component.scss'
  ],
  encapsulation: ViewEncapsulation.None,
})
export class MaterialTableComponent implements OnInit, AfterViewInit, OnDestroy {
  

  @Input() datasource: TableDatasource<any>;
  @Input() columns: CustomColumn[];
  @Input() config: TableConfig;

  @Output() selectEvent = new EventEmitter<any>();
  @Output() addEvent = new EventEmitter<any>();
  @Output() updateEvent = new EventEmitter<any>();
  @Output() deleteEvent = new EventEmitter<any>();
  @Output() deleteSelectionEvent = new EventEmitter<any[]>();

  protected displayColumns: string[];
  protected displayDataColumns: CustomColumn[];
  protected selection = new SelectionModel<string>(true, []);
  protected pageSize: number;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  private applyFilterEvent = new Subject<string>();
  

  private subs = new SubSink();

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.pageSize = this.config.pageSize;

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

    if(isMobile) {
      this.displayColumns = ['select', ...this.columns.filter(x => x.displayOnMobile).map(x => x.definition), 'actions'];
      console.log(this.displayColumns);
      return;
    } 

    this.displayColumns = ['select', ...this.columns.map(x => x.definition), 'actions'];
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

  onDeleteSelection() {
    this.deleteSelectionEvent.emit(this.selection.selected);
  }

  public datasourceEmpty = () => !this.datasource.data || this.datasource.data.length == 0;
  public deleteManyVisible = () => (this.isMoreThanOneSelected || this.isAllSelected) && !this.isOneSelected && this.config.deleteEnabled && !this.datasourceEmpty
  public oneSelected = (row) => this.isOneSelected && this.selection.isSelected(row.id)
  public paginatorHidden = () => this.datasourceEmpty || !(this.datasource.data.length > this.pageSize)

}
