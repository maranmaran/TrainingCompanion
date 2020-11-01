import { Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { TableAction, TableConfig } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTraining, trainingDeleted } from 'src/ngrx/training-log/training.actions';
import { trainings } from 'src/ngrx/training-log/training.selectors';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';
import { TrainingCreateEditComponent } from '../training-create-edit/training-create-edit.component';

@Component({
  selector: 'app-training-list',
  templateUrl: './training-list.component.html',
  styleUrls: ['./training-list.component.scss']
})
export class TrainingListComponent implements OnInit, OnDestroy {

  @Input() partOfTrainingProgram = false;

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'TRAINING_LOG.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<Training>;
  @ViewChild(MaterialTableComponent, { static: false }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private trainingService: TrainingService,
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
      this.store.select(trainings).subscribe((trainings: Training[]) => this.tableDatasource.updateDatasource([...trainings]))
    )
  }


  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {

    const tableConfig = new TableConfig({
      filterFunction: (data: Training, filter: string) => moment(data.dateTrained).format('L').toString().indexOf(filter) !== -1,
      cellActions: [TableAction.update, TableAction.delete],
      headerActions: [TableAction.create, TableAction.deleteMany],
      pagingOptions: {
        pageSizeOptions: [5, 10, 15],
        pageSize: 10,
        serverSidePaging: false
      },
      defaultSort: 'dateTrained',
      defaultSortDirection: 'desc'
    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        headerClass: 'training-header',
        cellClass: 'training-cell',
        definition: 'dateTrained',
        title: 'TRAINING_LOG.TRAINING_DATE',
        sort: true,
        displayFn: (item: Training) => moment(item.dateTrained).format('L, LT'),
      }),
    ]
  }

  onSelect = (training: Training) => this.store.dispatch(setSelectedTraining({ entity: training }));

  onAdd() {
    this.trainingService.onAdd(TrainingCreateEditComponent, null)
      .afterClosed()
      .pipe(take(1))
      .subscribe((training: Training) => {
        if (!training) return;

        this.table.onSelect(training, true);
        this.onSelect(training);
      });
  }

  onDeleteSingle(training: Training) {

    this.deleteDialogConfig.message = this.translateService.instant('TRAINING_LOG.DELETE_DIALOG', { dateTrained: moment(training.dateTrained).format('L') });

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.deleteTraining(training);
        }
      })
  }

  deleteTraining(training) {
    this.trainingService.delete(training.id)
      .subscribe(
        _ => {
          this.store.dispatch(trainingDeleted({ id: training.id }))
        },
        err => console.log(err)
      )
  }

}
