import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, take } from 'rxjs/operators';
import { ActiveFlagComponent } from 'src/app/shared/active-flag/active-flag.component';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { TagService } from 'src/business/services/feature-services/tag.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { CustomColumn, TableConfig, TableDatasource } from 'src/business/shared/table-data';
import { setSelectedTag } from 'src/ngrx/tag-group/tag-group.actions';
import { selectedTagGroup } from 'src/ngrx/tag-group/tag-group.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
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

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<Tag>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  private tagGroupName: string;

  constructor(
    private propertyService: TagService,
    private uiService: UIService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.subs.add(

      this.store.select(selectedTagGroup)
        .pipe(
          filter(tagGroup => !!tagGroup),
        )
        .subscribe((tagGroup: TagGroup) => {
          this.tagGroupName = tagGroup.type;
          this.tableDatasource.updateDatasource(tagGroup.properties);
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

  onSelect = (property: Tag) => this.store.dispatch(setSelectedTag({ property }));

  onAdd() {
    const dialogRef = this.uiService.openDialogFromComponent(TagsCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: `Add ${this.tagGroupName} property`, action: CRUD.Create },
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
