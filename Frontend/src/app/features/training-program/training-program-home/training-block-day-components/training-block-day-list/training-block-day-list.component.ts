import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { combineLatest, Observable, Subject } from 'rxjs';
import { distinctUntilChanged, filter, startWith, switchMap, take, tap } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/custom-preview-components/active-flag/active-flag.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { TableAction, TableConfig } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { TrainingBlockDayService } from 'src/business/services/feature-services/training-block-day.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTrainingBlockDay, trainingBlockDayDeleted, trainingBlockDayFetched } from 'src/ngrx/training-program/training-block-day/training-block-day.actions';
import { trainingBlockDays } from 'src/ngrx/training-program/training-block-day/training-block-day.selectors';
import { TrainingBlockDay } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { TrainingBlockDayCreateEditComponent } from '../training-block-day-create-edit/training-block-day-create-edit.component';
import { selectedTrainingBlockDay } from './../../../../../../ngrx/training-program/training-block-day/training-block-day.selectors';
import { selectedTrainingBlockId } from './../../../../../../ngrx/training-program/training-block/training-block.selectors';

@Component({
  selector: 'app-training-block-day-list',
  templateUrl: './training-block-day-list.component.html',
  styleUrls: ['./training-block-day-list.component.scss']
})
export class TrainingBlockDayListComponent implements OnInit {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'TRAINING_BLOCK_DAY.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

  hasMoreData = true;
  pagingModel: PagingModel;
  pageChange = new Subject<PagingModel>();

  selectedDay: Observable<TrainingBlockDay>

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

    this.selectedDay = this.store.select(selectedTrainingBlockDay);

    this.subs.add(

      this.onTrainingBlockSelected(), // fetch blocks data

      this.store.select(selectedTrainingBlockId).pipe(
        distinctUntilChanged()
      ).subscribe(id => {
        this.pagingModel = new PagingModel({pageSize: 28})
        this.pageChange.next(this.pagingModel);
      }),

      // get data for table datasource
      combineLatest(
        this.store.select(trainingBlockDays),
        this.pageChange.pipe(startWith(this.pagingModel)),
      ).pipe(
        tap(([data, paging]) => this.hasMoreData = (paging.page + 1) * paging.pageSize < data.length)
      )
      .subscribe(([data, paging]) => {

        data = this.doSlice(data, paging);
        this.tableDatasource.updateDatasource([...data])
      })
    )

  }

  doSlice(data, paging) {
    const from = paging.page * paging.pageSize;
    const to = from + paging.pageSize;
    return data.slice(from, to);
  }

  onNextPage() {
    console.log('next')
    if(this.hasMoreData) {

      this.pagingModel.page += 1;
      this.pageChange.next(this.pagingModel);
    }
  }

  onPreviousPage() {
    console.log('previous')
    if(this.pagingModel.page == 0) return;

    this.pagingModel.page -= 1;
    this.hasMoreData = true;
    this.pageChange.next(this.pagingModel);
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
      filterFunction: (data: TrainingBlockDay, filter: string) => data.order.toString().toLocaleLowerCase().indexOf(filter) !== -1,
      cellActions: [TableAction.delete],
      headerActions: [TableAction.create],
      pagingOptions: {
        pageSizeOptions: [5, 10, 15],
        pageSize: 5,
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
        sort: false,
        displayFn: (item: TrainingBlockDay) => `${this.translateService.instant("TRAINING_BLOCK_DAY.DAY_LABEL")} ${item.order}`,
      }),
      new CustomColumn({
        headerClass: 'trainingBlockDay-header',
        cellClass: 'trainingBlockDay-cell',
        definition: 'hasTraining',
        title: 'TRAINING_BLOCK_DAY.HAS_TRAINING',
        sort: false,
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

  onDeleteSingle() {

    this.selectedDay.pipe(take(1)).subscribe(
      (trainingBlockDay: TrainingBlockDay) => {
        this.deleteDialogConfig.message = this.translateService.instant('TRAINING_BLOCK_DAY.DELETE_DIALOG', { trainingBlockDay: `${this.translateService.instant("TRAINING_BLOCK_DAY.DAY_LABEL")} ${trainingBlockDay.order}`})

        var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

        dialogRef.afterClosed().pipe(take(1))
          .subscribe((result: ConfirmResult) => {
            if (result == ConfirmResult.Confirm) {
              this.deleteTrainingBlockDay(trainingBlockDay.id);
            }
          })
      }
    )
  }

  deleteTrainingBlockDay(trainingBlockDayId) {
    this.trainingBlockDayService.delete(trainingBlockDayId)
      .subscribe(
        _ => {
          this.store.dispatch(trainingBlockDayDeleted({ id: trainingBlockDayId }))
        },
        err => console.log(err)
      )
  }

}
