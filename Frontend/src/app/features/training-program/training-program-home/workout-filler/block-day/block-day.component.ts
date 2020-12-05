import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { AfterViewInit, ChangeDetectorRef, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSlideToggle, MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { noop } from 'rxjs/internal/util/noop';
import { take } from 'rxjs/operators';
import { BlockTrainingCreateEditComponent } from 'src/app/features/training-program/training-program-home/workout-filler/block-day/block-training/block-training-create-edit/block-training-create-edit.component';
import { MoveCopyDialogComponent } from 'src/app/features/training-program/training-program-home/workout-filler/block-day/move-copy-dialog/move-copy-dialog.component';
import { TrainingBlockDayService } from 'src/business/services/feature-services/training-block-day.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ConfirmDialogConfig, ConfirmResult } from 'src/business/shared/confirm-dialog.config';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { addTraining, removeTraining } from 'src/ngrx/training-program/training-block-day/training-block-day.actions';
import { CopyTrainingRequest } from 'src/server-models/cqrs/training/copy-training.request';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/create-training.request';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/update-training.request';
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

  userId: string;

  @ViewChild('slideToggle', { static: true }) toggle: MatSlideToggle

  private _subs = new SubSink();
  slideToggleControl = new FormControl(true);

  constructor(
    private translateService: TranslateService,
    private trainingService: TrainingService,
    private changeTracking: ChangeDetectorRef,
    private dayService: TrainingBlockDayService,
    private UIService: UIService,
    private dialog: MatDialog,
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userId = id);
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

  public get dayIdx(): number { return (this.day.order - 1) % 7 }
  public get dayLabel(): string { return `${this.dayIdx + 1}.`; }

  // add training
  onAdd() {

    let startTime = new Date();
    startTime.setHours(12, 0, 0, 0);

    const dialogRef = this.dialog.open(BlockTrainingCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '18rem',
      autoFocus: false,
      data: {
        title: this.translateService.instant('TRAINING_BLOCK.ADD_TRAINING_TITLE', { week: this.weekIdx + 1, day: this.dayIdx + 1 }),
        action: CRUD.Create,
        training: new Training({ dateTrained: startTime, note: '', trainingBlockDayId: this.day.id, applicationUserId: this.userId })
      },
      panelClass: ["dialog-container"]
    });

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((training: Training) => {
        if (!training) return;

        if (!this.day.trainings) this.day.trainings = [];

        this.day.trainings.push(training);
      });
  }

  // copy training
  onEdit(training: Training) {

    const dialogRef = this.dialog.open(BlockTrainingCreateEditComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '65rem',
      autoFocus: false,
      data: {
        title: this.translateService.instant('TRAINING_BLOCK.EDIT_TRAINING_TITLE', { week: this.weekIdx + 1, day: this.dayLabel }),
        action: CRUD.Update,
        training
      },
      panelClass: ["dialog-container"]
    });

    dialogRef.afterClosed().pipe(take(1))
      .subscribe((training: Training) => {
        if (!training) return;

        this.day.trainings = this.day.trainings.map(t => t.id == training.id ? Object.assign(t, training) : t);
      });
  }

  // delete training
  onDelete(training: Training) {
    let idx = this.day.trainings.indexOf(training);
    this.day.trainings.splice(idx, 1);
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

  trackTrainingId = (training: Training) => training.id

  drop(event: CdkDragDrop<TrainingBlockDay, Training>) {

    const training = event.item.data as Training;
    const day = event.container.data as TrainingBlockDay;

    // can't move or copy on same day
    if (training.trainingBlockDayId == day.id)
      return;

    const dialogRef = this.dialog.open(MoveCopyDialogComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '14rem',
      autoFocus: false,
      data: {
        title: this.translateService.instant('TRAINING_BLOCK.COPY_TRAINING_TITLE'),
      },
      panelClass: ["dialog-container"]
    });

    dialogRef.afterClosed().pipe(take(1))
      .subscribe(
        (action?: 'COPY' | 'MOVE') => {
          if (!action) return;

          // do copy
          if (action == 'COPY')
            this.copy(training, day.id);

          // do move
          if (action == 'MOVE')
            this.move(training, day.id);
        }
      );
  }

  copy(training, dayId) {
    const request = new CopyTrainingRequest();
    request.toProgramDay = dayId as string;
    request.toDate = training.dateTrained as Date;
    request.trainingId = training.id;

    this.trainingService.copy(request)
      .pipe(take(1))
      .subscribe(
        (training: Training) => this.store.dispatch(addTraining({ dayId, training })),
        err => console.log(err)
      );
  }

  move(training, dayId) {
    const previousDayId = training.trainingBlockDayId;

    const request = new UpdateTrainingRequest({
      id: training.id,
      trainingBlockDayId: dayId,
      dateTrained: training.dateTrained,
      note: training.note,
      noteRead: training.noteRead
    });

    this.trainingService.update(request)
      .pipe(take(1))
      .subscribe(
        (trainingResponse: Training) => {
          this.store.dispatch(addTraining({ dayId, training }));
          this.store.dispatch(removeTraining({ dayId: previousDayId, trainingId: trainingResponse.id }));
        },
        err => console.log(err)
      );
  }
}
