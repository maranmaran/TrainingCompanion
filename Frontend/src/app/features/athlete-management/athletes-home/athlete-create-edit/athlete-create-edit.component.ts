import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators, ValidationErrors } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { AthletesService } from 'src/business/services/athletes.service';
import { registerAthlete, updateAthlete } from 'src/ngrx/athletes/athlete.actions';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UpdateAthleteRequest } from 'src/server-models/cqrs/athletes/requests/update-athlete.request';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { Gender } from 'src/server-models/enums/gender.enum';
import { ServerStatusCodes } from 'src/server-models/error/status-codes/server.codes';
import { CreateAthleteRequest } from '../../../../../server-models/cqrs/athletes/requests/create-athlete.request';
import { CRUD } from './../../../../../business/shared/crud.enum';
import { AccountType } from './../../../../../server-models/enums/account-type.enum';
import { ErrorService } from 'src/business/services/shared/error.service';

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
    
  form: FormGroup;
  coachId: string;
  athlete = new ApplicationUser();

  ngOnInit() {
    if(this.data.action == CRUD.Update) this.athlete = Object.assign({}, this.data.athlete);
        
    this.createForm();
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this.coachId = user.id);
  }

  createForm() {
    this.form = new FormGroup({
      fullName: new FormControl(this.athlete.fullName, Validators.required),
      email: new FormControl(this.athlete.email, [Validators.required, Validators.email]),
      username: new FormControl(this.athlete.username, Validators.required),
    });

    if(this.data.action == CRUD.Update) {
      this.form.addControl('active', new FormControl(this.athlete.active, Validators.required))
    } 
  }
  
  get fullName(): AbstractControl { return this.form.get('fullName'); }
  get email(): AbstractControl { return this.form.get('email'); }
  get username(): AbstractControl { return this.form.get('username'); }

  onGenderChange(event: MatSlideToggleChange) {
    if (event.checked) this.athlete.gender = Gender.Male;
    if (!event.checked) this.athlete.gender = Gender.Female;
  }

  onActiveChange(event: MatSlideToggleChange) {
    if (event.checked) this.athlete.active = true;
    if (!event.checked) this.athlete.active = false;
  }
  
  onSubmit() {
    if ( this.data.action == CRUD.Create ) {
      this.createAthlete();
    } else {
      this.updateAthlete();
    }
  }
  
  onClose(athlete?: ApplicationUser) {
    this.dialogRef.close(athlete);
  }

  handleError(validationErrors: ValidationErrors) {
    if (validationErrors.status && validationErrors.status == ServerStatusCodes.ValidationError) {


      if(validationErrors.errors.username) {
        this.username.setErrors(validationErrors.errors.username)
      }

      if(validationErrors.errors.email) {
        this.email.setErrors(validationErrors.errors.email)
      }

    }
  }

  createAthlete() {
    var request = new CreateAthleteRequest();
    request.coachId = this.coachId;
    request.fullName = this.fullName.value;
    request.firstname = this.fullName.value.split(' ')[0];
    request.lastname = this.fullName.value.split(' ')[1];
    request.email = this.email.value;
    request.username = this.username.value;
    request.gender = this.athlete.gender;
    request.accountType = AccountType.Athlete;

    this.athletesService.create(request)
      .subscribe(
        (athlete: ApplicationUser) => {
          this.store.dispatch(registerAthlete(athlete));
          this.onClose(athlete);
        },
        (err: HttpErrorResponse) => this.handleError(err.error)
      );
  }

  updateAthlete() {
    var request = new UpdateAthleteRequest();
    request.id = this.athlete.id;
    request.fullName = this.fullName.value;
    request.firstname = this.fullName.value.split(' ')[0];
    request.lastname = this.fullName.value.split(' ')[1];
    request.email = this.email.value;
    request.username = this.username.value;
    request.gender = this.athlete.gender;
    request.active = this.athlete.active;

    this.athletesService.update(request)
      .subscribe(
        (athlete: ApplicationUser) => {
          this.store.dispatch(updateAthlete(athlete));
          this.onClose(athlete);
        },
        (err: HttpErrorResponse) => this.handleError(err.error)
      );
  }
}
