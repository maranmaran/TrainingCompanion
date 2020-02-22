import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/custom-preview-components/active-flag/active-flag.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from "src/app/shared/material-table/table-models/custom-column.model";
import { TableConfig } from "src/app/shared/material-table/table-models/table-config.model";
import { TableDatasource } from "src/app/shared/material-table/table-models/table-datasource.model";
import { TagService } from 'src/business/services/feature-services/tag.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { reorderTags, setSelectedTag } from 'src/ngrx/tag-group/tag-group.actions';
import { selectedTagGroup } from 'src/ngrx/tag-group/tag-group.selectors';
import { tagCount } from 'src/ngrx/tag/tag.selectors';
import { Tag } from 'src/server-models/entities/tag.model';
import { SubSink } from 'subsink';
import { TagGroup } from '../../../../../../server-models/entities/tag-group.model';
import { TagsCreateEditComponent } from '../properties-create-edit/properties-create-edit.component';

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
    private propertyService: TagService,
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource(null);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.subs.add(

      this.store.select(selectedTagGroup)
        .pipe(
          // filter(tagGroup => !!tagGroup),
        )
        .subscribe((tagGroup: TagGroup) => {
          this.groupSelected = !!tagGroup;
          if(this.groupSelected) {
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
    const tableConfig = new TableConfig();
    tableConfig.filterFunction = (data: Tag, filter: string) => data.value.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.enableDragAndDrop = true;
    tableConfig.pageSizeOptions = [5];
    this.store.select(tagCount).pipe(take(1)).subscribe(count => tableConfig.pageSizeOptions = [...tableConfig.pageSizeOptions, count])

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
        displayFunction: (item: Tag) => `${item.order + 1}.`,
      }),
      new CustomColumn({
        definition: 'value',
        title: 'Value',
        sort: true,
        displayFunction: (item: Tag) => item.value,
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
      data: { title: `Add ${this.tagGroupName} property`, action: CRUD.Create, tag: Object.assign(new Tag(), { order: this.tagsCount}) },
      panelClass: []
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
      data: { title: `Update ${this.tagGroupName} property`, action: CRUD.Update, tag: tag },
      panelClass: []
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
