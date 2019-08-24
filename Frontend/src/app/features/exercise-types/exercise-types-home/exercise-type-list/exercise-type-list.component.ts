import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { ExerciseTypeService } from 'src/business/services/exercise-type.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CustomColumn, TableConfig, TableDatasource } from 'src/business/shared/table-data';
import { setSelectedExerciseType } from 'src/ngrx/exercise-type/exercise-type.actions';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { SubSink } from 'subsink';
import { ExerciseTypePreviewComponent } from 'src/app/shared/exercise-type-preview/exercise-type-preview.component';

@Component({
  selector: 'app-exercise-type-list',
  templateUrl: './exercise-type-list.component.html',
  styleUrls: ['./exercise-type-list.component.scss']
})
export class ExerciseTypeListComponent implements OnInit {

  private subs = new SubSink();
  private deleteDialogConfig =  new ConfirmDialogConfig({ title: 'Delete action',  confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<ExerciseType>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;
  
  constructor(
    private uiService: UIService,
    private exerciseTypeService: ExerciseTypeService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.subs.add(
      this.store.select(exerciseTypes)
        .subscribe((exerciseTypes: ExerciseType[]) => {
          this.tableDatasource.updateDatasource(exerciseTypes);
      }));

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: ExerciseType, filter: string) => data.name.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.enableDragAndDrop = true;

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        definition: 'name',
        title: 'Name',
        sort: true,
        useComponent: true,
        component: ExerciseTypePreviewComponent,
        inputs: (item: ExerciseType) => { return {exerciseType: item}; },
      }),
    ]
  }

  onSelect = (exerciseType: ExerciseType) => this.store.dispatch(setSelectedExerciseType({exerciseType}));

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

  onUpdate(exerciseType: ExerciseType) {
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

  onDeleteSingle(exerciseType: ExerciseType) {

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

  onDeleteSelection(exerciseType: ExerciseType[]) {

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
