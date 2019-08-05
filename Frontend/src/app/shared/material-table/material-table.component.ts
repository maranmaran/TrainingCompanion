import { CustomColumn } from './../../../business/shared/table-data';
import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { TableData, TableDatasource, TableConfig } from 'src/business/shared/table-data';
import { SubSink } from 'subsink';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Type } from '@angular/compiler';

@Component({
  selector: 'app-material-table',
  templateUrl: './material-table.component.html',
  styleUrls: ['./material-table.component.scss']
})
export class MaterialTableComponent implements OnInit {

  @Input() datasource: TableDatasource<any>;
  @Input() columns: CustomColumn[];
  @Input() config: TableConfig;

  @Output() selectEvent = new EventEmitter<any>();
  @Output() deleteEvent = new EventEmitter<any>();
  @Output() deleteSelectionEvent = new EventEmitter<any[]>();

  protected displayColumns: string[];
  protected selection = new SelectionModel<any>(true, []);
  protected pageSize: number;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor() { }

  ngOnInit() {
    this.datasource.paginator = this.paginator;
    this.datasource.sort = this.sort;
    this.displayColumns = ['select', ...this.columns.map(x => x.definition), 'actions'];
    this.pageSize = this.config.pageSize;
  }

  applyFilter(filterValue: string) {
    this.datasource.filter = filterValue.trim().toLocaleLowerCase();

    if (this.datasource.paginator) {
      this.datasource.paginator.firstPage();
    }
  }

  masterToggle() {
    this.isAllSelected ?
        this.selection.clear() :
        this.datasource.data.forEach(row => this.selection.select(row));
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
 
  onSelect(entity: any) {

    this.selection.toggle(entity);

    // if multiple or none selected - remove details
    if(this.selection.selected.length > 1 || this.selection.isEmpty()) {
      this.selectEvent.emit(null);
      return;
    }

    // new selection
    this.selectEvent.emit(entity);
  }

  onDeleteSelection() {
    this.deleteSelectionEvent.emit(this.selection.selected);
  }

}
