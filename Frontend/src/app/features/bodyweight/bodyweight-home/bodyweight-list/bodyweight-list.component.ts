import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { selectedBodyweight } from './../../../../../ngrx/bodyweight/bodyweight.selectors';
import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { TableAction, TableConfig } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { BodyweightService } from 'src/business/services/feature-services/bodyweight.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { unitSystem } from 'src/ngrx/auth/auth.selectors';
import { bodyweightDeleted, setSelectedBodyweight } from 'src/ngrx/bodyweight/bodyweight.actions';
import { bodyweights } from 'src/ngrx/bodyweight/bodyweight.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { SubSink } from 'subsink';
import { BodyweightCreateEditComponent } from '../bodyweight-create-edit/bodyweight-create-edit.component';
import { isMobile } from './../../../../../ngrx/user-interface/ui.selectors';

@Component({
  selector: 'app-bodyweight-list',
  templateUrl: './bodyweight-list.component.html',
  styleUrls: ['./bodyweight-list.component.scss']
})
export class BodyweightListComponent implements OnInit, OnDestroy {

  private _unitSystem: UnitSystem;
  private lastLoggedValue: number = 0;

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'BODYWEIGHT.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<Bodyweight>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private bodyweightService: BodyweightService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as unknown as CustomColumn[];


    this.subs.add(
      this.store.select(unitSystem).subscribe(system => this._unitSystem = system),

      this.store.select(isMobile)
        .subscribe(mobile => {
          this.tableConfig.pagingOptions.pageSize = mobile ? 5 : 10;
        }),

      combineLatest([
        this.store.select(bodyweights),
        this.store.select(selectedBodyweight).pipe(take(1)),
      ]).subscribe(([entities, selectedEntity]) => {
        this.lastLoggedValue = bodyweights[0]?.value ?? 0;
        this.tableDatasource.updateDatasource(entities);
        this.tableDatasource.selectElement(selectedEntity);
      }),
    )

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {

    const tableConfig = new TableConfig({
      filterFunction: (data: Bodyweight, filter: string) => {

        return transformWeight(data.value, this._unitSystem).trim().toLocaleLowerCase().indexOf(filter) !== -1 ||
          moment(data.date).format('D, MMM').trim().toLocaleLowerCase().indexOf(filter) !== -1;
      },
      cellActions: [TableAction.update, TableAction.delete],
      headerActions: [TableAction.create, TableAction.deleteMany],
      pagingOptions: {
        pageSizeOptions: [5, 10, 15],
        pageSize: 10,
        serverSidePaging: false
      },
      defaultSort: 'date',
      defaultSortDirection: 'desc'
    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        headerClass: 'bodyweight-header',
        cellClass: 'bodyweight-cell',
        definition: 'value',
        title: 'BODYWEIGHT.BODYWEIGHT_LABEL',
        sort: true,
        displayFn: (item: Bodyweight) => transformWeight(item.value, this._unitSystem),
      }),
      new CustomColumn({
        definition: 'date',
        title: 'SHARED.DATE',
        sort: true,
        displayFn: (item: Bodyweight) => moment(item.date).format('D, MMM'),
      }),
    ]
  }

  onSelect = (bodyweight: Bodyweight) => this.store.dispatch(setSelectedBodyweight({ entity: bodyweight }));

  onAdd() {
    var bodyweight = new Bodyweight();
    bodyweight.value = this.lastLoggedValue;
    bodyweight.date = new Date();

    const dialogRef = this.uiService.openDialogFromComponent(BodyweightCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'BODYWEIGHT.ADD_TITLE', action: CRUD.Create, bodyweight },
      panelClass: ["dialog-container"]
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((bodyweight: Bodyweight) => {
        if (bodyweight) {
          this.table.onSelect(bodyweight, true);
          this.onSelect(bodyweight);
        }
      })
  }

  onUpdate(bodyweight: Bodyweight) {

    const dialogRef = this.uiService.openDialogFromComponent(BodyweightCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'BODYWEIGHT.UPDATE_TITLE', action: CRUD.Update, bodyweight: Object.assign({}, bodyweight) },
      panelClass: ["dialog-container"]
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((bodyweight: Bodyweight) => {
        if (bodyweight) {
          this.table.onSelect(bodyweight, true);
          this.onSelect(bodyweight);
        }
      })
  }

  onDeleteSingle(bodyweight: Bodyweight) {

    this.deleteDialogConfig.message = this.translateService.instant('BODYWEIGHT.DELETE_DIALOG', { bodyweight: transformWeight(bodyweight.value, this._unitSystem), date: moment(bodyweight.date).format('D, MMM') })

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.deleteBodyweight(bodyweight);
        }
      })
  }

  onDeleteSelection(bodyweights: Bodyweight[]) {

    this.deleteDialogConfig.message = this.translateService.instant('BODYWEIGHT.DELETE_SELECTION_DIALOG', { length: bodyweights.length });

    this.deleteDialogConfig.action = (bodyweights: Bodyweight[]) => {
      for (let bodyweight in bodyweights) {
        this.deleteBodyweight(bodyweight);
      }
    }

    this.deleteDialogConfig.actionParams = [bodyweights];

    this.uiService.openConfirmDialog(this.deleteDialogConfig)
  }

  deleteBodyweight(bodyweight) {
    this.bodyweightService.delete(bodyweight.id)
      .subscribe(
        () => {
          this.store.dispatch(bodyweightDeleted({ id: bodyweight.id }))
        },
        err => console.log(err)
      )
  }

}
