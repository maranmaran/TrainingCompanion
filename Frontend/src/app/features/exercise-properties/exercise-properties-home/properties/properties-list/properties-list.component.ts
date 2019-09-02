import { ExercisePropertyTypeService } from 'src/business/services/feature-services/exercise-property-type.service';
import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { distinctUntilChanged, map, switchMap, filter, concatMap, mergeMap, flatMap, take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/active-flag/active-flag.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CustomColumn, TableConfig, TableDatasource } from 'src/business/shared/table-data';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import { SubSink } from 'subsink';
import { ExercisePropertyType } from '../../../../../../server-models/entities/exercise-property-type.model';
import { selectedExercisePropertyType, selectedExercisePropertyTypeId } from 'src/ngrx/exercise-property-type/exercise-property-type.selectors';
import { ExercisePropertyService } from 'src/business/services/feature-services/exercise-property.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { forkJoin, combineLatest } from 'rxjs';
import { selectedExercise } from 'src/ngrx/training/training.selectors';
import { setSelectedExerciseProperty } from 'src/ngrx/exercise-property-type/exercise-property-type.actions';
import { PropertiesCreateEditComponent } from '../properties-create-edit/properties-create-edit.component';
import { CRUD } from 'src/business/shared/crud.enum';

@Component({
  selector: 'app-properties-list',
  templateUrl: './properties-list.component.html',
  styleUrls: ['./properties-list.component.scss']
})
export class PropertiesListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<ExerciseProperty>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  private propertyTypeName: string;

  constructor(
    private propertyService: ExercisePropertyService,
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.subs.add(

      this.store.select(selectedExercisePropertyType)
      .pipe(
        filter(propertyType => !!propertyType),
      )
      .subscribe((propertyType: ExercisePropertyType) => {
        this.propertyTypeName = propertyType.type;
        this.tableDatasource.updateDatasource(propertyType.properties);
      })

    );

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: ExerciseProperty, filter: string) => data.value.toLocaleLowerCase().indexOf(filter) !== -1
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
        title: '',
        displayOnMobile: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        useComponent: true,
        component: ActiveFlagComponent,
        inputs: (item: ExercisePropertyType) => { return { active: item.active } },
      }),
    ]
  }

  onSelect = (property: ExerciseProperty) => this.store.dispatch(setSelectedExerciseProperty({ property }));

  onAdd() {
    const dialogRef = this.uiService.openDialogFromComponent(PropertiesCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: `Add ${this.propertyTypeName} property`, action: CRUD.Create },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((property: ExerciseProperty) => {
        if (property) {
          this.table.onSelect(property, true);
          this.onSelect(property);
        }
      }
      )
  }

  onUpdate(exerciseProperty: ExerciseProperty) {
    const dialogRef = this.uiService.openDialogFromComponent(PropertiesCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: `Update ${this.propertyTypeName} property`, action: CRUD.Update, exerciseProperty: exerciseProperty },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((property: ExerciseProperty) => {
        if (property) {
          this.table.onSelect(property, true);
          this.onSelect(property);
        }
      }
      )
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
