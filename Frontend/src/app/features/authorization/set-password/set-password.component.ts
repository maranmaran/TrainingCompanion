import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { PasswordValidation } from 'src/business/utils/password.validator';
import { loginSuccess } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { SetPasswordRequest } from 'src/server-models/cqrs/authorization/set-password.request';
import { AuthService } from '../../../../business/services/feature-services/auth.service';


@Component({
  selector: 'app-set-password',
  templateUrl: './set-password.component.html',
  styleUrls: ['./set-password.component.scss']
})
export class SetPasswordComponent implements OnInit {

  setPasswordForm: FormGroup;
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
