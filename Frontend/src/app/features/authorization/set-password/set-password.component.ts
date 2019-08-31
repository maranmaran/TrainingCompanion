import { AuthService } from '../../../../business/services/feature-services/auth.service';
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
  selector: 'app-set-password',
  templateUrl: './set-password.component.html',
  styleUrls: ['./set-password.component.scss']
})
export class SetPasswordComponent implements OnInit {

  protected setPasswordForm: FormGroup;
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
    this.setPasswordForm = new FormGroup({
      password: new FormControl('', Validators.required),
      repeatPassword: new FormControl('', Validators.required),
    }, {
      validators: PasswordValidation.MatchPassword
    });
  }

  public onSubmit() {
    if (this.setPasswordForm.valid) {

      const password = this.setPasswordForm.get('password').value;
      const repeatPassword = this.setPasswordForm.get('repeatPassword').value;

      const request = new SetPasswordRequest(this.userId, password, repeatPassword);
      this.authService.setPassword(request).pipe(take(1))
        .subscribe(
          (currentUser: CurrentUser) => this.store.dispatch(loginSuccess(currentUser)),
          err => console.log(err)
        )
    }
  }
}
