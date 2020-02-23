import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { forkJoin } from 'rxjs';
import { concatMap, map, take, tap } from 'rxjs/operators';
import { ExerciseTypePreviewComponent } from 'src/app/shared/custom-preview-components/exercise-type-preview/exercise-type-preview.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { TableConfig } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { reorderExercises, setSelectedExercise, trainingUpdated } from 'src/ngrx/training-log/training.actions';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';
import { selectedTraining, selectedTrainingExercises, selectedTrainingId } from '../../../../../ngrx/training-log/training.selectors';
import { ExerciseCreateEditComponent } from '../exercise-create-edit/exercise-create-edit.component';

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.scss'],
  providers: [ExerciseTypeService]
})
export class ExerciseListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<Exercise>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  private userId: string;

  constructor(
    private uiService: UIService,
    private trainingService: TrainingService,
    private exerciseService: ExerciseService,
    private exerciseTypeService: ExerciseTypeService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);

    this.subs.add(
      this.store.select(selectedTrainingExercises)
        .pipe(map(exercises => exercises || []))
        .subscribe((exercises: Exercise[]) => {
          this.tableDatasource.updateDatasource([...exercises]);
        }));

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: Exercise, filter: string) => data.exerciseType.name.toLocaleLowerCase().indexOf(filter) !== -1;
    tableConfig.enableDragAndDrop = true;
    tableConfig.pageSizeOptions = [5];
    tableConfig.deleteEnabled = true;
    tableConfig.disableEnabled = false;
    tableConfig.editEnabled = false;

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
        title: 'Exercise',
        sort: true,
        sortFn: (item: Exercise) => item.exerciseType.name,
        useComponent: true,
        component: ExerciseTypePreviewComponent,
        componentInputs: (item: Exercise) => ({ exerciseType: item.exerciseType }),
      })
    ];
  }

  onReorder(payload: { previous: Exercise, current: Exercise }) {
    this.store.select(selectedTrainingId)
      .pipe(
        tap((trainingId: string) => {
          let previousItem = payload.previous.id;
          let currentItem = payload.current.id;
          this.store.dispatch(reorderExercises({ trainingId, previousItem, currentItem }));
        })
      ).subscribe(_ => {})
  }

  onSelect = (exercise: Exercise) => {
    this.store.dispatch(setSelectedExercise({ entity: exercise }));
  }

  onAdd() {
    var pagingModel = new PagingModel();

    forkJoin(
      this.exerciseTypeService.getPaged(this.userId, pagingModel).pipe(take(1)),
      this.store.select(selectedTraining).pipe(take(1), map(training => {
        const len = training.exercises?.length;
        const model = new Exercise();
        model.order = len;
        return model;
      }))
    ).subscribe(([exerciseTypes, exercise]) => {

        const dialogRef = this.uiService.openDialogFromComponent(ExerciseCreateEditComponent, {
          height: 'auto',
          width: '98%',
          maxWidth: '50rem',
          autoFocus: false,
          data: { title: 'Add exercise', action: CRUD.Create, exercise, exerciseTypes, pagingModel },
          panelClass: []
        });

        dialogRef.afterClosed().pipe(take(1))
          .subscribe((exercise: Exercise) => {
            if (exercise) {
              this.table.onSelect(exercise, true);
              // this.onSelect(exercise);
            }
          });
      });
  }

  onDeleteSingle(exercise: Exercise) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete ${exercise.exerciseType.name} ?</p>
     <p>All data will be lost if you delete this exercise.</p>`;

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

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete all (${exercises.length}) selected exercises ?</p>
     <p>All data will be lost if you delete these exercises.</p>`;

    // tslint:disable-next-line: no-shadowed-variable
    this.deleteDialogConfig.action = (exercises: Exercise[]) => {
      console.log('delete');
      console.log(exercises);
    };

    this.deleteDialogConfig.actionParams = [exercises];

    this.uiService.openConfirmDialog(this.deleteDialogConfig);
  }
}
