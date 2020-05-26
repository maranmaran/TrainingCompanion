import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { map, take } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { TableAction, TableConfig, TablePagingOptions } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { UIService } from 'src/business/services/shared/ui.service';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { exercisePrs, selectedExercise, selectedExerciseSets } from 'src/ngrx/training-log/training.selectors';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Set } from 'src/server-models/entities/set.model';
import { UserSetting } from 'src/server-models/entities/user-settings.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { SubSink } from 'subsink';
import { SetCreateEditComponent } from '../set-create-edit/set-create-edit.component';
import { PersonalBest } from './../../../../../server-models/entities/personal-best.model';

@Component({
  selector: 'app-set-list',
  templateUrl: './set-list.component.html',
  styleUrls: ['./set-list.component.scss'],
})
export class SetListComponent implements OnInit, OnDestroy {
  private subs = new SubSink();

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<Set>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  private userSettings: UserSetting;
  private _personalBests: PersonalBest[];
  private sets: Set[];

  constructor(
    private uiService: UIService,
    private store: Store<AppState>,
  ) { }

  ngOnInit() {
    this.store.select(exercisePrs).pipe(take(1)).subscribe(prs => this._personalBests = prs);

    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();

    this.subs.add(

      combineLatest(
        this.store.select(userSetting),
        this.store.select(selectedExercise).pipe(map(exercise => exercise?.exerciseType))
      ).subscribe(([userSetting, exerciseType]) => {
        this.userSettings = userSetting;

        if (!!exerciseType)
          this.tableColumns = this.getTableColumns(exerciseType) as CustomColumn[]
      }),

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
    const tableConfig = new TableConfig({
      selectionEnabled: false,
      pagingOptions: new TablePagingOptions({
        pageSizeOptions: [5]
      }),
      cellActions: [TableAction.dummy],
      headerActions: [TableAction.updateMany]
    })

    return tableConfig;
  }

  getTableColumns(exerciseType: ExerciseType) {
    var columns: CustomColumn[] = [];

    if (exerciseType.requiresWeight) {
      columns.push(
        new CustomColumn({
          definition: 'weight',
          title: 'TRAINING_LOG.SET_WEIGHT',
          sort: true,
          displayFn: (item: Set) => transformWeight(item.weight, this.userSettings.unitSystem), // transform
        }));
    }
    if (exerciseType.requiresReps) {
      columns.push(
        new CustomColumn({
          definition: 'reps',
          title: 'TRAINING_LOG.SET_REPS',
          sort: true,
          displayFn: (item: Set) => item.reps,
        }));
    }
    if (exerciseType.requiresBodyweight) {
      columns.push(
        new CustomColumn({
          definition: 'bodyweight',
          title: 'TRAINING_LOG.SET_BODYWEIGHT',
          sort: true,
          displayFn: (item: Set) => 'Bodyweight', // transform
        }));
    }
    if (exerciseType.requiresTime) {
      columns.push(
        new CustomColumn({
          definition: 'time',
          title: 'TRAINING_LOG.SET_TIME',
          sort: true,
          displayFn: (item: Set) => item.time, // transform
        }));
    }
    if (this.userSettings.useRpeSystem) {
      columns.push(
        new CustomColumn({
          definition: this.userSettings.rpeSystem,
          title: this.userSettings.rpeSystem == RpeSystem.Rpe ? 'TRAINING_LOG.SET_RPE' : 'TRAINING_LOG.SET_RIR',
          sort: true,
          displayFn: (item: Set) => this.userSettings.rpeSystem == RpeSystem.Rpe ? item.rpe : 10 - item.rpe, // transform
        }));
    }

    return columns;
  }

  onUpdateMany() {

    const dialogRef = this.uiService.openDialogFromComponent(SetCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '50rem',
      autoFocus: false,
      data: {
        title: 'TRAINING_LOG.SET_UPDATE_TITLE',
        action: CRUD.Update,
        sets: this.sets,
        prs: this._personalBests
      },
      panelClass: 'sets-dialog-container',
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((set: Set) => {
        if (set) {
          this.table.onSelect(set, true);
          // this.onSelect(set);
        }
      })
  }

}
