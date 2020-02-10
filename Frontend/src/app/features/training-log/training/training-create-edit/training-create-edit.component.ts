import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingCreated } from 'src/ngrx/training-log/training/training.actions';
import { Training } from 'src/server-models/entities/training.model';
import { TrainingService } from './../../../../../business/services/feature-services/training.service';
import { CreateTrainingRequest } from './../../../../../server-models/cqrs/training/requests/create-training.request';
import { UpdateTrainingRequest } from './../../../../../server-models/cqrs/training/requests/update-training.request';

@Component({
  selector: 'app-training-create-edit',
  templateUrl: './training-create-edit.component.html',
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
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
      day: moment.Moment
    }) { }

  form: FormGroup;
  request: CreateTrainingRequest | UpdateTrainingRequest;

  private _userId: string;

  ngOnInit() {
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);

    // setup request
    if (this.data.action == CRUD.Create) {
      this.request = new CreateTrainingRequest();
      this.request.dateTrained = this.data.day.utc().format();
      this.request.applicationUserId = this._userId;
    }

    this.createForm();
  }

  get dateTrained(): AbstractControl { return this.form.get('dateTrained'); }
  createForm() {
    this.form = new FormGroup({
      dateTrained: new FormControl(this.request.dateTrained, Validators.required),
    });
  }

  onSubmit() {
    if (this.form.valid)
      this.createEntity();
  }

  onClose(training?: Training) {
    this.dialogRef.close(training);
  }

  createEntity() {
    this.trainingService.create(this.request).pipe(take(1))
      .subscribe(
        (training: Training) => {
          this.store.dispatch(trainingCreated({ entity: training }))
          this.onClose(training)
        },
        err => console.log(err)
      );
  }

}
