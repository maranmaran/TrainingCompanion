import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { TableAction, TableConfig, TablePagingOptions } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { getPlaceholderImagePath } from 'src/business/utils/utils';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTrainingProgram, trainingProgramDeleted } from 'src/ngrx/training-program/training-program/training-program.actions';
import { selectedTrainingProgram, trainingPrograms } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { TrainingProgramCreateEditComponent } from '../training-program-create-edit/training-program-create-edit.component';
import { TrainingProgramDetailsComponent } from './../training-program-details/training-program-details.component';

@Component({
  selector: 'app-training-program-list',
  templateUrl: './training-program-list.component.html',
  styleUrls: ['./training-program-list.component.scss']
})
export class TrainingProgramListComponent implements OnInit {

  private subs = new SubSink();

  placeholderImagePath: string;
  selectedProgram: TrainingProgram;

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

    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as unknown as CustomColumn[];

    // table config
    this.subs.add(
      this.store.select(activeTheme).subscribe(theme => this.placeholderImagePath = getPlaceholderImagePath(theme)),
      this.store.select(selectedTrainingProgram).subscribe(program => this.selectedProgram = program),
      this.store.select(trainingPrograms).subscribe((programs: TrainingProgram[]) => {
        this.tableDatasource.updateDatasource(programs);
      }),
    )

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  programId = (program: TrainingProgram) => program.id;

  getTableConfig() {

    const tableConfig = new TableConfig({
      filterEnabled: true,
      filterFunction: (data: TrainingProgram, filter: string) => data.name.trim().toLocaleLowerCase().indexOf(filter) !== -1,
      cellActions: [TableAction.update, TableAction.delete],
      headerActions: [TableAction.create, TableAction.deleteMany],
      pagingOptions: new TablePagingOptions({
        pageSizeOptions: [5, 10, 15],
        pageSize: 5,
        serverSidePaging: false
      }),
      defaultSort: 'name',
      defaultSortDirection: 'asc',
      enableExpandableRows: true,
      expandableRowComponent: TrainingProgramDetailsComponent,
      expandableRowComponentAttributes: { class: 'training-program-details-expanded-row mat-elevation-z6' },
      // expandableRowComponentInputs: (trainingProgram) => ({ trainingProgram: trainingProgram })
    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        headerClass: 'trainingProgram-header',
        cellClass: 'trainingProgram-cell',
        definition: 'name',
        title: 'TRAINING_PROGRAM.PROGRAMS_COLUMN',
        sort: true,
        sortFn: (item: TrainingProgram) => item.name,
        displayFn: (item: TrainingProgram) => item.name,
      }),
    ]
  }

  onSelect(program: TrainingProgram) {
    this.store.dispatch(setSelectedTrainingProgram({ entity: program }))
  }

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

    dialogRef.afterClosed()
      .pipe(take(1))
      .subscribe((trainingProgram: TrainingProgram) => {
        console.log('here');
      })
  }

  onDeleteSingle(trainingProgram: TrainingProgram) {

    let deleteDialogConfig = new ConfirmDialogConfig({ title: 'TRAINING_PROGRAM.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

    deleteDialogConfig.message = this.translateService.instant('TRAINING_PROGRAM.DELETE_DIALOG', { trainingProgram: trainingProgram.name })

    var dialogRef = this.uiService.openConfirmDialog(deleteDialogConfig);

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
