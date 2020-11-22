import { exerciseCount, exercises } from './../../../../../ngrx/exercise/exercise.selectors';
import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { forkJoin, noop } from 'rxjs';
import { concatMap, map, take, tap } from 'rxjs/operators';
import { ExerciseTypePreviewComponent } from 'src/app/shared/custom-preview-components/exercise-type-preview/exercise-type-preview.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { TableAction, TableConfig, TablePagingOptions } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training.actions';
import { reorderExercises, setSelectedExercise } from 'src/ngrx/exercise/exercise.actions';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';
import { selectedTraining, selectedTrainingId } from '../../../../../ngrx/training-log/training.selectors';
import { ExerciseCreateEditComponent } from '../exercise-create-edit/exercise-create-edit.component';
import { unitSystem } from './../../../../../ngrx/auth/auth.selectors';
import { UnitSystem } from './../../../../../server-models/enums/unit-system.enum';

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.scss'],
})
export class ExerciseListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'TRAINING_LOG.EXERCISE_DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<Exercise>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  private userId: string;
  private unitSystem: UnitSystem;

  constructor(
    private uiService: UIService,
    private exerciseService: ExerciseService,
    private exerciseTypeService: ExerciseTypeService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);
    this.store.select(unitSystem).pipe(take(1)).subscribe(system => this.unitSystem = system);

    this.subs.add(
      this.store.select(exercises)
        .pipe(map(exercises => exercises || []))
        .subscribe((exercises: Exercise[]) => {
          this.tableDatasource.updateDatasource([...exercises]);
        }));

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig({
      filterFunction: (data: Exercise, filter: string) => data.exerciseType.name.toLocaleLowerCase().indexOf(filter) !== -1,
      enableDragAndDrop: true,
      cellActions: [TableAction.delete],
      pagingOptions: new TablePagingOptions({
        pageSizeOptions: [5]
      }),
    });

    this.store.select(exerciseCount).pipe(take(1))
    .subscribe(count => count > 5 ? tableConfig.pagingOptions.pageSizeOptions = [...tableConfig.pagingOptions.pageSizeOptions, count] : noop)

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
        displayFn: (item: Exercise) => `${item.order + 1}.`,
      }),
      new CustomColumn({
        definition: 'exercise',
        title: 'TRAINING_LOG.EXERCISE_LABEL',
        sort: true,
        sortFn: (item: Exercise) => item.exerciseType.name,
        useComponent: true,
        component: ExerciseTypePreviewComponent,
        componentInputs: (item: Exercise) => ({ exerciseType: item.exerciseType }),
      }),
      new CustomColumn({
        definition: 'sets',
        title: 'TRAINING_LOG.SETS_LABEL',
        headerClass: 'set-column',
        cellClass: 'set-column',
        sort: true,
        sortFn: (item: Exercise) => item.sets?.length,
        displayFn: (item: Exercise) => item.sets?.length,
      }),
      //TODO: Changes for watts, distance, time etc
      new CustomColumn({
        definition: 'max',
        title: 'TRAINING_LOG.PROJECTED_MAX',
        headerClass: 'max-column',
        cellClass: 'max-column',
        sort: true,
        sortFn: (item: Exercise) => item.sets.map(x => x.projectedMax).reduce(this.reduceProjectedMax, 0),
        displayFn: (item: Exercise) => transformWeight(item.sets.map(x => x.projectedMax).reduce(this.reduceProjectedMax, 0), this.unitSystem),
      })
    ];
  }

  reduceProjectedMax = (prev, cur) => cur >= prev ? cur : prev;

  onReorder(payload: { previous: Exercise, current: Exercise }) {

    this.store.select(selectedTrainingId)
      .pipe(
        tap((trainingId: string) => {
          let previousItem = payload.previous.id;
          let currentItem = payload.current.id;
          this.store.dispatch(reorderExercises({ trainingId, previousItem, currentItem }));
        })
      ).subscribe(_ => { })
  }

  onSelect = (exercise: Exercise) => {
    this.store.dispatch(setSelectedExercise({ entity: exercise }));
  }

  onAdd() {
    var pagingModel = new PagingModel();

    forkJoin([
      this.exerciseTypeService.getPaged(this.userId, pagingModel).pipe(take(1)),
      this.store.select(selectedTraining).pipe(take(1), map(training => {
        const len = training.exercises?.length;
        const model = new Exercise();
        model.order = len;
        return model;
      }))
    ]).subscribe(([exerciseTypes, exercise]) => {

      const dialogRef = this.uiService.openDialogFromComponent(ExerciseCreateEditComponent, {
        height: 'auto',
        width: '98%',
        maxWidth: '50rem',
        autoFocus: false,
        data: { title: 'TRAINING_LOG.EXERCISE_ADD_TITLE', action: CRUD.Create, exercise, exerciseTypes, pagingModel },
        panelClass: ["dialog-container", "exercise-create-edit-dialog"]
      });

      dialogRef.afterClosed().pipe(take(1))
        .subscribe((exercise: Exercise) => {
          if (exercise) {
            this.table.onSelect(exercise, true);
            this.onSelect(exercise);
          }
        });
    });
  }

  onDeleteSingle(exercise: Exercise) {

    this.deleteDialogConfig.message = this.translateService.instant('TRAINING_LOG.EXERCISE_DELETE_DIALOG', { name: exercise.exerciseType.name });

    const dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result === ConfirmResult.Confirm) {

          this.exerciseService.delete(exercise.id)
            .pipe(
              take(1),
              concatMap(() => this.store.select(selectedTraining)),
              take(1),
              map(training => Object.assign({}, training))
            )
            .subscribe(
              (training: Training) => {

                const trainingUpdate: Update<Training> = {
                  id: training.id,
                  changes: {
                    exercises: training.exercises.filter(item => item.id !== exercise.id)
                  }
                };

                this.store.dispatch(trainingUpdated({ entity: trainingUpdate }));
              },
              err => console.log(err)
            );

        }
      });
  }

  onDeleteSelection(exercises: Exercise[]) {

    this.deleteDialogConfig.message = this.translateService.instant('TRAINING_LOG.EXERCISE_DELETE_DIALOG', { length: exercises.length });

    // tslint:disable-next-line: no-shadowed-variable
    this.deleteDialogConfig.action = (exercises: Exercise[]) => {
      console.log('delete');
      console.log(exercises);
    };

    this.deleteDialogConfig.actionParams = [exercises];

    this.uiService.openConfirmDialog(this.deleteDialogConfig);
  }
}
