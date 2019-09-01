import { TypesCreateEditComponent } from './../types-create-edit/types-create-edit.component';
import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { map, take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/active-flag/active-flag.component';
import { ExerciseTypeChipComponent } from 'src/app/shared/exercise-type-preview/exercise-type-chip/exercise-type-chip.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { ExercisePropertyTypeService } from 'src/business/services/feature-services/exercise-property-type.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CustomColumn, TableConfig, TableDatasource } from 'src/business/shared/table-data';
import { sortArrayByOrderProperty } from 'src/business/utils/utils';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { SubSink } from 'subsink';
import { CRUD } from 'src/business/shared/crud.enum';
import { allExercisePropertyTypes } from 'src/ngrx/exercise-property-type/exercise-property-type.selectors';
import { setSelectedExercisePropertyType, reorderExercisePropertyTypes } from 'src/ngrx/exercise-property-type/exercise-property-type.actions';

@Component({
  selector: 'app-types-list',
  templateUrl: './types-list.component.html',
  styleUrls: ['./types-list.component.scss']
})
export class TypesListComponent implements OnInit, OnDestroy {

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
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.subs.add(
      this.store.select(allExercisePropertyTypes)
        .subscribe((propertyTypes: ExercisePropertyType[]) => {
          this.tableDatasource.updateDatasource(propertyTypes);
      }));

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: ExercisePropertyType, filter: string) => data.type.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.enableDragAndDrop = true;
    tableConfig.pageSizeOptions = [5];

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
        displayFunction: (item: ExercisePropertyType) => `${item.order + 1}.`,
      }),
      new CustomColumn({
        definition: 'type',
        title: 'Type',
        sort: true,
        headerClass: 'type-header',
        cellClass: 'type-cell',
        displayFunction: (item: ExercisePropertyType) => item.type,
      }),
      new CustomColumn({
        definition: 'active',
        title: '',
        displayOnMobile: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        useComponent: true,
        component: ActiveFlagComponent,
        inputs: (item: ExercisePropertyType) => { return {active: item.active } },
      }),
      new CustomColumn({
        definition: 'hexColor',
        title: '',
        displayOnMobile: false,
        headerClass: 'hex-header',
        cellClass: 'hex-cell',
        useComponent: true,
        component: ExerciseTypeChipComponent,
        inputs: (item: ExercisePropertyType) => {return {value: "Tag", show: true, backgroundColor: item.hexBackground, color: item.hexColor}},
      }),
    ]
  }

  onSelect = (propertyType: ExercisePropertyType) => this.store.dispatch(setSelectedExercisePropertyType({propertyType}));

  onReorder(payload: {previous: ExercisePropertyType, current: ExercisePropertyType}) {
    let previousItem = payload.previous.id;
    let currentItem = payload.current.id;
    this.store.dispatch(reorderExercisePropertyTypes({previousItem, currentItem }));
  }
  onAdd() {
    const dialogRef = this.uiService.openDialogFromComponent(TypesCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'Add exercise property type', action: CRUD.Create },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1)).subscribe((propertyType: ExercisePropertyType) => this.postCreateUpdate(propertyType));
  }

  onUpdate(propertyType: ExercisePropertyType) {

    const dialogRef = this.uiService.openDialogFromComponent(TypesCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'Update exercise property type', action: CRUD.Update, exercisePropertyType: propertyType },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1)).subscribe((propertyType: ExercisePropertyType) => this.postCreateUpdate(propertyType));
  }

  postCreateUpdate(propertyType: ExercisePropertyType) {
    if (propertyType) {
      this.table.onSelect(propertyType, true);
      this.onSelect(propertyType);
    }
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
