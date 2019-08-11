import { AuthService } from './../../../../business/services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { PasswordValidation } from 'src/business/utils/password.validator';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SetPasswordRequest } from 'src/server-models/cqrs/authorization/requests/set-password.request';
import { take } from 'rxjs/operators';
import { login, loginSuccess } from 'src/ngrx/auth/auth.actions';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  protected resetPasswordForm: FormGroup;
  private userId: string;

  constructor(
    private store: Store<AppState>,
    private authService: AuthService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.userId = this.route.snapshot.params.id
    this.createForm();
  }

  private createForm() {
    this.resetPasswordForm = new FormGroup({
      password: new FormControl('', Validators.required),
      repeatPassword: new FormControl('', Validators.required),
    }, {
      validators: PasswordValidation.MatchPassword
    });
  }

  public onSubmit() {
    if (this.resetPasswordForm.valid) {

      const password = this.resetPasswordForm.get('password').value;
      const repeatPassword = this.resetPasswordForm.get('repeatPassword').value;

      const request = new SetPasswordRequest(this.userId, password, repeatPassword);
      this.authService.setPassword(request).pipe(take(1))
        .subscribe(
          (currentUser: CurrentUser) => this.store.dispatch(loginSuccess(currentUser)),
          err => console.log(err)
        )
    }
  }
}