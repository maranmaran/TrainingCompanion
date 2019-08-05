import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { TableConfig } from 'src/business/shared/table-data';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { subusers, selectedSubuser } from 'src/ngrx/subusers/subuser.selectors';
import { SubSink } from 'subsink';
import { CustomColumn, TableDatasource } from './../../../../../business/shared/table-data';
import { ApplicationUser } from './../../../../../server-models/entities/application-user.model';
import { setSelectedSubuser } from 'src/ngrx/subusers/subuser.actions';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-subusers-list',
  templateUrl: './subusers-list.component.html',
  styleUrls: ['./subusers-list.component.scss']
})
export class SubusersListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig =  new ConfirmDialogConfig({ title: 'Delete action',  confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<ApplicationUser>;

  constructor(
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.subs.add(
      this.store.select(subusers)
        .subscribe((subusers: ApplicationUser[]) => {
          this.tableDatasource = new TableDatasource(subusers);
          this.tableConfig = new TableConfig();
          this.tableColumns = this.getTableColumns();
      }))

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
    this.store.dispatch(setSelectedSubuser({subuser}));;
  }

  onAdd() {
    console.log('add');
  }

  onDeleteSingle(subuser: ApplicationUser) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete user ${subuser.firstName} ${subuser.lastName} ?</p>
     <p>All data will be lost if you delete this user.</p>`;

    this.deleteDialogConfig.action = function(subuser) {
      console.log('delete');
      console.log(subuser);
    };

    this.deleteDialogConfig.actionParams = [subuser];

    this.uiService.openConfirmDialog(this.deleteDialogConfig);
  }

  onDeleteSelection(subusers: ApplicationUser[]) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete all (${subusers.length}) selected users ?</p>
     <p>All data will be lost if you delete these users.</p>`;

    this.deleteDialogConfig.action = (subusers: ApplicationUser[]) => {
      console.log('delete');
      console.log(subusers);
    }

    this.deleteDialogConfig.actionParams = [subusers];

    this.uiService.openConfirmDialog(this.deleteDialogConfig)
  }
}

