import { AfterViewInit, ChangeDetectorRef, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatSlideToggle, MatSlideToggleChange } from '@angular/material/slide-toggle';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';
import { TrainingCreateEditComponent } from 'src/app/features/training-log/training/training-create-edit/training-create-edit.component';
import { TrainingBlockDayService } from 'src/business/services/feature-services/training-block-day.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { TrainingBlockDay } from 'src/server-models/entities/training-program.model';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';
import { TrainingService } from './../../../../../../business/services/feature-services/training.service';

@Component({
  selector: 'app-block-day',
  templateUrl: './block-day.component.html',
  styleUrls: ['./block-day.component.scss']
})
export class BlockDayComponent implements OnInit, AfterViewInit, OnDestroy {

  @Input() day: TrainingBlockDay;
  @Input() weekIdx: number;

  @ViewChild('slideToggle', { static: true }) toggle: MatSlideToggle

  private _subs = new SubSink();
  slideToggleControl = new FormControl(true);

  constructor(
    private translateService: TranslateService,
    private trainingService: TrainingService,
    private changeTracking: ChangeDetectorRef,
    private dayService: TrainingBlockDayService,
    private UIService: UIService
  ) { }

  ngOnInit(): void {

  }

  ngAfterViewInit(): void {
    if (!this.day.modified || !this.day.restDay) {
      this.toggle.checked = true; // default is training day
      this.changeTracking.detectChanges();
    }
  }

  ngOnDestroy() {
    this._subs.unsubscribe();
  }

  public get dayLabel(): string { return `${(this.day.order - 1) % 7 + 1}.`; }

  // add training
  onAdd() {
    this.trainingService.onAdd(TrainingCreateEditComponent, this.day.id)
      .afterClosed()
      .pipe(take(1))
      .subscribe((training: Training) => {

        if (training) {
          if (!this.day.trainings) this.day.trainings = [];

          this.day.trainings.push(training);
        }
      });
  }

  // delete training
  onDelete(training: Training) {
    let idx = this.day.trainings.indexOf(training);
    this.day.trainings.splice(idx, 1);
  }

  // copy training
  onCopy(training: Training) {
    throw new Error("Not implemented");
  }

  // change state of training block day (Rest/Training day) - Slide toggle button
  onChange(event: MatSlideToggleChange) {

    let newState = !event.checked;

    // if slide is checked.. this is training day
    if (newState) {
      this.toggle.toggle();
      return this.day.restDay = false;
    }

    if (this.day.trainings?.length > 0) {
      this.promptDialogForRestDay();
    } else {
      this.markAsRestDay();
    }

  }

  promptDialogForRestDay() {
    // after dialog closed and confirmed...
    // this is rest day.. if slide is checked off
    let deleteDialogConfig = new ConfirmDialogConfig({
      title: 'TRAINING_PROGRAM.MARK_REST_DAY_TITLE',
      confirmLabel: 'TRAINING_PROGRAM.MARK_REST_DAY_BTN'
    });

    deleteDialogConfig.message = this.translateService.instant('TRAINING_PROGRAM.MARK_REST_DAY_BODY', { day: this.day.order % 7, week: this.weekIdx + 1 });

    var dialogRef = this.UIService.openConfirmDialog(deleteDialogConfig);

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((result: ConfirmResult) => {
        if (result == ConfirmResult.Confirm) {
          this.markAsRestDay();
        }
      });
  }

  markAsRestDay() {
    this.toggle.toggle();

    let request = {
      id: this.day.id,
      restDay: true
    };

    this.dayService.update(request).pipe(take(1))
      .subscribe(
        _ => {
          this.day.restDay = true;
          this.day.trainings = [];
        },
        err => console.log(err)
      )
  }

}
