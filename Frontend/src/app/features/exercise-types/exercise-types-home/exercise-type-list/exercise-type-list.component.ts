import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { ExerciseTypePreviewComponent } from 'src/app/shared/exercise-type-preview/exercise-type-preview.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { CustomColumn, TableConfig, TableDatasource } from 'src/business/shared/table-data';
import { setSelectedExerciseType } from 'src/ngrx/exercise-type/exercise-type.actions';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { SubSink } from 'subsink';
import { ExerciseTypeCreateEditComponent } from './../exercise-type-create-edit/exercise-type-create-edit.component';

@Component({
  selector: 'app-exercise-type-list',
  templateUrl: './exercise-type-list.component.html',
  styleUrls: ['./exercise-type-list.component.scss']
})
export class ExerciseTypeListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<ExerciseType>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  exerciseTypeControl = new FormControl();
  exerciseTypes: ExerciseType[] = [];

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
          this.exerciseTypes = exerciseTypes;
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
        inputs: (item: ExerciseType) => { return { exerciseType: item }; },
      }),
    ]
  }

  onSelect = (exerciseType: ExerciseType) => this.store.dispatch(setSelectedExerciseType({ exerciseType }));

  // TODO: Refactor these onAdd onUpdate methods.. make them more resuable and also define each table actions properly
  onAdd() {
    const dialogRef = this.uiService.openDialogFromComponent(ExerciseTypeCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '50rem',
      autoFocus: false,
      data: { title: 'Add exercise type', action: CRUD.Create },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1))
    .subscribe((type: ExerciseType) => {
        if (type) {
          this.table.onSelect(type, true);
          this.onSelect(type);
        }
      }
    )
  }

  onUpdate(exerciseType: ExerciseType) {
    const dialogRef = this.uiService.openDialogFromComponent(ExerciseTypeCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '50rem',
      autoFocus: false,
      data: { title: `Update ${exerciseType.name}`, action: CRUD.Update, entity: exerciseType },
      panelClass: ['exercise-type-dialog-container']
    })

    dialogRef.afterClosed().pipe(take(1))
    .subscribe((type: ExerciseType) => {
        if (type) {
          this.table.onSelect(type, true);
          this.onSelect(type);
        }
      }
    )
  }

  onDeleteSingle(exerciseType: ExerciseType) {

    // this.deleteDialogConfig.message =
    //   `<p>Are you sure you wish to delete type ${tagGroup.type} ?</p>
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
