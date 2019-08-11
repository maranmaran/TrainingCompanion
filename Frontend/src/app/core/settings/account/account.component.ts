import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { finalize, take } from 'rxjs/operators';
import { UIService } from 'src/business/services/shared/ui.service';
import { UsersService } from 'src/business/services/user.service';
import { validateForm } from 'src/business/utils/form.utils';
import { updateCurrentUser } from 'src/ngrx/auth/auth.actions';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UpdateUserRequest } from 'src/server-models/cqrs/users/requests/update-user.request';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  public accountForm: FormGroup;
  private currentUser: CurrentUser;

  // readonly inputs at first
  public editUsername = true;
  public editMail = true;

  constructor(
    private UIService: UIService,
    private usersService: UsersService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.store.select(currentUser)
      .pipe(take(1))
      .subscribe((user: CurrentUser) => { 
        this.currentUser = {...user};
        this.createForm(this.currentUser);
      });
  }


  private createForm(model: CurrentUser) {
    this.accountForm = new FormGroup({
      username: new FormControl(model.username, [Validators.required]),
      email: new FormControl(model.email, [Validators.required]),
    });
  }

  get username(): AbstractControl { return this.accountForm.get('username'); }
  get email(): AbstractControl { return this.accountForm.get('email'); }

  get getErrorMessage(): string {
    return 'Not valid';
  }

  public changePassword() {
    if (!this.email.valid) return;

    // hit change password api
  }

  public onSubmit() {
    if (validateForm(this.accountForm, this.UIService)) {

      const command = new UpdateUserRequest(
        this.currentUser.id,
        this.username.value,
        this.email.value,
        this.currentUser.firstName,
        this.currentUser.lastName,
        this.currentUser.active
      );

      this.usersService.update(command)
        .pipe(
          take(1),
          finalize(() => { 
            this.editUsername = true;
            this.editMail = true;
          }))
        .subscribe(
          () => {
            this.currentUser.username = this.username.value;
            this.currentUser.email = this.email.value;
            
            // set new state but don't pass by reference
            console.log('Update user')
            this.store.dispatch(updateCurrentUser(Object.assign({}, this.currentUser))); 
          },
          err => console.log(err),
        );
    }
  }
}
