import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSliderChange } from '@angular/material/slider';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { TrainingCreateEditComponent } from 'src/app/features/training-log/training/training-create-edit/training-create-edit.component';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingBlockDays } from 'src/ngrx/training-program/training-block-day/training-block-day.selectors';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/create-training.request';
import { CopyTrainingRequest } from 'src/server-models/cqrs/training/copy-training.request';
import { TrainingBlockDay } from 'src/server-models/entities/training-program.model';
import { Training } from 'src/server-models/entities/training.model';
import * as _ from 'lodash-es';
import * as moment from 'moment';
import { applyUserTimezone } from 'src/business/pipes/apply-timezone.pipe';
import { addTraining } from 'src/ngrx/training-program/training-block-day/training-block-day.actions';

@Component({
  selector: 'app-block-training-create-edit',
  templateUrl: './block-training-create-edit.component.html',
})
export class BlockTrainingCreateEditComponent implements OnInit {

  form: FormGroup;
  weeks: TrainingBlockDay[][] = [];
  daysMin = 1;
  daysMax = 7;

  constructor(
    private trainingService: TrainingService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<TrainingCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD | 'COPY',
      training: Training,
      day: string,
      week: number
    }) { }

  ngOnInit() {
    this.getWeeksData();
  }

  getWeeksData() {
    this.store.select(trainingBlockDays)
      .pipe(take(1))
      .subscribe(days => {

        days = _.cloneDeep(days);

        if (days.length == 0) return this.weeks = [];

        let weeks = [];
        let current = 0;
        while (current < days.length) {
          let week = days.slice(current, current + 7);
          weeks.push(week);
          current += 7;
        }

        this.weeks = weeks;
        this.createForm(weeks);
      });
  }

  createForm(weeks) {
    let trainingTime = applyUserTimezone(this.data.training.dateTrained).format('HH:mm');

    this.form = new FormGroup({
      weekIdx: new FormControl(this.data.week),
      dayIdx: new FormControl(this.data.day),
      time: new FormControl(trainingTime)
    });
  }

  weekSelected(event: MatSliderChange) {
    let weekIdx = event.value - 1;
    this.form.controls.weekIdx.setValue(weekIdx);

    const week = this.weeks[weekIdx];

    this.daysMax = week.length
  }

  daySelected(event: MatSliderChange) {
    let dayIdx = event.value - 1;
    this.form.controls.dayIdx.setValue(dayIdx);
  }

  onSubmit() {
    if (!this.form.valid)
      return;

    const { weekIdx, dayIdx, time } = this.form.value;
  
    const week = this.weeks[weekIdx];

    const day = week[dayIdx];
    const trainingTime = moment(moment(new Date()).format('L') + ' ' + time, 'L HH:mm').toDate();

    switch (this.data.action) {
      case CRUD.Create:
        return this.create(day.id, trainingTime);

      case 'COPY':
        return this.copy(day.id, trainingTime);

      default:
        throw new Error('Invalid action')
    };
  }

  onClose(dayId?: string, training?: Training) {

    if(dayId && training) {
      this.store.dispatch(addTraining({dayId, training}));
    }

    this.dialogRef.close(training);
  }

  copy(blockDayId, trainingTime) {

    const request = new CopyTrainingRequest();
    request.toProgramDay = blockDayId as string;
    request.toDate = trainingTime as Date;
    request.trainingId = this.data.training.id;

    this.trainingService.copy(request)
      .pipe(take(1))
      .subscribe(
        (training: Training) => this.onClose(blockDayId as string, training),
        err => console.log(err)
      );
  }

  create(blockDayId, trainingTime) {

    const request = new CreateTrainingRequest();
    request.trainingBlockDayId = blockDayId;
    request.dateTrained = trainingTime;

    this.trainingService.create(request).pipe(take(1))
      .subscribe(
        (training: Training) => this.onClose(blockDayId as string, training),
        err => console.log(err)
      );
  }
}
