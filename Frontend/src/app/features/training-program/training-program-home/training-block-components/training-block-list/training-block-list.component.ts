import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs/internal/Observable';
import { filter, take } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { TableAction, TableConfig } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { TrainingBlockService } from 'src/business/services/feature-services/training-block.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { reorderTrainingBlock, setSelectedTrainingBlock, trainingBlockDeleted } from 'src/ngrx/training-program/training-block/training-block.actions';
import { trainingBlocks } from 'src/ngrx/training-program/training-block/training-block.selectors';
import { BlockDurationType, TrainingBlock, TrainingProgram } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { TrainingBlockCreateEditComponent } from '../training-block-create-edit/training-block-create-edit.component';
import { selectedTrainingProgram } from './../../../../../../ngrx/training-program/training-program/training-program.selectors';

@Component({
  selector: 'app-training-block-list',
  templateUrl: './training-block-list.component.html',
  styleUrls: ['./training-block-list.component.scss']
})
export class TrainingBlockListComponent implements OnInit, OnDestroy {

  selectedTrainingProgram: Observable<TrainingProgram>;

  private subs = new SubSink();

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<TrainingBlock>;
  @ViewChild(MaterialTableComponent, { static: false }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private trainingBlockService: TrainingBlockService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {

    this.selectedTrainingProgram = this.store.select(selectedTrainingProgram);

    // table config
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as unknown as CustomColumn[];

    this.subs.add(
      // get data for table datasource
      this.store.select(trainingBlocks).subscribe((trainingBlocks: TrainingBlock[]) => this.tableDatasource.updateDatasource([...trainingBlocks]))
    )

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {

    const tableConfig = new TableConfig({
      filterFunction: (data: TrainingBlock, filter: string) => data.name.trim().toLocaleLowerCase().indexOf(filter) !== -1,
      cellActions: [TableAction.update, TableAction.delete],
      headerActions: [TableAction.create, TableAction.deleteMany],
      pagingOptions: {
        pageSizeOptions: [5, 10, 15],
        pageSize: 5,
        serverSidePaging: false
      },
      enableDragAndDrop: true,
      defaultSort: 'order',
      defaultSortDirection: 'asc'
    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        definition: 'order',
        title: '#',
        sort: true,
        sortFn: (item: TrainingBlock) => item.order,
        headerClass: 'order-header',
        cellClass: 'order-cell',
        displayFn: (item: TrainingBlock) => `${item.order + 1}.`,
      }),
      new CustomColumn({
        headerClass: 'trainingBlock-header',
        cellClass: 'trainingBlock-cell',
        definition: 'name',
        title: 'TRAINING_BLOCK.NAME_LABEL',
        sort: false,
        displayFn: (item: TrainingBlock) => item.name,
      }),
      new CustomColumn({
        headerClass: 'duration-header',
        cellClass: 'duration-cell',
        definition: 'duration',
        title: 'TRAINING_BLOCK.DURATION',
        sort: false,
        displayFn: (item: TrainingBlock) =>
          this.translateService.instant(item.durationType == BlockDurationType.Weeks ? 'TRAINING_BLOCK.WEEKS' : 'TRAINING_BLOCK.DAYS', { number: item.durationType == BlockDurationType.Weeks ? item.duration / 7 : item.duration }),
      }),
    ]
  }

  onSelect = (trainingBlock: TrainingBlock) => this.store.dispatch(setSelectedTrainingBlock({ entity: trainingBlock }));

  onReorder(payload: { previous: TrainingBlock, current: TrainingBlock }) {
    let previousItem = payload.previous.id;
    let currentItem = payload.current.id;
    this.store.dispatch(reorderTrainingBlock({ previousItem, currentItem }));
  }

  onAdd() {

    const dialogRef = this.uiService.openDialogFromComponent(TrainingBlockCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '25rem',
      autoFocus: true,
      data: { title: 'TRAINING_BLOCK.ADD_TITLE', action: CRUD.Create, trainingBlock: new TrainingBlock({ order: this.tableDatasource.data.length, durationType: BlockDurationType.Weeks }) },
      panelClass: ["dialog-container"]
    })

    dialogRef.afterClosed()
      .pipe(take(1))
      .subscribe((trainingBlock: TrainingBlock) => {
        if (!trainingBlock) return;

        this.table.onSelect(trainingBlock, true);
        this.onSelect(trainingBlock);
      })
  }

  onUpdate(trainingBlock: TrainingBlock) {

    const dialogRef = this.uiService.openDialogFromComponent(TrainingBlockCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '25rem',
      autoFocus: true,
      data: { title: 'TRAINING_BLOCK.UPDATE_TITLE', action: CRUD.Update, trainingBlock: Object.assign({}, trainingBlock) },
      panelClass: ["dialog-container"]
    })

    dialogRef.afterClosed().pipe(take(1), filter(program => !!program)).subscribe((trainingBlock: TrainingBlock) => (this.table.onSelect(trainingBlock, true), this.onSelect(trainingBlock)))
  }

  onDeleteSingle(trainingBlock: TrainingBlock) {

    let deleteDialogConfig = new ConfirmDialogConfig({ title: 'TRAINING_BLOCK.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

    deleteDialogConfig.message = this.translateService.instant('TRAINING_BLOCK.DELETE_DIALOG', { trainingBlock: trainingBlock.name })

    var dialogRef = this.uiService.openConfirmDialog(deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.deleteTrainingBlock(trainingBlock);
        }
      })
  }

  deleteTrainingBlock(trainingBlock) {
    this.trainingBlockService.delete(trainingBlock.id)
      .subscribe(
        _ => {
          this.store.dispatch(trainingBlockDeleted({ id: trainingBlock.id }))
        },
        err => console.log(err)
      )
  }

}
