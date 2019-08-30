import { Component, OnInit, ViewChild } from '@angular/core';
import { SubSink } from 'subsink';
import { ConfirmDialogConfig } from 'src/business/shared/confirm-dialog.config';
import { TableConfig, CustomColumn, TableDatasource } from 'src/business/shared/table-data';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingService } from 'src/business/services/training.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { take } from 'rxjs/operators';
import { sets } from 'src/ngrx/training/training.selectors';
import { setSelectedSet } from 'src/ngrx/training/training.actions';
import { SetCreateEditComponent } from '../set-create-edit/set-create-edit.component';
import { CRUD } from 'src/business/shared/crud.enum';
import { Set } from 'src/server-models/entities/set.model';

@Component({
  selector: 'app-set-list',
  templateUrl: './set-list.component.html',
  styleUrls: ['./set-list.component.scss']
})
export class SetListComponent implements OnInit {
  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete action', confirmLabel: 'Delete' });

  protected tableConfig: TableConfig;
  protected tableColumns: CustomColumn[];
  protected tableDatasource: TableDatasource<Set>;
  @ViewChild(MaterialTableComponent, { static: true }) table: MaterialTableComponent;

  private userId: string;

  constructor(
    private uiService: UIService,
    private trainingService: TrainingService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();
    this.tableColumns = this.getTableColumns() as CustomColumn[];

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);

    this.subs.add(
      this.store.select(sets)
        .subscribe((sets: Set[]) => {
          this.tableDatasource.updateDatasource(sets);
        }));

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig();
    // tableConfig.filterFunction = (data: Set, filter: string) => data.weight.name.toLocaleLowerCase().indexOf(filter) !== -1
    tableConfig.enableDragAndDrop = true;
    tableConfig.pageSizeOptions = [5];

    return tableConfig;
  }

  getTableColumns() {
    return [
      // new CustomColumn({
      //   definition: 'set',
      //   title: 'Set',
      //   sort: true,
      //   inputs: (item: Set) => { return {setType: item.setType}; },
      // }),
      // new CustomColumn({
      //   definition: 'active',
      //   title: '',
      //   displayOnMobile: false,
      //   headerClass: 'active-header',
      //   cellClass: 'active-cell',
      //   useComponent: true,
      //   component: ActiveFlagComponent,
      //   inputs: (item: Set) => { return {active: item.active } },
      // }),
      // new CustomColumn({
      //   definition: 'hexColor',
      //   title: '',
      //   displayOnMobile: false,
      //   headerClass: 'hex-header',
      //   cellClass: 'hex-cell',
      //   useComponent: true,
      //   component: SetTypeChipComponent,
      //   inputs: (item: Set) => {return {value: "Tag", show: true, backgroundColor: item.hexBackground, color: item.hexColor}},
      // }),
    ]
  }

  onSelect = (set: Set) => this.store.dispatch(setSelectedSet({ set }));

  onAdd() {
    // const dialogRef = this.uiService.openDialogFromComponent(SetCreateEditComponent, {
    //   height: 'auto',
    //   width: '98%',
    //   maxWidth: '50rem',
    //   autoFocus: false,
    //   data: { title: 'Add set', action: CRUD.Create, setTypes },
    //   panelClass: []
    // })

    // dialogRef.afterClosed().pipe(take(1))
    //   .subscribe((set: Set) => {
    //       if (set) {
    //         this.table.onSelect(set, true);
    //         this.onSelect(set);
    //       }
    //     }
    //   )
  }

  onUpdate(set: Set) {
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

  onDeleteSingle(set: Set) {

    // this.deleteDialogConfig.message =
    //   `<p>Are you sure you wish to delete type ${set.type} ?</p>
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

  onDeleteSelection(sets: Set[]) {

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
