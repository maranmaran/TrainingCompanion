import { Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { TableAction, TableConfig } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { TrainingProgramUserService } from 'src/business/services/feature-services/training-program-user.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingProgramUserDeleted } from 'src/ngrx/training-program/training-program-user/training-program-user.actions';
import { trainingProgramUsers } from 'src/ngrx/training-program/training-program-user/training-program-user.selectors';
import { selectedTrainingProgram } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { SubSink } from 'subsink';
import { TrainingProgramUser } from './../../../../../../../server-models/entities/training-program.model';

@Component({
  selector: 'app-assigned-athletes',
  templateUrl: './assigned-athletes.component.html',
  styleUrls: ['./assigned-athletes.component.scss']
})
export class AssignedAthletesComponent implements OnInit, OnDestroy {

  private subs = new SubSink();

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  @Input() trainingProgramName: string;
  @Input() programUsers$: TrainingProgramUser[];

  tableDatasource: TableDatasource<TrainingProgramUser>;

  constructor(
    private uiService: UIService,
    private trainingProgramUserService: TrainingProgramUserService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {

    // table config
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as unknown as CustomColumn[];

    this.subs.add(
      this.store.select(trainingProgramUsers).subscribe(users => {
        this.tableDatasource.updateDatasource([...users]);
      }),
      this.store.select(selectedTrainingProgram).subscribe(program => {
        this.trainingProgramName = program.name;
      })
    )

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {

    const tableConfig = new TableConfig({
      filterFunction: (data: TrainingProgramUser, filter: string) => data.user.fullName.trim().toLocaleLowerCase().indexOf(filter) !== -1 ||
        data.user.firstName.trim().toLocaleLowerCase().indexOf(filter) !== -1 ||
        data.user.lastName.trim().toLocaleLowerCase().indexOf(filter) !== -1,
      cellActions: [TableAction.delete],
      headerActions: [],
      pagingOptions: {
        pageSizeOptions: [5, 10, 15],
        pageSize: 5,
        serverSidePaging: false
      },
      selectionEnabled: false,
      defaultSort: 'date',
      defaultSortDirection: 'asc'
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
        displayFn: (item: TrainingProgramUser) => `<img class="avatar-table-img avatar-img" src="${item.user.avatar}"/>`,
      }),
      new CustomColumn({
        definition: 'fullName',
        title: 'ATHLETE_MANAGEMENT.FULL_NAME',
        sort: true,
        sortFn: (item: TrainingProgramUser) => item.user.fullName,
        displayFn: (item: TrainingProgramUser) => item.user.fullName,
      }),
      new CustomColumn({
        definition: 'date',
        title: 'TRAINING_PROGRAM.DETAILS.STARTED_ON',
        sort: true,
        sortFn: (item: TrainingProgramUser) => item.startedOn,
        displayFn: (item: TrainingProgramUser) => moment(item.startedOn).format('D, MMM'),
      }),
    ]
  }

  onDeleteSingle(trainingProgramUser: TrainingProgramUser) {

    const deleteDialogConfig = new ConfirmDialogConfig({
      title: 'TRAINING_PROGRAM.DETAILS.UNASSIGN_TITLE',
      confirmLabel: 'TRAINING_PROGRAM.DETAILS.UNASSIGN_BTN_LABEL'
    });

    deleteDialogConfig.message = this.translateService
      .instant('TRAINING_PROGRAM.DETAILS.UNASSIGN_DIALOG', {
        name: trainingProgramUser.user.fullName,
        programName: this.trainingProgramName
      })

    var dialogRef = this.uiService.openConfirmDialog(deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.deleteTrainingProgramUser(trainingProgramUser);
        }
      })
  }

  deleteTrainingProgramUser(trainingProgramUser) {
    this.trainingProgramUserService.delete(trainingProgramUser.id)
      .subscribe(
        _ => {
          this.store.dispatch(trainingProgramUserDeleted({ id: trainingProgramUser.id as string }))
        },
        err => console.log(err)
      )
  }

}
