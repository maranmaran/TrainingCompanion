import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import * as moment from 'moment';
import { filter, switchMap, take, tap } from 'rxjs/operators';
import { MaterialTableComponent } from 'src/app/shared/material-table/material-table.component';
import { CustomColumn } from 'src/app/shared/material-table/table-models/custom-column.model';
import { TableAction, TableConfig, TablePagingOptions } from 'src/app/shared/material-table/table-models/table-config.model';
import { TableDatasource } from 'src/app/shared/material-table/table-models/table-datasource.model';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { unitSystem } from 'src/ngrx/auth/auth.selectors';
import { selectedExerciseType } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { PersonalBest } from 'src/server-models/entities/personal-best.model';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { SubSink } from 'subsink';
import { PersonalBestService } from '../../../../../business/services/feature-services/personal-best.service';
import { UIService } from '../../../../../business/services/shared/ui.service';
import { PersonalBestCreateEditComponent } from './../personal-best-create-edit/personal-best-create-edit.component';

@Component({
  selector: 'app-personal-best-list',
  templateUrl: './personal-best-list.component.html',
  styleUrls: ['./personal-best-list.component.scss'],
})
export class PersonalBestListComponent implements OnInit {

  bootstrap = false;

  tableConfig: TableConfig;
  tableColumns: CustomColumn[];
  tableDatasource: TableDatasource<PersonalBest>;
  @ViewChild(MaterialTableComponent, { static: false }) table: MaterialTableComponent;

  exerciseType: ExerciseType;

  unitSystem: UnitSystem;
  private _subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private prService: PersonalBestService,
    private translateService: TranslateService,
    private UIService: UIService
  ) { }

  ngOnInit(): void {

    this.tableDatasource = new TableDatasource([]);
    this.tableConfig = this.getTableConfig();

    this._subs.add(
      this.store.select(unitSystem).subscribe(system => this.unitSystem = system),
      this.fetchPRs()
    )
  }

  fetchPRs() {
    return this.store.select(selectedExerciseType).pipe(
      tap(type => {
        this.bootstrap = false;
        this.tableDatasource.updateDatasource([]);
      }),
      filter(type => !!type),
      tap(type => this.exerciseType = type),
      switchMap(type => this.prService.getAll(type.id)),
    ).subscribe((prs: PersonalBest[]) => {
      this.tableColumns = this.getTableColumns() as CustomColumn[];
      this.tableDatasource.updateDatasource([...prs]);

      setTimeout(_ => this.bootstrap = true)
    });
  }

  ngOnDestroy() {
    this._subs.unsubscribe();
  }

  getTableConfig() {
    const tableConfig = new TableConfig({
      pagingOptions: new TablePagingOptions({
        pageSizeOptions: [5]
      }),
      cellActions: [TableAction.delete],
      headerActions: [TableAction.create],
      enableDragAndDrop: false,
      selectionEnabled: false,
      filterEnabled: false,
      defaultSort: 'dateAchieved',
      defaultSortDirection: 'desc'
    });

    return tableConfig;
  }

  getTableColumns() {
    let columns = [
      new CustomColumn({
        headerClass: 'personal-best-header',
        cellClass: 'personal-best-cell',
        definition: 'dateAchieved',
        title: 'PERSONAL_BEST.DATE_ACHIEVED',
        sort: true,
        displayFn: (item: PersonalBest) => moment(item.dateAchieved).format('L'),
      }),
      new CustomColumn({
        headerClass: 'personal-best-header',
        cellClass: 'personal-best-cell',
        definition: 'value',
        title: 'PERSONAL_BEST.VALUE',
        sort: true,
        //TODO transform depending on exercise type to kg, lbs, watts, km, yards etc
        displayFn: (item: PersonalBest) => transformWeight(item.value, this.unitSystem),
      }),
      new CustomColumn({
        headerClass: 'personal-best-header',
        cellClass: 'personal-best-cell',
        definition: 'bodyweight',
        title: 'PERSONAL_BEST.BODYWEIGHT',
        sort: true,
        //TODO transform depending on exercise type to kg, lbs, watts, km, yards etc
        displayFn: (item: PersonalBest) => item.bodyweight ?
              transformWeight(item.bodyweight, this.unitSystem)
              : this.translateService.instant('SHARED.UNKNOWN'),
      }),
    ];

    // get columns based on exercise type
    // don't show this for 1 rep max because we know what it's for.. only 1 rep
    // if(this.exerciseType.requiresReps) {
    //   columns.push( new CustomColumn({
    //     headerClass: 'personal-best-header',
    //     cellClass: 'personal-best-cell',
    //     definition: 'reps',
    //     title: 'PERSONAL_BEST.REPS',
    //     sort: true,
    //     displayFn: (item: PersonalBest) => item.reps,
    //   }))
    // }

    // TODO... value should be time actually depending on exercise type
    // if(this.exerciseType.requiresTime) {
    //   columns.push( new CustomColumn({
    //     headerClass: 'personal-best-header',
    //     cellClass: 'personal-best-cell',
    //     definition: 'reps',
    //     title: 'PERSONAL_BEST.REPS',
    //     sort: true,
    //     displayFn: (item: PersonalBest) => item.time, //todo transform
    //   }))
    // }

    // watt distance etc
    // if(this.exerciseType.requiresReps) {
    //   columns.push( new CustomColumn({
    //     headerClass: 'personal-best-header',
    //     cellClass: 'personal-best-cell',
    //     definition: 'reps',
    //     title: 'PERSONAL_BEST.REPS', //TODO: Change
    //     sort: true,
    //     displayFn: (item: PersonalBest) => item.reps,
    //   }))

    return columns;
  }

  onAdd() {
    let personalBest = new PersonalBest();
    personalBest.exerciseTypeId = this.exerciseType.id;

    const dialogRef = this.UIService.openDialogFromComponent(PersonalBestCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'PERSONAL_BEST.ADD_TITLE', action: CRUD.Create, personalBest, unitSystem: this.unitSystem },
      panelClass: []
    });

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((pb: PersonalBest) => {
        if (pb) {
          this.table.onSelect(pb, true);
          this.tableDatasource.addElement(pb);
        }
      });
  }

  onDeleteSingle(pr: PersonalBest) {

    const deleteDialogConfig = new ConfirmDialogConfig({
      title: 'PERSONAL_BEST.DELETE_TITLE',
      confirmLabel: 'SHARED.DELETE'
    });

    deleteDialogConfig.message = this.translateService.instant(
      'PERSONAL_BEST.DELETE_BODY',
      { date: moment(pr.dateAchieved).format('D, MMM') }
    );

    const dialogRef = this.UIService.openConfirmDialog(deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {

        if (result !== ConfirmResult.Confirm) {
          return;
        }

        this.prService.delete(pr.id)
          .subscribe(
            () => {
              this.table.onSelect(null);
              this.tableDatasource.removeElement(pr);
            },
            err => console.log(err)
          );
      });
  }

}
