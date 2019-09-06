import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { concatMap, map, take } from 'rxjs/operators';
import { ExerciseTypePreviewComponent } from 'src/app/shared/exercise-type-preview/exercise-type-preview.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { CustomColumn, TableConfig, TableDatasource } from 'src/business/shared/table-data';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';
import { ExerciseCreateEditComponent } from '../exercise-create-edit/exercise-create-edit.component';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { Update } from '@ngrx/entity';
import { selectedExercises, selectedTraining } from 'src/ngrx/training-log/training/training.selectors';
import { setSelectedExercise, trainingUpdated } from 'src/ngrx/training-log/training/training.actions';

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.scss'],
  providers: [ExerciseTypeService]
})
export class ExerciseListComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  private deleteDialogConfig =  new ConfirmDialogConfig({ title: 'Delete action',  confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<Exercise>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;
  
  private userId: string;

  constructor(
    private uiService: UIService,
    private trainingService: TrainingService,
    private exerciseTypeService: ExerciseTypeService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);

    this.subs.add(
      this.store.select(selectedExercises)
        .pipe(map(exercises => exercises || []))
        .subscribe((exercises: Exercise[]) => {
          this.tableDatasource.updateDatasource(exercises);
      }));

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: Exercise, filter: string) => data.exerciseType.name.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.enableDragAndDrop = true;
    tableConfig.pageSizeOptions = [5];

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        definition: 'exercise',
        title: 'Exercise',
        sort: true,
        useComponent: true,
        component: ExerciseTypePreviewComponent,
        inputs: (item: Exercise) => { return {exerciseType: item.exerciseType}; },
      })
    ]
  }

  onSelect = (exercise: Exercise) => this.store.dispatch(setSelectedExercise({exercise}));

  onAdd() {
    this.exerciseTypeService.getAll(this.userId).pipe(take(1))
    .subscribe((exerciseTypes: ExerciseType[]) => {
      const dialogRef = this.uiService.openDialogFromComponent(ExerciseCreateEditComponent, {
        height: 'auto',
        width: '98%',
        maxWidth: '50rem',
        autoFocus: false,
        data: { title: 'Add exercise', action: CRUD.Create, exerciseTypes },
        panelClass: []
      })
  
      dialogRef.afterClosed().pipe(take(1))
        .subscribe((exercise: Exercise) => {
            if (exercise) {
              this.table.onSelect(exercise, true);
              this.onSelect(exercise);
            }
          }
        )
    });
  }

  onUpdate(exercise: Exercise) {
    this.exerciseTypeService.getAll(this.userId).pipe(take(1))
    .subscribe((exerciseTypes: ExerciseType[]) => {
      const dialogRef = this.uiService.openDialogFromComponent(ExerciseCreateEditComponent, {
        height: 'auto',
        width: '98%',
        maxWidth: '50rem',
        autoFocus: false,
        data: { title: 'Add exercise', action: CRUD.Update, exercise, exerciseTypes },
        panelClass: []
      })
  
      dialogRef.afterClosed().pipe(take(1))
        .subscribe((exercise: Exercise) => {
            if (exercise) {
              this.table.onSelect(exercise, true);
              this.onSelect(exercise);
            }
          }
        )
    });
  }

  onDeleteSingle(exercise: Exercise) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete ${exercise.exerciseType.name} ?</p>
     <p>All data will be lost if you delete this exercise.</p>`;

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.store.select(selectedTraining).pipe(
            take(1),
            map(training => Object.assign({}, training)),
            concatMap((training: Training) => {
              training.exercises = training.exercises.filter(item => item.id != exercise.id);
              console.log(training);
              return this.trainingService.update(training);
            }),
            take(1))
            .subscribe((training: Training) => {
              
              const trainingUpdate: Update<Training> = {
                id: training.id,
                changes: training
              };

              this.store.dispatch(trainingUpdated({ training: trainingUpdate }));
            });
        }
      });
  }

  onDeleteSelection(exercises: Exercise[]) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete all (${exercises.length}) selected exercises ?</p>
     <p>All data will be lost if you delete these exercises.</p>`;

    this.deleteDialogConfig.action = (exercises: Exercise[]) => {
      console.log('delete');
      console.log(exercises);
    }

    this.deleteDialogConfig.actionParams = [exercises];

    this.uiService.openConfirmDialog(this.deleteDialogConfig)
  }
}
