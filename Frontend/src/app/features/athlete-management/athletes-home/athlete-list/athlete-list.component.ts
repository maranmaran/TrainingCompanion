import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/custom-preview-components/active-flag/active-flag.component';
import { TableAction, TableConfig } from "src/app/shared/material-table/table-models/table-config.model";
import { UserService } from 'src/business/services/feature-services/user.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { athleteDeleted, setSelectedAthlete } from 'src/ngrx/athletes/athlete.actions';
import { athletes } from 'src/ngrx/athletes/athlete.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { AccountType } from 'src/server-models/enums/account-type.enum';
import { SubSink } from 'subsink';
import { ApplicationUser } from '../../../../../server-models/entities/application-user.model';
import { CustomColumn } from "../../../../shared/material-table/table-models/custom-column.model";
import { TableDatasource } from "../../../../shared/material-table/table-models/table-datasource.model";
import { AthleteCreateEditComponent } from '../athlete-create-edit/athlete-create-edit.component';
import { CRUD } from './../../../../../business/shared/crud.enum';
import { MaterialTableComponent } from './../../../../shared/material-table/material-table.component';

@Component({
  selector: 'app-athlete-list',
  templateUrl: './athlete-list.component.html',
  styleUrls: ['./athlete-list.component.scss']
})
export class AthleteListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<ApplicationUser>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private userService: UserService,
    private store: Store<AppState>,
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as unknown as CustomColumn[];

    this.subs.add(
      this.store.select(athletes)
        .subscribe((athletes: ApplicationUser[]) => {
          this.tableDatasource.updateDatasource(athletes);
        }))

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig({
      filterFunction: (data: ApplicationUser, filter: string) => data.fullName.trim().toLocaleLowerCase().indexOf(filter) !== -1 ||
        data.firstName.trim().toLocaleLowerCase().indexOf(filter) !== -1 ||
        data.lastName.trim().toLocaleLowerCase().indexOf(filter) !== -1,
      cellActions: [TableAction.update, TableAction.delete],
      selectionEnabled: false,
      filterEnabled: true,
    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        headerClass: 'avatar-header',
        cellClass: 'avatar-cell',
        definition: 'avatar',
        title: '',
        displayFn: (item: ApplicationUser) => `<img class="avatar-table-img avatar-img" src="${item.avatar}"/>`,
      }),
      new CustomColumn({
        definition: 'fullName',
        title: 'ATHLETE_MANAGEMENT.FULL_NAME',
        sort: true,
        displayFn: (item: ApplicationUser) => item.fullName,
      }),
      new CustomColumn({
        definition: 'active',
        title: '',
        displayOnMobile: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        useComponent: true,
        component: ActiveFlagComponent,
        componentInputs: (item: ApplicationUser) => { return { active: item.active } },
      }),
    ]
  }

  onSelect = (athlete: ApplicationUser) => this.store.dispatch(setSelectedAthlete({ entity: athlete }));

  onAdd(event) {
    const dialogRef = this.uiService.openDialogFromComponent(AthleteCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'ATHLETE_MANAGEMENT.ADD_TITLE', action: CRUD.Create },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((athlete: ApplicationUser) => {
        if (athlete) {
          this.table.onSelect(athlete, true);
          this.onSelect(athlete);
        }
      }
      )
  }

  onUpdate(athlete: ApplicationUser) {
    const dialogRef = this.uiService.openDialogFromComponent(AthleteCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'ATHLETE_MANAGEMENT.UPDATE_TITLE', action: CRUD.Update, athlete: athlete },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((athlete: ApplicationUser) => {
        if (athlete) {
          this.table.onSelect(athlete, true);
          this.onSelect(athlete);
        }
      }
      )
  }

  onDeleteSingle(athlete: ApplicationUser) {

    //TODO i18n
    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete user ${athlete.firstName} ${athlete.lastName} ?</p>
     <p>All data will be lost if you delete this user.</p>`;

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.userService.delete(athlete.id, AccountType.Athlete)
            .subscribe(
              () => {
                this.store.dispatch(athleteDeleted({ id: athlete.id }))
              },
              err => console.log(err)
            )
        }
      })
  }

  // onDeleteSelection(athletes: ApplicationUser[]) {

  //   this.deleteDialogConfig.message =
  //     `<p>Are you sure you wish to delete all (${athletes.length}) selected users ?</p>
  //    <p>All data will be lost if you delete these users.</p>`;

  //   this.deleteDialogConfig.action = (athletes: ApplicationUser[]) => {
  //     console.log('delete');
  //     console.log(athletes);
  //   }

  //   this.deleteDialogConfig.actionParams = [athletes];

  //   this.uiService.openConfirmDialog(this.deleteDialogConfig)
  // }
}
