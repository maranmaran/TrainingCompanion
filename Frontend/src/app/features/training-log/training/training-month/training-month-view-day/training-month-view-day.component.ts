import { MatDialog } from '@angular/material/dialog';
import { TrainingCreateEditComponent } from 'src/app/features/training-log/training/training-create-edit/training-create-edit.component';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { sortBy } from 'src/business/utils/utils';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTraining, trainingDeleted } from 'src/ngrx/training-log/training.actions';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import { CRUD } from 'src/business/shared/crud.enum';
import { noop } from '@angular/compiler/src/render3/view/util';

@Component({
  selector: 'app-training-month-view-day',
  templateUrl: './training-month-view-day.component.html',
  styleUrls: ['./training-month-view-day.component.scss']
})
export class TrainingMonthViewDayComponent implements OnInit {

  @Input() training: Training;
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete training', confirmLabel: 'Delete' });
  private isMobile: boolean;
  @ViewChild('trainingPreviewTrigger', { read: MatMenuTrigger }) trainingPreviewTrigger: MatMenuTrigger;
  @ViewChild('actionsTrigger', { read: MatMenuTrigger }) actionsTrigger: MatMenuTrigger;

  showPreview = false;

  constructor(
    private store: Store<AppState>,
    private trainingService: TrainingService,
    private uiService: UIService,
    private translateService: TranslateService,
    private dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.store.select(isMobile).pipe(take(1)).subscribe((isMobile: boolean) => this.isMobile = isMobile);
  }

  onTrainingClick() {
    this.store.dispatch(setSelectedTraining({ entity: Object.assign({}, this.training) }));
  }

  onCopyClick() {
    // open copy dialog...
  }

  onDelete() {

    this.deleteDialogConfig.message = this.translateService.instant('TRAINING_LOG.TRAINING_DELETE_DIALOG', { dateTrained: moment(this.training.dateTrained).format('L') });

    var dialogRef = this.uiService.openConfirmDialog(this.deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe(
        (result: ConfirmResult) => {
          if (result == ConfirmResult.Confirm) {
            this.onDeleteClick();
          }
        },
        err => console.log(err)
      )
  }

  filterBy(data: Exercise[], prop: string) {
    return sortBy(data, [prop]);
  }

  pressEvent = false;
  onPress() {

    this.pressEvent = true;
    setTimeout(() => { // this is because we need if block on CLICK event..
      this.pressEvent = false;
    }, 500);

    if (this.isMobile) {
      this.actionsTrigger.openMenu();
    }

  }

  onClick() {

    if (!this.pressEvent) {
      if (this.isMobile && this.actionsTrigger.menuOpen) {
        this.actionsTrigger.closeMenu();
      } else if (this.actionsTrigger.menuClosed) {
        this.onTrainingClick();
      }
    }
  }

  onCopy(training: Training) {
    const date = moment(training.dateTrained);

    const dialogRef = this.dialog.open(TrainingCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '18rem',
      autoFocus: false,
      data: {
        title: this.translateService.instant('TRAINING_LOG.COPY_TRAINING_TITLE', { date: date.format("DD, MMM") }),
        action: 'COPY',
        training: new Training({ id: training.id }),
        timeOnly: false,
        day: date
      },
      panelClass: ["dialog-container"]
    });
  }

  onDeleteClick() {

    this.trainingService.delete(this.training.id).pipe(take(1))
      .subscribe(
        () => this.store.dispatch(trainingDeleted({ id: this.training.id })),
        err => console.log(err)
      );
  }
}
