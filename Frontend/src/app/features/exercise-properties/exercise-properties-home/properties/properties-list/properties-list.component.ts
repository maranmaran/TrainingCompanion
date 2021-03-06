import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/custom-preview-components/active-flag/active-flag.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { TableAction, TableConfig, TablePagingOptions } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { reorderTags, setSelectedTag } from 'src/ngrx/tag-group/tag-group.actions';
import { selectedTagGroup } from 'src/ngrx/tag-group/tag-group.selectors';
import { Tag } from 'src/server-models/entities/tag.model';
import { SubSink } from 'subsink';
import { TagGroup } from '../../../../../../server-models/entities/tag-group.model';
import { TagsCreateEditComponent } from '../properties-create-edit/properties-create-edit.component';
import { PropertyDetailsComponent } from './../property-details/property-details.component';

@Component({
  selector: 'app-properties-list',
  templateUrl: './properties-list.component.html',
  styleUrls: ['./properties-list.component.scss']
})
export class PropertiesListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<Tag>;
  @ViewChild(MaterialTableComponent, { static: false }) table: MaterialTableComponent;

  private tagGroupName: string;
  groupSelected: boolean = false;
  tagsCount: number = 0;

  constructor(
    private translateService: TranslateService,
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource(null);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.subs.add(
      this.store.select(selectedTagGroup)
        .subscribe((tagGroup: TagGroup) => {
          this.groupSelected = !!tagGroup;
          if (this.groupSelected) {
            this.tagGroupName = tagGroup?.type;
            this.tagsCount = tagGroup?.tags.length;
            this.tableDatasource.updateDatasource([...tagGroup?.tags]);
          }
        })
    );

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig({
      filterFunction: (data: Tag, filter: string) => data.value.toLocaleLowerCase().indexOf(filter) !== -1,
      enableDragAndDrop: true,
      pagingOptions: new TablePagingOptions({
        pageSizeOptions: [5]
      }),
      cellActions: [TableAction.update, TableAction.delete],
      selectionEnabled: false,
      filterEnabled: true,
      enableExpandableRows: false,
      expandableRowComponent: PropertyDetailsComponent,
      expandableRowComponentAttributes: { class: 'property-details-expanded-row' }
    });

    this.store.select(selectedTagGroup)
      .subscribe((tagGroup: TagGroup) => {
        if (tagGroup && tagGroup?.tags.length > 5) {
          tableConfig.pagingOptions.pageSizeOptions = [...tableConfig.pagingOptions.pageSizeOptions, tagGroup?.tags.length] // page option
        }
      })


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
        displayFn: (item: Tag) => `${item.order + 1}.`,
      }),
      new CustomColumn({
        definition: 'value',
        title: 'SHARED.VALUE',
        sort: true,
        displayFn: (item: Tag) => item.value,
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
    ]
  }

  onReorder(payload: { previous: Tag, current: Tag }) {
    let previousItem = payload.previous.id;
    let currentItem = payload.current.id;
    this.store.dispatch(reorderTags({ previousItem, currentItem }));
  }

  onSelect = (property: Tag) => this.store.dispatch(setSelectedTag({ property }));

  onAdd() {
    const dialogRef = this.uiService.openDialogFromComponent(TagsCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: this.translateService.instant('TAGS.ADD_PROPERTY', { groupName: this.tagGroupName }), action: CRUD.Create, tag: Object.assign(new Tag(), { order: this.tagsCount }) },
      panelClass: ["dialog-container"]
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((property: Tag) => {
        if (property) {
          this.table.onSelect(property, true);
          this.onSelect(property);
        }
      }
      )
  }

  onUpdate(tag: Tag) {
    const dialogRef = this.uiService.openDialogFromComponent(TagsCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: this.translateService.instant('TAGS.UPDATE_PROPERTY', { groupName: this.tagGroupName }), action: CRUD.Update, tag: tag },
      panelClass: ["dialog-container"]
    })

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((property: Tag) => {
        if (property) {
          this.table.onSelect(property, true);
          this.onSelect(property);
        }
      }
      )
  }

  onDeleteSingle(tagGroup: Tag) {

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

  onDeleteSelection(tagGroups: Tag[]) {

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
