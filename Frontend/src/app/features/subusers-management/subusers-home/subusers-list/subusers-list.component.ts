import { SubSink } from 'subsink';
import { Component, OnInit, Input, ViewChild, OnDestroy, Output, EventEmitter } from '@angular/core';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { Observable, of } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-subusers-list',
  templateUrl: './subusers-list.component.html',
  styleUrls: ['./subusers-list.component.scss']
})
export class SubusersListComponent implements OnInit, OnDestroy {

  @Input() subusers$: Observable<ApplicationUser[]>
  private subusers: ApplicationUser[];
  private subs = new SubSink();
  private selectedSubuserId: string;

  @Output() subuserSelectedEvent = new EventEmitter<ApplicationUser>();
  @Output() deleteSubuserEvent = new EventEmitter<ApplicationUser>();
  @Output() deleteSelectionEvent = new EventEmitter<ApplicationUser[]>();

  // #region Table config
  displayedColumns: string[] = ['select', 'name', 'actions'];
  dataSource: MatTableDataSource<ApplicationUser>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  protected selection = new SelectionModel<ApplicationUser>(true, []);
  protected pageSize: number = 5;
  protected datasourceLength: number = 0;
  // #endregion

  constructor() { }

  ngOnInit() {
    this.subs.add(
      this.subusers$.subscribe(subusers => this.subusers = subusers)
    );

    this.setupTable();
  }

  ngOnDestroy() {
   this.subs.unsubscribe();
  }

  setupTable() {
    this.dataSource = new MatTableDataSource(this.subusers);

    this.datasourceLength = this.subusers.length;
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLocaleLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  masterToggle() {
    this.isAllSelected ?
        this.selection.clear() :
        this.dataSource.data.forEach(row => this.selection.select(row));
  }

  get isOneSelected() {
    return this.selection.selected.length == 1;
  }

  get isMoreThanOneSelected() {
    return this.selection.selected.length > 1;
  }
  
  get isAllSelected() {
    return this.dataSource.data.length === this.selection.selected.length;
  }
 
  onSelect(subuser: ApplicationUser) {

    this.selection.toggle(subuser);

    // if multiple or none selected - remove details
    if(this.selection.selected.length > 1 || this.selection.isEmpty()) {
      this.subuserSelectedEvent.emit(null);
      return;
    }

    // new selection
    this.subuserSelectedEvent.emit(subuser);
  }

  onDeleteSelection() {
    this.deleteSelectionEvent.emit(this.selection.selected);
  }

}
