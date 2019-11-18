import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { AppState } from 'src/ngrx/app/app.state';
import { setSelectedTraining, trainingDeleted } from 'src/ngrx/training-log/training2/training.actions';
import { UIService } from './../../../../../../business/services/shared/ui.service';
import { Training } from './../../../../../../server-models/entities/training.model';

@Component({
  selector: 'app-training-calendar-day',
  templateUrl: './training-calendar-day.component.html',
  styleUrls: ['./training-calendar-day.component.scss']
})
export class TrainingCalendarDayComponent implements OnInit {

  @Input() training: Training;
  private deleteDialogConfig = new ConfirmDialogConfig({ title: 'Delete training', confirmLabel: 'Delete' });

  constructor(
    private store: Store<AppState>,
    private trainingService: TrainingService,
    private uiService: UIService
  ) { }

  ngOnInit() {
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

  onDeleteClick() {

    this.trainingService.delete(this.training.id).pipe(take(1))
      .subscribe(
        () => this.store.dispatch(trainingDeleted({ id: this.training.id })),
        err => console.log(err)
      );
  }
}
