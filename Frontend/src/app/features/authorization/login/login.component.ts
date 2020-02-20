import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { login } from 'src/ngrx/auth/auth.actions';
import { loginError } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { disableErrorDialogs, setActiveProgressBar, switchTheme } from 'src/ngrx/user-interface/ui.actions';
import { getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { SignInRequest } from 'src/server-models/cqrs/authorization/sign-in.request';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public loading$: Observable<boolean>;
  public hidePassword: boolean;
  public error: Observable<Error>;

  constructor(
    private store: Store<AppState>,
  ) { }

  ngOnInit() {
    // state setup for login component
    this.store.dispatch(switchTheme({ theme: Theme.Light }));
    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.LoginScreen }))
    this.store.dispatch(disableErrorDialogs());

    this.loading$ = getLoadingState(this.store, UIProgressBar.LoginScreen);;
    this.error = this.store.select(loginError);

    // form logic flags
    this.hidePassword = true;

    this.createForm();
  }

  private createForm() {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  public onSubmit() {
    if (this.loginForm.valid) {

      const username = this.loginForm.get('username').value;
      const password = this.loginForm.get('password').value;
      const signInRequest = new SignInRequest(username, password);

      this.store.dispatch(login(signInRequest));
    }
  }
}
