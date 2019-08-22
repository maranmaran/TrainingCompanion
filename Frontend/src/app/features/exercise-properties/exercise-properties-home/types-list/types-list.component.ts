import { Component, OnInit, ViewChild } from '@angular/core';
import { SubSink } from 'subsink';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { TableConfig, CustomColumn, TableDatasource } from 'src/business/shared/table-data';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { UIService } from 'src/business/services/shared/ui.service';
import { ExercisePropertyTypeService } from 'src/business/services/exercise-property-type.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { exercisePropertyTypes } from 'src/ngrx/exercise-property-management/exercise-property-type/exercise-property-type.selectors';
import { CRUD } from 'src/business/shared/crud.enum';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-types-list',
  templateUrl: './types-list.component.html',
  styleUrls: ['./types-list.component.scss']
})
export class TypesListComponent implements OnInit {

  private subs = new SubSink();
  private deleteDialogConfig =  new ConfirmDialogConfig({ title: 'Delete action',  confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<ExercisePropertyType>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private exercisePropertyTypeService: ExercisePropertyTypeService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns();

    this.subs.add(
      this.store.select(exercisePropertyTypes)
        .subscribe((propertyTypes: ExercisePropertyType[]) => {
          this.tableDatasource.updateDatasource(propertyTypes);
      }))

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: ExercisePropertyType, filter: string) => data.type.toLocaleLowerCase().indexOf(filter) !== -1

    return tableConfig;
  }

  getTableColumns() {
    return [
      {
        definition: 'order',
        title: '#',
        sort: true,
        headerClass: 'order-header',
        cellClass: 'order-cell',
        displayFunction: (item: ExercisePropertyType) => `${item.order + 1}.`,
      },
      {
        definition: 'type',
        title: 'Type',
        sort: true,
        headerClass: 'type-header',
        cellClass: 'type-cell',
        displayFunction: (item: ExercisePropertyType) => item.type,
      },
      {
        definition: 'active',
        title: 'Active',
        sort: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        displayFunction: (item: ExercisePropertyType) => item.active ? `<i class="fas fa-check active"></i>` : `<i class="fas fa-times not-active"></i>`,
      },
      {
        definition: 'hexColor',
        title: 'Tag color',
        sort: false,
        headerClass: 'hex-header',
        cellClass: 'hex-cell',
        displayFunction: (item: ExercisePropertyType) => `<div class="hex-color-column" style="background-color: ${item.hexColor}"></div>`,
      }
    ]
  }

  onSelect = (propertyType: ExercisePropertyType) => {};//this.store.dispatch(setSelectedPropertyType({propertyType}));

  onAdd() {
    // const dialogRef = this.uiService.openDialogFromComponent(AthleteCreateEditComponent, {
    //   height: 'auto',
    //   width: '98%',
    //   maxWidth: '20rem',
    //   autoFocus: false,
    //   data: { title: 'Add athlete', action: CRUD.Create },
    //   panelClass: []
    // })

    // dialogRef.afterClosed().pipe(take(1))
    //   .subscribe((athlete: ApplicationUser) => {
    //       if (athlete) {
    //         this.table.onSelect(athlete, true);
    //         this.onSelect(athlete);
    //       }
    //     }
    //   )
  }

  onUpdate(propertyType: ExercisePropertyType) {
    // const dialogRef = this.uiService.openDialogFromComponent(AthleteCreateEditComponent, {
    //   height: 'auto',
    //   width: '98%',
    //   maxWidth: '20rem',
    //   autoFocus: false,
    //   data: { title: 'Update athlete', action: CRUD.Update, athlete: athlete },
    //   panelClass: []
    // })

    // dialogRef.afterClosed().pipe(take(1))
    //   .subscribe((athlete: ApplicationUser) => {
    //       if (athlete) {
    //         this.table.onSelect(athlete, true);
    //         this.onSelect(athlete);
    //       }
    //     }
    //   )
  }

  onDeleteSingle(propertyType: ExercisePropertyType) {

    // this.deleteDialogConfig.message =
    //   `<p>Are you sure you wish to delete type ${propertyType.type} ?</p>
    //  <p>All data will be lost if you delete this type.</p>`;

    // var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    // dialogRef.afterClosed().pipe(take(1))
    //   .subscribe((result: ConfirmResult) => {
    //     if(result == ConfirmResult.Confirm) {
    //       this.userService.delete(athlete.id, AccountType.Athlete)
    //         .subscribe(
    //           () => {
    //             this.store.dispatch(deleteAthlete(athlete))
    //           },
    //           err => console.log(err)
    //         )
    //     }
    //   })
  }

  onDeleteSelection(propertyTypes: ExercisePropertyType[]) {

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
}
