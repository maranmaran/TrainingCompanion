import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { forkJoin, noop } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/custom-preview-components/active-flag/active-flag.component';
import { ExerciseTypeChipComponent } from 'src/app/shared/custom-preview-components/exercise-type-preview/exercise-type-chip/exercise-type-chip.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { TableAction, TableConfig, TablePagingOptions } from "src/app/shared/material-table/table-models/table-config.model";
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
import { TypeDetailsComponent } from './../type-details/type-details.component';
import { TypesCreateEditComponent } from './../types-create-edit/types-create-edit.component';

@Component({
  selector: 'app-types-list',
  templateUrl: './types-list.component.html',
  styleUrls: ['./types-list.component.scss']
})
export class TypesListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'TAGS.DELETE_TYPE_TITLE', confirmLabel: 'SHARED.DELETE' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<TagGroup>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  constructor(
    private uiService: UIService,
    private tagGroupService: TagGroupService,
    private store: Store<AppState>,
    private translateService: TranslateService
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
    const tableConfig = new TableConfig({
      filterFunction: (data: TagGroup, filter: string) => data.type.toLocaleLowerCase().indexOf(filter) !== -1,
      enableDragAndDrop: true,
      pagingOptions: new TablePagingOptions({
        pageSizeOptions: [5]
      }),
      cellActions: [TableAction.update, TableAction.delete],
      filterEnabled: true,
      enableExpandableRows: true,
      expandableRowComponent: TypeDetailsComponent,
      expandableRowComponentAttributes: { class: 'type-details-expanded-row' }

    });

    this.store.select(tagGroupCount).pipe(take(1)).subscribe(count => count > 5 ? tableConfig.pagingOptions.pageSizeOptions = [...tableConfig.pagingOptions.pageSizeOptions, count] : noop)

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
        displayFn: (item: TagGroup) => `${item.order + 1}.`,
      }),
      new CustomColumn({
        definition: 'type',
        title: 'TAGS.TYPE',
        sort: true,
        headerClass: 'type-header',
        cellClass: 'type-cell',
        displayFn: (item: TagGroup) => item.type,
      }),
      new CustomColumn({
        definition: 'active',
        title: '',
        displayOnMobile: false,
        headerClass: 'active-header',
        cellClass: 'active-cell',
        useComponent: true,
        component: ActiveFlagComponent,
        componentInputs: (item: TagGroup) => { return { active: item.active } },
      }),
      new CustomColumn({
        definition: 'hexColor',
        title: '',
        displayOnMobile: false,
        headerClass: 'hex-header',
        cellClass: 'hex-cell',
        useComponent: true,
        component: ExerciseTypeChipComponent,
        componentInputs: (item: TagGroup) => { return { value: "TAGS.TAG", show: true, backgroundColor: item.hexBackground, color: item.hexColor } },
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
          data: { title: 'TAGS.ADD_TYPE', action: CRUD.Create, tagGroup: group },
          panelClass: ["dialog-container"]
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
      data: { title: 'TAGS.UPDATE_TYPE', action: CRUD.Update, tagGroup: tagGroup },
      panelClass: ["dialog-container"]
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

    this.deleteDialogConfig.message = this.translateService.instant('TAGS.DELETE_TYPE', { type: tagGroup.type });

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

    this.deleteDialogConfig.message = this.translateService.instant('TAGS.DELETE_TYPE_SELECTION', { length: tagGroups.length });

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
