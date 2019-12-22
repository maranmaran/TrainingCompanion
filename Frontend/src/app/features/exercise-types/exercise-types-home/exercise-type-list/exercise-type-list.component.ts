import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Store } from '@ngrx/store';
import * as _ from "lodash";
import { concatMap, map, take } from 'rxjs/operators';
import { ExerciseTypePreviewComponent } from 'src/app/shared/exercise-type-preview/exercise-type-preview.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { CustomColumn, TableConfig, TableDatasource } from 'src/business/shared/table-data';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { setSelectedExerciseType } from 'src/ngrx/exercise-type/exercise-type.actions';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { SubSink } from 'subsink';
import { TagGroupService } from './../../../../../business/services/feature-services/tag-group.service';
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
    private tagGroupService: TagGroupService,
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
          this.tableDatasource.updateDatasource([...exerciseTypes]);
        }));

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: ExerciseType, filter: string) => data.name.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.enableDragAndDrop = false;

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
        inputs: (item: ExerciseType) => {
          return {
                  exerciseType: item,
                };
        },
      }),
      new CustomColumn({
        definition: 'code',
        title: 'Code',
        sort: false,
        useComponent: false,
        displayFunction: (item: ExerciseType) => item.code
      }),
    ]
  }

  onSelect = (exerciseType: ExerciseType) => this.store.dispatch(setSelectedExerciseType({ entity: exerciseType }));

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
    // prerequisite data
    // can't filter included data https://github.com/aspnet/EntityFrameworkCore/issues/1833
    // do it in frontend...
    this.store
      .select(currentUserId)
      .pipe(
        concatMap((userId: string) => {
          return this.tagGroupService.getAll(userId);
        }),
        map((groups: TagGroup[]) => groups.map(group => {
          // filter out assigned tags and unactive tags
          group.tags = group.tags.filter(tag => !!tag.active && exerciseType.properties.find(x => x.tagId !== tag.id));
          return group;
        })),
      )
      .subscribe(
        (tagGroups: TagGroup[]) => {
          tagGroups = _.sortBy(tagGroups, ['type']);
          this.openUpdateDialog(exerciseType, tagGroups);
        },
        err => console.log(err)
      );
  }

  openUpdateDialog(exerciseType: ExerciseType, tagGroups: TagGroup[]) {
    const dialogRef = this.uiService.openDialogFromComponent(ExerciseTypeCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '30rem',
      // maxHeight: '50vh',
      autoFocus: false,
      data: { title: `Update ${exerciseType.name}`, action: CRUD.Update, entity: exerciseType, tagGroups},
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
