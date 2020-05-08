import { AppSettingsService } from './../../../../../../business/services/shared/app-settings.service';
import { NotificationService } from './../../../../../../business/services/feature-services/notification.service';
import { TranslateService } from '@ngx-translate/core';
import { Component, Inject, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingProgramUserCreated } from 'src/ngrx/training-program/training-program/training-program.actions';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { TrainingProgramCreateEditComponent } from '../training-program-create-edit/training-program-create-edit.component';
import { TrainingProgramUserService } from './../../../../../../business/services/feature-services/training-program-user.service';
import { UserService } from './../../../../../../business/services/feature-services/user.service';
import { CreateTrainingProgramUserRequest } from './../../../../../../server-models/cqrs/training-program/create-training-program-user.request';
import { TrainingProgramUser } from './../../../../../../server-models/entities/training-program.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-training-program-assign',
  templateUrl: './training-program-assign.component.html',
  styleUrls: ['./training-program-assign.component.scss'],
  providers: [
    NotificationService,
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] },
  ]
})
export class TrainingProgramAssignComponent implements OnInit {

  constructor(
    private toastrService: ToastrService,
    private appSettings: AppSettingsService,
    public mediaObserver: MediaObserver,
    private translate: TranslateService,
    private trainingProgramUserService: TrainingProgramUserService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<TrainingProgramCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      trainingProgram: TrainingProgram,
      users: ApplicationUser[]
    }) { }


  form: FormGroup;
  request = new CreateTrainingProgramUserRequest({ programId: this.data.trainingProgram.id });

  ngOnInit() {
    this.createForm();
  }

  get user(): AbstractControl { return this.form.get('user'); }
  get startDate(): AbstractControl { return this.form.get('startDate'); }

  createForm() {
    this.form = new FormGroup({
      user: new FormControl(null, [Validators.required]),
      startDate: new FormControl(new Date(), [Validators.required]),
    });
  }

  onSubmit() {
    if (!this.form.valid) return;

    // do assign
    this.request.userId = this.user.value.id;
    this.request.startDate = this.startDate.value;

    let user = this.data.users.find(x => x.id == this.user.value.id);

    // call api
    this.trainingProgramUserService.create(this.request).pipe(take(1))
      .subscribe((programUser: TrainingProgramUser) => {
        this.store.dispatch(trainingProgramUserCreated({ entity: programUser }));
        this.toastSuccess(user, this.data.trainingProgram);
        this.onClose();
      }, err => (console.log(err), this.toastFail(this.data.trainingProgram)))
  }

  toastSuccess(user, program) {
    this.toastrService.success(
      this.translate.instant(
        'TRAINING_PROGRAM.ASSIGNED_SUCCESS',
        { program: program.name, athlete: user.fullName }
      ),
      this.translate.instant('TRAINING_PROGRAM.ASSIGNED_SUCCESS_TITLE'),
      this.appSettings.defaultNotificationConfig
    );
  }

  toastFail(program) {
    this.toastrService.error(
      this.translate.instant(
        'TRAINING_PROGRAM.ASSIGNED_FAIL',
        { program: program.name }
      ),
      this.translate.instant('TRAINING_PROGRAM.ASSIGNED_FAIL_TITLE'),
      this.appSettings.defaultNotificationConfig
    );
  }

  onClose() {
    this.dialogRef.close();
  }

  displayFn(user: ApplicationUser) {
    return user?.fullName;
  }
}
