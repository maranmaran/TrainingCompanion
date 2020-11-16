import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import * as _ from 'lodash-es';
import { concatMap, map, take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/custom-preview-components/active-flag/active-flag.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { TableAction, TableConfig, TablePagingOptions } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { exerciseTypesFetched, exerciseTypeUpdated, setSelectedExerciseType } from 'src/ngrx/exercise-type/exercise-type.actions';
import { exerciseTypes, exerciseTypesPagingModel, exerciseTypesTotalItems, selectedExerciseType } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UpdateExerciseTypeRequest } from 'src/server-models/cqrs/exercise-type/update-exercise-type.request';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { Tag } from 'src/server-models/entities/tag.model';
import { PagedList } from 'src/server-models/shared/paged-list.model';
import { SubSink } from 'subsink';
import { ExerciseTypeService } from './../../../../../business/services/feature-services/exercise-type.service';
import { TagGroupService } from './../../../../../business/services/feature-services/tag-group.service';
import { currentUserId } from './../../../../../ngrx/auth/auth.selectors';
import { ExerciseTypePreviewComponent } from './../../../../shared/custom-preview-components/exercise-type-preview/exercise-type-preview.component';
import { PagingModel } from './../../../../shared/material-table/table-models/paging.model';
import { ExerciseTypeCreateEditComponent } from './../exercise-type-create-edit/exercise-type-create-edit.component';

