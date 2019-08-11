import { disableErrorDialogs } from './../../../../ngrx/user-interface/ui.actions';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { loginSuccess } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { AuthService } from './../../../../business/services/auth.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  protected resetPasswordForm: FormGroup;
  protected emailSent: boolean = false;
  protected emailFailed: boolean = false;

  constructor(
    private store: Store<AppState>,
    private authService: AuthService,
  ) { }

  ngOnInit() {
    this.store.dispatch(disableErrorDialogs());
    this.createForm();
  }

  private createForm() {
    this.resetPasswordForm = new FormGroup({
      email: new FormControl('', Validators.required),
    });
  }

  public onSubmit() {
    if (this.resetPasswordForm.valid) {

      const email = this.resetPasswordForm.get('email').value;

      this.authService.resetPassword(email).pipe(take(1))
        .subscribe(
          () => this.emailSent = true,
          err => this.emailFailed = true
        )
    }
  }
}