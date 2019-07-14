import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs/operators';
import { NotificationService } from 'src/business/services/shared/notification.service';
import { UsersService } from 'src/business/services/user.service';
import { CurrentUserStore } from 'src/business/stores/current-user.store';
import { validateForm } from 'src/business/utils/form.utils';
import { UpdateUserRequest } from 'src/server-models/cqrs/users/requests/update-user.request';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit, OnDestroy {

  public accountForm: FormGroup;
  private currentUser: CurrentUser;

  // readonly inputs at first
  public editUsername = true;
  public editMail = true;

  @Output() loading = new EventEmitter<boolean>(true);

  constructor(
    private notificationService: NotificationService,
    private currentUserStore: CurrentUserStore,
    private usersService: UsersService
  ) { }

  ngOnInit() {
    this.currentUser = this.currentUserStore.state;
    this.createForm(this.currentUser)
  }

  ngOnDestroy(): void {
    // reset loading bars back
    this.loading.emit(false);
    this.notificationService.showAppLoadingBar = true;
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
    if (validateForm(this.accountForm, this.notificationService)) {

      const command = new UpdateUserRequest(
        this.currentUser.id,
        this.username.value,
        this.email.value,
        this.currentUser.firstName,
        this.currentUser.lastName,
        this.currentUser.accountStatus
      );

      this.notificationService.showAppLoadingBar = false;
      this.loading.emit(true);
      
      this.usersService.update(command)
        .pipe(take(1))
        .subscribe(
          () => {
            this.currentUser.username = this.username.value;
            this.currentUser.email = this.email.value;

            this.currentUserStore.setState(this.currentUser);
          },
          err => console.log(err),
          () => {
            this.loading.emit(false);
            this.notificationService.showAppLoadingBar = true;
            
            this.editUsername = true;
            this.editMail = true;
          }
        );
    }
  }
}