@Component({
  selector: 'app-exercise-type-list',
  templateUrl: './exercise-type-list.component.html',
  styleUrls: ['./exercise-type-list.component.scss']
})
export class ExerciseTypeListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'EXERCISE_TYPES.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<ExerciseType>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  exerciseTypeControl = new FormControl();
  exerciseTypes: ExerciseType[] = [];
  _userId: string;

  constructor(
    private uiService: UIService,
    private exerciseTypeService: ExerciseTypeService,
    private tagGroupService: TagGroupService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);

    this.subs.add(
      combineLatest([
        this.store.select(exerciseTypes),
        this.store.select(exerciseTypesPagingModel),
        this.store.select(exerciseTypesTotalItems),
        this.store.select(selectedExerciseType).pipe(take(1)),
      ]).subscribe(([entities, pagingModel, totalItems, selectedEntity]) => {

        console.log([entities, pagingModel, totalItems, selectedEntity]);
        
        this.exerciseTypes = entities.slice(0, pagingModel.pageSize);

        this.tableDatasource.updateDatasource([...this.exerciseTypes]);
        this.tableDatasource.selectElement(selectedEntity);

        this.tableDatasource.setPagingModel(Object.assign({}, pagingModel));
        this.tableDatasource.setTotalLength(totalItems);
      }),
    )
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig({
      filterFunction: (data: ExerciseType, filter: string) => data.name.toLocaleLowerCase().indexOf(filter) !== -1,
      pagingOptions: new TablePagingOptions({
        serverSidePaging: true
      }),
      cellActions: [TableAction.update, TableAction.disable],
      filterEnabled: true,
      defaultSort: 'name',
      defaultSortDirection: 'asc'
    });

    return tableConfig;
  }

  getTableColumns() {
    return [
      new CustomColumn({
        definition: 'name',
        title: 'SHARED.NAME',
        sort: true,
        sortFn: (item: ExerciseType) => item.name,
        useComponent: true,
        component: ExerciseTypePreviewComponent,
        componentInputs: (item: ExerciseType) => {
          return {
            exerciseType: item,
          };
        },
      }),
      new CustomColumn({
        definition: 'active',
        title: '',
        displayOnMobile: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        useComponent: true,
        component: ActiveFlagComponent,
        componentInputs: (item: ExerciseType) => { return { active: item.active } },
      }),
      // new CustomColumn({
      //   definition: 'code',
      //   title: 'SHARED.CODE',
      //   headerClass: 'code-header',
      //   cellClass: 'code-cell',
      //   sort: false,
      //   useComponent: false,
      //   displayFn: (item: ExerciseType) => item.code
      // }),
    ]
  }

  onSelect = (exerciseType: ExerciseType) => this.store.dispatch(setSelectedExerciseType({ entity: exerciseType }));

  // TODO: Refactor these onAdd onUpdate methods.. make them more resuable and also define each table actions properly
  onAdd() {
    this.prepareDialog('CREATE');
  }

  onUpdate(exerciseType: ExerciseType) {
    this.prepareDialog('UPDATE', exerciseType);
  }

  prepareDialog(action: 'UPDATE' | 'CREATE', exerciseType?: ExerciseType) {
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
          // only relevant for updating entity...
          if (exerciseType) {

            var filterTags = (tag: Tag) => {
              if (!tag.active)
                return false;

              if (exerciseType.properties.find(x => x.tagId == tag.id))
                return false;

              return true;
            };

            group.tags = group.tags.filter(filterTags);
          }

          return group;
        })),
      )
      .subscribe(
        (tagGroups: TagGroup[]) => {
          tagGroups = _.sortBy(tagGroups, ['type']);

          if (action == 'CREATE')
            this.openAddDialog(tagGroups);

          if (action == 'UPDATE')
            this.openUpdateDialog(exerciseType, tagGroups);
        },
        err => console.log(err)
      );
  }

  openAddDialog(tagGroups: TagGroup[]) {
    const dialogRef = this.uiService.openDialogFromComponent(ExerciseTypeCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '50rem',
      autoFocus: false,
      data: { title: 'EXERCISE_TYPES.ADD_TYPE_LABEL', action: CRUD.Create, tagGroups, entity: new ExerciseType() },
      panelClass: ['exercise-type-dialog-container', 'dialog-container']
    })

    this.onDialogClose(dialogRef);
  }

  openUpdateDialog(exerciseType: ExerciseType, tagGroups: TagGroup[]) {
    const dialogRef = this.uiService.openDialogFromComponent(ExerciseTypeCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '30rem',
      // maxHeight: '50vh',
      autoFocus: false,
      data: { title: this.translateService.instant('EXERCISE_TYPES.UPDATE_TYPE_LABEL', { name: exerciseType.name }), action: CRUD.Update, entity: exerciseType, tagGroups },
      panelClass: ['exercise-type-dialog-container', 'dialog-container']
    })

    this.onDialogClose(dialogRef);
  }

  onDialogClose(dialogRef: MatDialogRef<any, any>) {
    dialogRef.afterClosed().pipe(take(1))
      .subscribe((type: ExerciseType) => {
        if (type) {
          this.table.onSelect(type, true, true);
          this.onSelect(type);
        }
      })
  }

  onDisableEvent(exerciseType: ExerciseType) {
    let type = Object.assign({}, exerciseType);
    type.active = false;

    const request = new UpdateExerciseTypeRequest({ exerciseType: type });

    this.exerciseTypeService.update<UpdateExerciseTypeRequest, ExerciseType>(request).pipe(take(1))
      .subscribe(
        (exerciseType: ExerciseType) => {

          const exerciseTypeUpdate: Update<ExerciseType> = {
            id: exerciseType.id,
            changes: { active: exerciseType.active }
          };

          this.store.dispatch(exerciseTypeUpdated({ entity: exerciseTypeUpdate }));
        },
        err => console.log(err)
      );
  }
  // onDeleteSingle(exerciseType: ExerciseType) {

  //   // this.deleteDialogConfig.message =
  //   //   `<p>Are you sure you wish to delete type ${tagGroup.type} ?</p>
  //   //  <p>All data will be lost if you delete this type.</p>`;

  //   // var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

  //   // dialogRef.afterClosed().pipe(take(1))
  //   //   .subscribe((result: ConfirmResult) => {
  //   //     if(result == ConfirmResult.Confirm) {
  //   //       this.userService.delete(athlete.id, AccountType.Athlete)
  //   //         .subscribe(
  //   //           () => {
  //   //             this.store.dispatch(deleteAthlete(athlete))
  //   //           },
  //   //           err => console.log(err)
  //   //         )
  //   //     }
  //   //   })
  // }

  // onDeleteSelection(exerciseType: ExerciseType[]) {

  //   //   this.deleteDialogConfig.message =
  //   //     `<p>Are you sure you wish to delete all (${athletes.length}) selected users ?</p>
  //   //    <p>All data will be lost if you delete these users.</p>`;

  //   //   this.deleteDialogConfig.action = (athletes: ApplicationUser[]) => {
  //   //     console.log('delete');
  //   //     console.log(athletes);
  //   //   }

  //   //   this.deleteDialogConfig.actionParams = [athletes];

  //   //   this.uiService.openConfirmDialog(this.deleteDialogConfig)
  //   // }
  // }

  onPagingChange(model: PagingModel) {
    this._fetchExerciseTypes(model).subscribe(_ => _, err => console.log(err));
  }

  _fetchExerciseTypes = (model: PagingModel) =>
    this.exerciseTypeService.getPaged(this._userId, model)
      .pipe(
        take(1),
        map(((pagedListModel: PagedList<ExerciseType>) => {
          this.store.dispatch(exerciseTypesFetched({ entities: pagedListModel.list, totalItems: pagedListModel.totalItems, pagingModel: model }));
        }))
      );
}
