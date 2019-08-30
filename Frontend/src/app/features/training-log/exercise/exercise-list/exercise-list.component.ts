import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { SubSink } from 'subsink';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { TableConfig, CustomColumn, TableDatasource } from 'src/business/shared/table-data';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { UIService } from 'src/business/services/shared/ui.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ActiveFlagComponent } from 'src/app/shared/active-flag/active-flag.component';
import { ExerciseTypeChipComponent } from 'src/app/shared/exercise-type-preview/exercise-type-chip/exercise-type-chip.component';
import { TrainingService } from 'src/business/services/training.service';
import { setSelectedExercise } from 'src/ngrx/training/training.actions';
import { Observable } from 'rxjs';
import { exercises } from 'src/ngrx/training/training.selectors';
import { ExerciseTypeService } from 'src/business/services/exercise-type.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { take } from 'rxjs/operators';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { ExerciseCreateEditComponent } from '../exercise-create-edit/exercise-create-edit.component';
import { CRUD } from 'src/business/shared/crud.enum';
import { ExerciseTypePreviewComponent } from 'src/app/shared/exercise-type-preview/exercise-type-preview.component';

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.scss'],
  providers: [ExerciseTypeService]
})
export class ExerciseListComponent implements OnInit {
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
      this.store.select(exercises)
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
      }),
      // new CustomColumn({
      //   definition: 'active',
      //   title: '',
      //   displayOnMobile: false,
      //   headerClass: 'active-header',
      //   cellClass: 'active-cell',
      //   useComponent: true,
      //   component: ActiveFlagComponent,
      //   inputs: (item: Exercise) => { return {active: item.active } },
      // }),
      // new CustomColumn({
      //   definition: 'hexColor',
      //   title: '',
      //   displayOnMobile: false,
      //   headerClass: 'hex-header',
      //   cellClass: 'hex-cell',
      //   useComponent: true,
      //   component: ExerciseTypeChipComponent,
      //   inputs: (item: Exercise) => {return {value: "Tag", show: true, backgroundColor: item.hexBackground, color: item.hexColor}},
      // }),
    ]
  }

  onSelect = (exercise: Exercise) => this.store.dispatch(setSelectedExercise({exercise}));

  onAdd() {
      // const dialogRef = this.uiService.openDialogFromComponent(ExerciseCreateEditComponent, {
      //   height: 'auto',
      //   width: '98%',
      //   maxWidth: '50rem',
      //   autoFocus: false,
      //   data: { title: 'Add exercise', action: CRUD.Create, exerciseTypes },
      //   panelClass: []
      // })
  
      // dialogRef.afterClosed().pipe(take(1))
      //   .subscribe((exercise: Exercise) => {
      //       if (exercise) {
      //         this.table.onSelect(exercise, true);
      //         this.onSelect(exercise);
      //       }
      //     }
      //   )
  }

  onUpdate(exercise: Exercise) {
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

  onDeleteSingle(exercise: Exercise) {

    // this.deleteDialogConfig.message =
    //   `<p>Are you sure you wish to delete type ${exercise.type} ?</p>
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

  onDeleteSelection(exercises: Exercise[]) {

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
