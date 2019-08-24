import { ExercisePropertyType } from './../../../../../server-models/entities/exercise-property-type.model';
import { selectedPropertyType } from '../../../../../ngrx/exercise-property-type/exercise-property-type.selectors';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import { SubSink } from 'subsink';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { TableConfig, CustomColumn, TableDatasource } from 'src/business/shared/table-data';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { UIService } from 'src/business/services/shared/ui.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { map } from 'rxjs/operators';
import { sortArrayByOrderProperty } from 'src/business/utils/utils';

@Component({
  selector: 'app-properties-list',
  templateUrl: './properties-list.component.html',
  styleUrls: ['./properties-list.component.scss']
})
export class PropertiesListComponent implements OnInit {

  private subs = new SubSink();
  private deleteDialogConfig =  new ConfirmDialogConfig({ title: 'Delete action',  confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<ExerciseProperty>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;
  
  constructor(
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.subs.add(
      this.store.select(selectedPropertyType)
        .pipe(map((propertyType: ExercisePropertyType) => {
          return propertyType ? propertyType.properties : []; 
        })) 
        .subscribe((propertyTypes: ExerciseProperty[]) => {
          this.tableDatasource.updateDatasource(propertyTypes);
      }));

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: ExerciseProperty, filter: string) => data.value.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.enableDragAndDrop = true;

    return tableConfig;
  }

  getTableColumns() {
    return [
       new CustomColumn({
        definition: 'order',
        title: '#',
        sort: true,
        headerClass: 'order-header',
        cellClass: 'order-cell',
        displayFunction: (item: ExerciseProperty) => `${item.order + 1}.`,
      }),
      new CustomColumn({
        definition: 'value',
        title: 'Value',
        sort: true,
        displayFunction: (item: ExerciseProperty) => item.value,
      }),
      new CustomColumn({
        definition: 'active',
        title: 'Active',
        displayOnMobile: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        displayFunction: (item: ExerciseProperty) => item.active ? `<i class="fas fa-check active"></i>` : `<i class="fas fa-times not-active"></i>`,
      }),
    ]
  }

  // onSelect = (propertyType: ExerciseProperty) => this.store.dispatch(setSelectedExerciseProperty({propertyType}));

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

  onUpdate(propertyType: ExerciseProperty) {
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

  onDeleteSingle(propertyType: ExerciseProperty) {

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

  onDeleteSelection(propertyTypes: ExerciseProperty[]) {

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
