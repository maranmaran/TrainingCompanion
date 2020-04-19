import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { filter, take } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { TableAction, TableConfig } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTrainingProgram, trainingProgramDeleted } from 'src/ngrx/training-program/training-program/training-program.actions';
import { trainingPrograms } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { TrainingProgramCreateEditComponent } from '../training-program-create-edit/training-program-create-edit.component';

@Component({
  selector: 'app-training-program-list',
  templateUrl: './training-program-list.component.html',
  styleUrls: ['./training-program-list.component.scss']
})
export class TrainingProgramListComponent implements OnInit {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'TRAINING_PROGRAM.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<TrainingProgram>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private trainingProgramService: TrainingProgramService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {

    // table config
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as unknown as CustomColumn[];

    this.subs.add(

      // handle mobile page size of table
      this.store.select(isMobile).subscribe(mobile => this.tableConfig.pagingOptions.pageSize = mobile ? 5 : 10),

      // get data for table datasource
      this.store.select(trainingPrograms).subscribe((trainingPrograms: TrainingProgram[]) => this.tableDatasource.updateDatasource([...trainingPrograms]))
    )

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {

    const tableConfig = new TableConfig({
      filterFunction: (data: TrainingProgram, filter: string) => data.name.trim().toLocaleLowerCase().indexOf(filter) !== -1,
      cellActions: [TableAction.update, TableAction.delete],
      headerActions: [TableAction.create, TableAction.deleteMany],
      pagingOptions: {
        pageSizeOptions: [5, 10, 15],
        pageSize: 10,
        serverSidePaging: false
      },
      selectionEnabled: false,
      defaultSort: 'name',
      defaultSortDirection: 'desc'
    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        headerClass: 'trainingProgram-header',
        cellClass: 'trainingProgram-cell',
        definition: 'name',
        title: 'TRAINING_PROGRAM.PROGRAM_NAME_LABEL',
        sort: true,
        displayFn: (item: TrainingProgram) => item.name,
      }),
    ]
  }

  onSelect = (trainingProgram: TrainingProgram) => this.store.dispatch(setSelectedTrainingProgram({ entity: trainingProgram }));

  onAdd() {

    const dialogRef = this.uiService.openDialogFromComponent(TrainingProgramCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '60rem',
      autoFocus: true,
      data: { title: 'TRAINING_PROGRAM.ADD_TITLE', action: CRUD.Create, trainingProgram: new TrainingProgram() },
      panelClass: []
    })

    dialogRef.afterClosed()
      .pipe(take(1))
      .subscribe((trainingProgram: TrainingProgram) => {
        console.log('here');
        if (!trainingProgram) return;

        console.log(trainingProgram)
        this.table.onSelect(trainingProgram, true);
        this.onSelect(trainingProgram);
      })
  }

  onUpdate(trainingProgram: TrainingProgram) {

    const dialogRef = this.uiService.openDialogFromComponent(TrainingProgramCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '60rem',
      autoFocus: true,
      data: { title: 'TRAINING_PROGRAM.UPDATE_TITLE', action: CRUD.Update, trainingProgram: Object.assign({}, trainingProgram) },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1), filter(program => !!program)).subscribe((trainingProgram: TrainingProgram) => (this.table.onSelect(trainingProgram, true), this.onSelect(trainingProgram)))
  }

  onDeleteSingle(trainingProgram: TrainingProgram) {

    this.deleteDialogConfig.message = this.translateService.instant('TRAINING_PROGRAM.DELETE_DIALOG', { trainingProgram: trainingProgram.name })

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.deleteTrainingProgram(trainingProgram);
        }
      })
  }

  deleteTrainingProgram(trainingProgram) {
    this.trainingProgramService.delete(trainingProgram.id)
      .subscribe(
        _ => {
          this.store.dispatch(trainingProgramDeleted({ id: trainingProgram.id }))
        },
        err => console.log(err)
      )
  }

}
