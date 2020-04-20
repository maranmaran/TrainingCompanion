import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingCreated } from 'src/ngrx/training-log/training.actions';
import { selectedTrainingBlockDayId } from 'src/ngrx/training-program/training-block-day/training-block-day.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { TrainingService } from './../../../../../business/services/feature-services/training.service';
import { CreateTrainingRequest } from './../../../../../server-models/cqrs/training/create-training.request';

@Component({
  selector: 'app-training-create-edit',
  templateUrl: './training-create-edit.component.html',
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
  ]
})
export class TrainingCreateEditComponent implements OnInit {

  constructor(
    private trainingService: TrainingService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<TrainingCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD,
      day: moment.Moment,
      timeOnly: boolean,
      partOfTrainingProgram: boolean
    }) { }

  form: FormGroup;
  private _userId: string;
  private _blockDay: string;

  private dateTimeObj = {
    date: this.data.day.toDate(),
    time: '12:00 PM'
  }

  ngOnInit() {
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);

    this.store.select(selectedTrainingBlockDayId).pipe(take(1)).subscribe(blockDay => this._blockDay = blockDay as string);
    this.createForm();
  }

  get date(): AbstractControl { return this.form.get('date'); }
  get time(): AbstractControl { return this.form.get('time'); }

  createForm() {
    this.form = new FormGroup({
      date: new FormControl(this.dateTimeObj.date, Validators.required),
      time: new FormControl(this.dateTimeObj.time, Validators.required),
    });
  }

  onSubmit() {
    if (!this.form.valid)
      return;

    const request = new CreateTrainingRequest();

    if(this.data.partOfTrainingProgram) {
      request.trainingBlockDayId = this._blockDay;
    } else {
      request.applicationUserId = this._userId;
    }

    request.dateTrained = moment(moment(this.date.value).format('L')  + ' ' + this.time.value, 'L HH:mm').toDate();

    this.createEntity(request);
  }

  onClose(training?: Training) {
    this.dialogRef.close(training);
  }

  createEntity(request: CreateTrainingRequest) {

    this.trainingService.create(request).pipe(take(1))
      .subscribe(
        (training: Training) => {
          this.store.dispatch(trainingCreated({ entity: training }))
          this.onClose(training)
        },
        err => console.log(err)
      );
  }

}
