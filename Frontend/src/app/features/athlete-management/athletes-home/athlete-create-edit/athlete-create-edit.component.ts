import { ErrorDetails } from '../../../../../server-models/error/error-details.model';
import { HttpErrorResponse } from '@angular/common/http';
import { CreateAthleteRequest } from './../../../../../server-models/cqrs/athletes/create-athlete.request';
import { AthletesService } from 'src/business/services/athletes.service';
import { UsersService } from 'src/business/services/user.service';
import { AccountType } from './../../../../../server-models/enums/account-type.enum';
import { Gender } from './../../../../../server-models/enums/gender.enum';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { CRUD } from './../../../../../business/shared/crud.enum';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { PasswordValidation } from 'src/business/utils/password.validator';
import { CreateUserRequest } from 'src/server-models/cqrs/users/requests/create-user.request';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { registerAthlete } from 'src/ngrx/athletes/athlete.actions';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { take } from 'rxjs/operators';
import { CreateUserStatusCodes } from 'src/server-models/error/status-codes/create-user.codes';

@Component({
  selector: 'app-athlete-create-edit',
  templateUrl: './athlete-create-edit.component.html',
  styleUrls: ['./athlete-create-edit.component.scss']
})
export class AthleteCreateEditComponent implements OnInit {

  constructor(
    private store: Store<AppState>,
    private athletesService: AthletesService,
    protected dialogRef: MatDialogRef<AthleteCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, action: CRUD, athlete: ApplicationUser }) { }

  athlete: ApplicationUser;
  coachId: string;
  form: FormGroup;

  ngOnInit() {
    this.createForm();
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this.coachId = user.id);
  }

  createForm() {
    this.form = new FormGroup({
      firstName: new FormControl(null, Validators.required),
      lastName: new FormControl(null, Validators.required),
      email: new FormControl(null, [Validators.required, Validators.email]),
      username: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
      repeatPassword: new FormControl(null, Validators.required),
      gender: new FormControl(Gender.Male),
    }, {
      validators: PasswordValidation.MatchPassword
    });
  }
  
  get firstName(): AbstractControl { return this.form.get('firstName'); }
  get lastName(): AbstractControl { return this.form.get('lastName'); }
  get email(): AbstractControl { return this.form.get('email'); }
  get username(): AbstractControl { return this.form.get('username'); }
  get password(): AbstractControl { return this.form.get('password'); }
  get repeatPassword(): AbstractControl { return this.form.get('repeatPassword'); }
  get gender(): AbstractControl { return this.form.get('gender'); }

  onClose() {
    this.dialogRef.close();
  }

  onSubmit() {
    var request = new CreateAthleteRequest();
    request.coachId = this.coachId;
    request.firstname = this.firstName.value;
    request.lastname = this.lastName.value;
    request.email = this.email.value;
    request.username = this.username.value;
    request.password = this.password.value;
    request.confirmPassword = this.repeatPassword.value;
    request.gender = this.gender.value;
    request.accountType = AccountType.Athlete;

    this.athletesService.create(request)
      .subscribe(
        (athlete: ApplicationUser) => {
          console.log(athlete);
          this.store.dispatch(registerAthlete(athlete));
          this.onClose();
        },
        (err: HttpErrorResponse) => this.handleError(err.error)
      );
  }

  handleError(error: ErrorDetails) {
    const status = error.Status;
    const message = error.Message;

    if(status == CreateUserStatusCodes.UsernameExists) {
      console.log('here');
      this.username.setErrors({notUnique: true})
    }
    if(status == CreateUserStatusCodes.EmailExists) {
      this.email.setErrors({notUnique: true})
    }
  }

}
