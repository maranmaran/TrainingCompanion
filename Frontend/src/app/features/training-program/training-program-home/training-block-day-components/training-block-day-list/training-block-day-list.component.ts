import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { filter, switchMap, take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/custom-preview-components/active-flag/active-flag.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { TableAction, TableConfig } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { TrainingBlockDayService } from 'src/business/services/feature-services/training-block-day.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTrainingBlockDay, trainingBlockDayDeleted, trainingBlockDayFetched } from 'src/ngrx/training-program/training-block-day/training-block-day.actions';
import { trainingBlockDays } from 'src/ngrx/training-program/training-block-day/training-block-day.selectors';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { TrainingBlockDay } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { TrainingBlockDayCreateEditComponent } from '../training-block-day-create-edit/training-block-day-create-edit.component';
import { selectedTrainingBlockId } from './../../../../../../ngrx/training-program/training-block/training-block.selectors';

@Component({
  selector: 'app-training-block-day-list',
  templateUrl: './training-block-day-list.component.html',
  styleUrls: ['./training-block-day-list.component.scss']
})
export class TrainingBlockDayListComponent implements OnInit {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'TRAINING_BLOCK_DAY.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<TrainingBlockDay>;
  @ViewChild(MaterialTableComponent, { static: false }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private trainingBlockDayService: TrainingBlockDayService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {

    // table config
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as unknown as CustomColumn[];

    this.subs.add(

      this.onTrainingBlockSelected(), // fetch blocks data

      // handle mobile page size of table
      this.store.select(isMobile).subscribe(mobile => this.tableConfig.pagingOptions.pageSize = mobile ? 5 : 10),

      // get data for table datasource
      this.store.select(trainingBlockDays).subscribe((trainingBlockDays: TrainingBlockDay[]) => this.tableDatasource.updateDatasource([...trainingBlockDays]))
    )

  }

  onTrainingBlockSelected() {
    return this.store.select(selectedTrainingBlockId)
    .pipe(filter(id => !!id), switchMap(blockId => this.trainingBlockDayService.getAll(blockId as string)))
    .subscribe((blocks: TrainingBlockDay[]) => this.store.dispatch(trainingBlockDayFetched({ entities: blocks })));
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {

    const tableConfig = new TableConfig({
      filterFunction: (data: TrainingBlockDay, filter: string) => data.name.trim().toLocaleLowerCase().indexOf(filter) !== -1,
      cellActions: [TableAction.delete],
      headerActions: [TableAction.create],
      pagingOptions: {
        pageSizeOptions: [5, 10, 15],
        pageSize: 10,
        serverSidePaging: false
      },
      selectionEnabled: false,
      defaultSort: 'name',
      defaultSortDirection: 'asc'
    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        headerClass: 'trainingBlockDay-header',
        cellClass: 'trainingBlockDay-cell',
        definition: 'name',
        title: 'TRAINING_BLOCK_DAY.NAME_LABEL',
        sort: true,
        displayFn: (item: TrainingBlockDay) => item.name.replace("Day", this.translateService.instant("TRAINING_BLOCK_DAY.DAY_LABEL")),
      }),
      new CustomColumn({
        headerClass: 'trainingBlockDay-header',
        cellClass: 'trainingBlockDay-cell',
        definition: 'hasTraining',
        title: 'TRAINING_BLOCK_DAY.HAS_TRAINING',
        sort: true,
        useComponent: true,
        component: ActiveFlagComponent,
        componentInputs: (item: TrainingBlockDay) => { return { active: !item.restDay } },      }),
    ]
  }

  onSelect = (trainingBlockDay: TrainingBlockDay) => this.store.dispatch(setSelectedTrainingBlockDay({ entity: trainingBlockDay }));

  onAdd() {

    const dialogRef = this.uiService.openDialogFromComponent(TrainingBlockDayCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '60rem',
      autoFocus: true,
      data: { title: 'TRAINING_BLOCK_DAY.ADD_TITLE', action: CRUD.Create, trainingBlockDay: new TrainingBlockDay() },
      panelClass: []
    })

    dialogRef.afterClosed()
      .pipe(take(1))
      .subscribe((trainingBlockDay: TrainingBlockDay) => {
        if (!trainingBlockDay) return;

        this.table.onSelect(trainingBlockDay, true);
        this.onSelect(trainingBlockDay);
      })
  }

  onUpdate(trainingBlockDay: TrainingBlockDay) {

    const dialogRef = this.uiService.openDialogFromComponent(TrainingBlockDayCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '60rem',
      autoFocus: true,
      data: { title: 'TRAINING_BLOCK_DAY.UPDATE_TITLE', action: CRUD.Update, trainingBlockDay: Object.assign({}, trainingBlockDay) },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1), filter(program => !!program)).subscribe((trainingBlockDay: TrainingBlockDay) => (this.table.onSelect(trainingBlockDay, true), this.onSelect(trainingBlockDay)))
  }

  onDeleteSingle(trainingBlockDay: TrainingBlockDay) {

    this.deleteDialogConfig.message = this.translateService.instant('TRAINING_BLOCK_DAY.DELETE_DIALOG', { trainingBlockDay: trainingBlockDay.name })

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.deleteTrainingBlockDay(trainingBlockDay);
        }
      })
  }

  deleteTrainingBlockDay(trainingBlockDay) {
    this.trainingBlockDayService.delete(trainingBlockDay.id)
      .subscribe(
        _ => {
          this.store.dispatch(trainingBlockDayDeleted({ id: trainingBlockDay.id }))
        },
        err => console.log(err)
      )
  }

}
