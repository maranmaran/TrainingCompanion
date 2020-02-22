import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { forkJoin } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/custom-preview-components/active-flag/active-flag.component';
import { ExerciseTypeChipComponent } from 'src/app/shared/custom-preview-components/exercise-type-preview/exercise-type-chip/exercise-type-chip.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { TableConfig } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { TagGroupService } from 'src/business/services/feature-services/tag-group.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { reorderTagGroups, setSelectedTagGroup, tagGroupDeleted } from 'src/ngrx/tag-group/tag-group.actions';
import { allTagGroups, tagGroupCount } from 'src/ngrx/tag-group/tag-group.selectors';
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { SubSink } from 'subsink';
import { TypesCreateEditComponent } from './../types-create-edit/types-create-edit.component';

@Component({
  selector: 'app-types-list',
  templateUrl: './types-list.component.html',
  styleUrls: ['./types-list.component.scss']
})
export class TypesListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<TagGroup>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private tagGroupService: TagGroupService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.subs.add(
      this.store.select(allTagGroups)
        .subscribe((tagGroups: TagGroup[]) => {
          this.tableDatasource.updateDatasource(tagGroups);
        }));
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: TagGroup, filter: string) => data.type.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.enableDragAndDrop = true;
    tableConfig.pageSizeOptions = [5];
    this.store.select(tagGroupCount).pipe(take(1)).subscribe(count => tableConfig.pageSizeOptions = [...tableConfig.pageSizeOptions, count])

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
        displayFunction: (item: TagGroup) => `${item.order + 1}.`,
      }),
      new CustomColumn({
        definition: 'type',
        title: 'Type',
        sort: true,
        headerClass: 'type-header',
        cellClass: 'type-cell',
        displayFunction: (item: TagGroup) => item.type,
      }),
      new CustomColumn({
        definition: 'active',
        title: '',
        displayOnMobile: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        useComponent: true,
        component: ActiveFlagComponent,
        inputs: (item: TagGroup) => { return { active: item.active } },
      }),
      new CustomColumn({
        definition: 'hexColor',
        title: '',
        displayOnMobile: false,
        headerClass: 'hex-header',
        cellClass: 'hex-cell',
        useComponent: true,
        component: ExerciseTypeChipComponent,
        inputs: (item: TagGroup) => { return { value: "Tag", show: true, backgroundColor: item.hexBackground, color: item.hexColor } },
      }),
    ]
  }

  onSelect = (tagGroup: TagGroup) => this.store.dispatch(setSelectedTagGroup({ tagGroup }));

  onReorder(payload: { previous: TagGroup, current: TagGroup }) {
    let previousItem = payload.previous.id;
    let currentItem = payload.current.id;
    this.store.dispatch(reorderTagGroups({ previousItem, currentItem }));
  }

  onAdd(event) {
    forkJoin(
      this.store.select(tagGroupCount).pipe(take(1)),
      this.store.select(currentUserId).pipe(take(1))
    )
    .pipe(map(([count, userId]) => {
        const newTagGroup = new TagGroup();
        newTagGroup.order = count;
        newTagGroup.applicationUserId = userId;
        return newTagGroup;
    })).subscribe(group => {
      const dialogRef = this.uiService.openDialogFromComponent(TypesCreateEditComponent, {
        height: 'auto',
        width: '98%',
        maxWidth: '20rem',
        autoFocus: false,
        data: { title: 'Add exercise property type', action: CRUD.Create, tagGroup: group},
        panelClass: []
      })

      dialogRef.afterClosed().pipe(take(1)).subscribe((tagGroup: TagGroup) => this.postCreateUpdate(tagGroup));
    });
  }

  onUpdate(tagGroup: TagGroup) {

    const dialogRef = this.uiService.openDialogFromComponent(TypesCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'Update exercise property type', action: CRUD.Update, tagGroup: tagGroup },
      panelClass: []
    })

    dialogRef.afterClosed().pipe(take(1)).subscribe((tagGroup: TagGroup) => this.postCreateUpdate(tagGroup));
  }

  postCreateUpdate(tagGroup: TagGroup) {
    if (tagGroup) {
      this.table.onSelect(tagGroup, true);
      this.onSelect(tagGroup);
    }
  }

  onDeleteSingle(tagGroup: TagGroup) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete type ${tagGroup.type} ?</p>
     <p>All data will be lost if you delete this type.</p>`;

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.tagGroupService.delete(tagGroup.id)
            .subscribe(
              () => {
                this.store.dispatch(tagGroupDeleted({ id: tagGroup.id }))
              },
              err => console.log(err)
            )
        }
      })
  }

  onDeleteSelection(tagGroups: TagGroup[]) {

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete all (${tagGroups.length}) selected types ?</p>
     <p>All data will be lost if you delete these types.</p>`;

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig)

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.tagGroupService.deleteMany(tagGroups.map(x => x.id))
            .subscribe(
              () => {
                // TODO
                // this.store.dispatch(tagGroupsDeleted({id: tagGroup.id }))
              },
              err => console.log(err)
            )
        }
      })
  }


}
