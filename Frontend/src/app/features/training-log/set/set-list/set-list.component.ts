import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { map, take } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { TableConfig } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { UnitSystemService } from 'src/business/services/shared/unit-system.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUserId, userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedExercise, selectedExerciseSets } from 'src/ngrx/training-log/training/training.selectors';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Set } from 'src/server-models/entities/set.model';
import { UserSetting } from 'src/server-models/entities/user-settings.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { SubSink } from 'subsink';
import { SetCreateEditComponent } from '../set-create-edit/set-create-edit.component';

@Component({
  selector: 'app-set-list',
  templateUrl: './set-list.component.html',
  styleUrls: ['./set-list.component.scss'],
  providers: [UnitSystemService]
})
export class SetListComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<Set>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  private userId: string;
  private userSettings: UserSetting;
  private exerciseType: ExerciseType;
  private sets: Set[];

  constructor(
    private unitSystemService: UnitSystemService,
    private uiService: UIService,
    private trainingService: TrainingService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);
    this.store.select(userSetting).pipe(take(1)).subscribe(settings => this.userSettings = settings);
    this.store.select(selectedExercise).pipe(take(1), map(exercise => exercise.exerciseType)).subscribe(type => {
      this.tableColumns = this.getTableColumns(type) as CustomColumn[];
    });

    this.subs.add(
      this.store.select(selectedExerciseSets)
        .pipe(map(sets => sets || []))
        .subscribe((sets: Set[]) => {
          this.sets = sets;
          this.tableDatasource.updateDatasource(sets);
        }),
    );

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    // tableConfig.filterFunction = (data: Set, filter: string) => data.weight.name.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.pageSizeOptions = [5];

    tableConfig.selectionEnabled = false;
    tableConfig.filterEnabled = false;
    tableConfig.editManyEnabled = true;
    tableConfig.addEnabled = false;
    tableConfig.editEnabled = false;
    tableConfig.deleteEnabled = false;
    tableConfig.disableEnabled = false;

    return tableConfig;
  }

  getTableColumns(exerciseType: ExerciseType) {
    var columns: CustomColumn[] = [];

    if (exerciseType.requiresWeight) {
      columns.push(
        new CustomColumn({
          definition: 'weight',
          title: 'Weight',
          sort: true,
          displayFunction: (item: Set) => this.unitSystemService.transformWeight(item.weight), // transform
        }));
    }
    if (exerciseType.requiresReps) {
      columns.push(
        new CustomColumn({
          definition: 'reps',
          title: 'Reps',
          sort: true,
          displayFunction: (item: Set) => item.reps,
        }));
    }
    if (exerciseType.requiresBodyweight) {
      columns.push(
        new CustomColumn({
          definition: 'bodyweight',
          title: 'Bodyweight',
          sort: true,
          displayFunction: (item: Set) => 'Bodyweight', // transform
        }));
    }
    if (exerciseType.requiresTime) {
      columns.push(
        new CustomColumn({
          definition: 'time',
          title: 'Time',
          sort: true,
          displayFunction: (item: Set) => item.time, // transform
        }));
    }
    if (this.userSettings.useRpeSystem) {
      columns.push(
        new CustomColumn({
          definition: this.userSettings.rpeSystem,
          title: this.userSettings.rpeSystem == RpeSystem.Rpe ? 'RPE' : 'RIR',
          sort: true,
          displayFunction: (item: Set) => this.userSettings.rpeSystem == RpeSystem.Rpe ? item.rpe : 10 - item.rpe, // transform
        }));
    }

    return columns;
  }

  // onSelect = (set: Set) => this.store.dispatch(setSelectedSet({ entity: set }));

  onAdd() {

    // const dialogRef = this.uiService.openDialogFromComponent(SetCreateEditComponent, {
    //   height: 'auto',
    //   width: '98%',
    //   maxWidth: '50rem',
    //   autoFocus: false,
    //   data: { action: CRUD.Update, exerciseType: this.exerciseType, sets: this.sets },
    //   panelClass: []
    // })

    // dialogRef.afterClosed().pipe(take(1))
    //   .subscribe((set: Set) => {
    //       if (set) {
    //         this.table.onSelect(set, true);
    //         this.onSelect(set);
    //       }
    //     }
    //   )
  }

  onUpdateMany(set: Set) {

    const dialogRef = this.uiService.openDialogFromComponent(SetCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '50rem',
      autoFocus: false,
      data: { title: 'Update sets', action: CRUD.Update, sets: this.sets },
      panelClass: 'sets-dialog-container',
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((set: Set) => {
        if (set) {
          this.table.onSelect(set, true);
          // this.onSelect(set);
        }
      }
      )

  }

  onDeleteSingle(set: Set) {

    // this.deleteDialogConfig.message =
    //   `<p>Are you sure you wish to delete type ${set.type} ?</p>
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

  onDeleteSelection(sets: Set[]) {

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
