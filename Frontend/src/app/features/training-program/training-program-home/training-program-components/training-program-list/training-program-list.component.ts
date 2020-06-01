import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { delay, filter, take, map } from 'rxjs/operators';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { getPlaceholderImagePath } from 'src/business/utils/utils';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTrainingProgram, trainingProgramDeleted } from 'src/ngrx/training-program/training-program/training-program.actions';
import { trainingPrograms, selectedTrainingProgram } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { TrainingProgramCreateEditComponent } from '../training-program-create-edit/training-program-create-edit.component';
import { Observable } from 'rxjs/internal/Observable';
import { ReturnStatement } from '@angular/compiler';

@Component({
  selector: 'app-training-program-list',
  templateUrl: './training-program-list.component.html',
  styleUrls: ['./training-program-list.component.scss']
})
export class TrainingProgramListComponent implements OnInit {

  private subs = new SubSink();
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'TRAINING_PROGRAM.DELETE_TITLE', confirmLabel: 'SHARED.DELETE' });

  placeholderImagePath: string;

  programs: Observable<TrainingProgram[]>;
  selectedProgram: TrainingProgram;

  constructor(
    private uiService: UIService,
    private trainingProgramService: TrainingProgramService,
    private store: Store<AppState>,
    private translateService: TranslateService
  ) { }

  ngOnInit() {

    this.programs = this.store.select(trainingPrograms)

    // table config
    this.subs.add(
      this.store.select(activeTheme).subscribe(theme => this.placeholderImagePath = getPlaceholderImagePath(theme)),
      this.store.select(selectedTrainingProgram).subscribe(program => this.selectedProgram = program)
    )

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  programId = (program: TrainingProgram) => program.id;


  onSelect(program: TrainingProgram) {
    this.store.dispatch(setSelectedTrainingProgram({ entity: program }))
  }

  onClose(programId: string, selectedProgramId: string) {
    if (programId != selectedProgramId) return;

    this.store.dispatch(setSelectedTrainingProgram({ entity: null }))
  }

  onAdd() {

    const dialogRef = this.uiService.openDialogFromComponent(TrainingProgramCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '60rem',
      autoFocus: true,
      data: { title: 'TRAINING_PROGRAM.ADD_TITLE', action: CRUD.Create, trainingProgram: new TrainingProgram() },
      panelClass: []
    })

    dialogRef.afterClosed()
      .pipe(take(1))
      .subscribe((trainingProgram: TrainingProgram) => {
        console.log('here');
      })
  }

  onUpdate(trainingProgram: TrainingProgram) {

    const dialogRef = this.uiService.openDialogFromComponent(TrainingProgramCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '60rem',
      autoFocus: true,
      data: { title: 'TRAINING_PROGRAM.UPDATE_TITLE', action: CRUD.Update, trainingProgram: Object.assign({}, trainingProgram) },
      panelClass: []
    })

    dialogRef.afterClosed()
      .pipe(take(1))
      .subscribe((trainingProgram: TrainingProgram) => {
        console.log('here');
      })
  }

  onDeleteSingle(trainingProgram: TrainingProgram) {

    this.deleteDialogConfig.message = this.translateService.instant('TRAINING_PROGRAM.DELETE_DIALOG', { trainingProgram: trainingProgram.name })

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.deleteTrainingProgram(trainingProgram);
        }
      })
  }

  deleteTrainingProgram(trainingProgram) {
    this.trainingProgramService.delete(trainingProgram.id)
      .subscribe(
        _ => {
          this.store.dispatch(trainingProgramDeleted({ id: trainingProgram.id }))
        },
        err => console.log(err)
      )
  }

}
