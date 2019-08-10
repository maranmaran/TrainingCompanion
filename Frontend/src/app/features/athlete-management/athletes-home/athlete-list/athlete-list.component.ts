import { CRUD } from './../../../../../business/shared/crud.enum';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { TableConfig } from 'src/business/shared/table-data';
import { setSelectedAthlete } from 'src/ngrx/athletes/athlete.actions';
import { athletes } from 'src/ngrx/athletes/athlete.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SubSink } from 'subsink';
import { CustomColumn, TableDatasource } from '../../../../../business/shared/table-data';
import { ApplicationUser } from '../../../../../server-models/entities/application-user.model';
import { AthleteCreateEditComponent } from '../athlete-create-edit/athlete-create-edit.component';

@Component({
  selector: 'app-athlete-list',
  templateUrl: './athlete-list.component.html',
  styleUrls: ['./athlete-list.component.scss']
})
export class AthleteListComponent implements OnInit, OnDestroy {

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
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = new TableConfig();
    this.tableColumns = this.getTableColumns();

    this.subs.add(
      this.store.select(athletes)
        .subscribe((athletes: ApplicationUser[]) => {
          this.tableDatasource.updateDatasource(athletes);
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

  onSelect(athlete: ApplicationUser) {
    this.store.dispatch(setSelectedAthlete({athlete}));;
  }

  onAdd() {
    this.uiService.openDialogFromComponent(AthleteCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'Add athlete', action: CRUD.Create },
      panelClass: []
    })
  }

  onUpdate() {

  }

  onDeleteSingle(athlete: ApplicationUser) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete user ${athlete.firstName} ${athlete.lastName} ?</p>
     <p>All data will be lost if you delete this user.</p>`;

    this.deleteDialogConfig.action = function(athlete) {
      console.log('delete');
      console.log(athlete);
    };

    this.deleteDialogConfig.actionParams = [athlete];

    this.uiService.openConfirmDialog(this.deleteDialogConfig);
  }

  onDeleteSelection(athletes: ApplicationUser[]) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete all (${athletes.length}) selected users ?</p>
     <p>All data will be lost if you delete these users.</p>`;

    this.deleteDialogConfig.action = (athletes: ApplicationUser[]) => {
      console.log('delete');
      console.log(athletes);
    }

    this.deleteDialogConfig.actionParams = [athletes];

    this.uiService.openConfirmDialog(this.deleteDialogConfig)
  }
}

