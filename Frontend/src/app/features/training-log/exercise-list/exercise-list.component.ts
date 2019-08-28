import { Component, OnInit, ViewChild } from '@angular/core';
import { SubSink } from 'subsink';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { TableConfig, CustomColumn, TableDatasource } from 'src/business/shared/table-data';
import { Exercise } from 'src/server-models/entities/Exercise';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { UIService } from 'src/business/services/shared/ui.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ActiveFlagComponent } from 'src/app/shared/active-flag/active-flag.component';
import { ExerciseTypeChipComponent } from 'src/app/shared/exercise-type-preview/exercise-type-chip/exercise-type-chip.component';

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.scss']
})
export class ExerciseListComponent implements OnInit {
  private subs = new SubSink();
  private deleteDialogConfig =  new ConfirmDialogConfig({ title: 'Delete action',  confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<Exercise>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;
  
  constructor(
    private uiService: UIService,
    private exerciseService: ExerciseService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

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
        definition: 'type',
        title: 'Type',
        sort: true,
        headerClass: 'type-header',
        cellClass: 'type-cell',
        // displayFunction: (item: Exercise) => ,
      }),
      new CustomColumn({
        definition: 'active',
        title: '',
        displayOnMobile: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        useComponent: true,
        component: ActiveFlagComponent,
        inputs: (item: Exercise) => { return {active: item.active } },
      }),
      new CustomColumn({
        definition: 'hexColor',
        title: '',
        displayOnMobile: false,
        headerClass: 'hex-header',
        cellClass: 'hex-cell',
        useComponent: true,
        component: ExerciseTypeChipComponent,
        inputs: (item: Exercise) => {return {value: "Tag", show: true, backgroundColor: item.hexBackground, color: item.hexColor}},
      }),
    ]
  }

  onSelect = (exercise: Exercise) => this.store.dispatch(setSelectedExercise({exercise}));

  onReorder(payload: {previous: Exercise, current: Exercise}) {
    let previousItem = payload.previous.id;
    let currentItem = payload.current.id;
    this.store.dispatch(reorderExercises({previousItem, currentItem }));
  }
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
