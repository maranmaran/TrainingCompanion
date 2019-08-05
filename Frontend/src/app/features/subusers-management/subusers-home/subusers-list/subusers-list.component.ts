import { CustomColumn, TableDatasource } from './../../../../../business/shared/table-data';
import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { TableConfig, TableData } from 'src/business/shared/table-data';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-subusers-list',
  templateUrl: './subusers-list.component.html',
  styleUrls: ['./subusers-list.component.scss']
})
export class SubusersListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  @Input() subusers$: Observable<ApplicationUser[]>

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<ApplicationUser>;

  @Output() subuserSelectedEvent = new EventEmitter<ApplicationUser>();
  @Output() deleteSubuserEvent = new EventEmitter<ApplicationUser>();
  @Output() deleteSelectionEvent = new EventEmitter<ApplicationUser[]>();

  constructor() { }

  ngOnInit() {
    this.subs.add(
      this.subusers$.subscribe(subusers => {
        this.tableDatasource = new TableDatasource(subusers);
        this.tableConfig = new TableConfig();
        this.tableColumns = this.getTableColumns();
      })
    );
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableColumns() {
    return [{
      definition: 'name',
      title: 'Name',
      displayFunction: (item: ApplicationUser) => `${item.firstName} ${item.lastName}`,
      sort: true
    }]
  }

  onSelect(subuser: ApplicationUser) {
    this.subuserSelectedEvent.emit(subuser);
  }

  onDeleteSingle(subuser: ApplicationUser) {
    this.deleteSubuserEvent.emit(subuser);
  }

  onDeleteSelection(subusers: ApplicationUser[]) {
    this.deleteSelectionEvent.emit(subusers);
  }

}

