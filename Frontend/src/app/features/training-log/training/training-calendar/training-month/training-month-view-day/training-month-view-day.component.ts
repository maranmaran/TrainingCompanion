import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { sortBy } from 'src/business/utils/utils';
import { AppState } from 'src/ngrx/app/app.state';
import { setSelectedTraining, trainingDeleted } from 'src/ngrx/training-log/training/training.actions';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { UIService } from '../../../../../../../business/services/shared/ui.service';
import { Exercise } from '../../../../../../../server-models/entities/exercise.model';
import { Training } from '../../../../../../../server-models/entities/training.model';

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

    this.deleteDialogConfig.message =
      `<p>Are you sure you wish to delete training on ${moment(this.training.dateTrained).format('L')} ?</p>
     <p>All data will be lost if you delete this training.</p>`;

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

  onCopy() {
    console.log("COPY");
  }

  onDeleteClick() {

    this.trainingService.delete(this.training.id).pipe(take(1))
      .subscribe(
        () => this.store.dispatch(trainingDeleted({ id: this.training.id })),
        err => console.log(err)
      );
  }
}
