import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
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

@Component({
  selector: 'app-bodyweight-list',
  templateUrl: './bodyweight-list.component.html',
  styleUrls: ['./bodyweight-list.component.scss']
})
export class BodyweightListComponent implements OnInit, OnDestroy {

  private _unitSystem: UnitSystem;
  private lastLoggedValue: number = 0;

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<Bodyweight>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private bodyweightService: BodyweightService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as unknown as CustomColumn[];

    this.store.select(unitSystem).subscribe(system => this._unitSystem = system);

    this.subs.add(
      this.store.select(bodyweights)
        .subscribe((bodyweights: Bodyweight[]) => {
          this.lastLoggedValue = bodyweights[0]?.value ?? 0;
          this.tableDatasource.updateDatasource([...bodyweights]);
        }))

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {

    const tableConfig = new TableConfig({
      filterFunction: (data: Bodyweight, filter: string) =>  {

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

    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        headerClass: 'bodyweight-header',
        cellClass: 'bodyweight-cell',
        definition: 'value',
        title: 'Bodyweight',
        sort: true,
        defaultSort: true,
        sortAsc: 'asc',
        displayFn: (item: Bodyweight) => transformWeight(item.value, this._unitSystem),
      }),
      new CustomColumn({
        definition: 'date',
        title: 'Date',
        sort: true,
        displayFn: (item: Bodyweight) => moment(item.date).format('D, MMM'),
      }),
    ]
  }

  onSelect = (bodyweight: Bodyweight) => this.store.dispatch(setSelectedBodyweight({ entity: bodyweight }));

  onAdd() {
    var bodyweight = new Bodyweight();
    bodyweight.value = this.lastLoggedValue;

    const dialogRef = this.uiService.openDialogFromComponent(BodyweightCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'Add bodyweight', action: CRUD.Create, bodyweight },
      panelClass: []
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
      data: { title: 'Update bodyweight', action: CRUD.Update, bodyweight: Object.assign({}, bodyweight) },
      panelClass: []
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

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete
      bodyweight record of ${transformWeight(bodyweight.value, this._unitSystem)}
      on ${moment(bodyweight.date).format('D, MMM')}?</p>`;

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.deleteBodyweight(bodyweight);
        }
      })
  }

  onDeleteSelection(bodyweights: Bodyweight[]) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete all (${bodyweights.length}) selected bodyweights ?</p>
     <p>All data will be lost if you delete these bodyweights.</p>`;

    this.deleteDialogConfig.action = (bodyweights: Bodyweight[]) => {
      for(let bodyweight in bodyweights) {
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
