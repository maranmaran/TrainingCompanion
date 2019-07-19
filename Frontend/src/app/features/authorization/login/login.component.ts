import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { combineLatest, Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { AuthService } from 'src/business/services/auth.service';
import { login } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { disableErrorSnackbar, setActiveProgressBar, switchTheme } from 'src/ngrx/user-interface/ui.actions';
import { activeProgressBar, requestLoading, getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { SignInRequest } from 'src/server-models/cqrs/authorization/requests/sign-in.request';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public loading$: Observable<boolean>;
  public hidePassword: boolean;
  public error: boolean;

  constructor(
    private authService: AuthService,
    private store: Store<AppState>,
  ) { }

  ngOnInit() {
    // state setup for login component
    this.store.dispatch(switchTheme({theme: Theme.Light}));
    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.LoginScreen}))
    this.store.dispatch(disableErrorSnackbar());

    this.loading$ = getLoadingState(this.store, UIProgressBar.LoginScreen);;

    // form logic flags
    this.hidePassword = true;
    this.error = false;
    
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

      this.authService.signIn(signInRequest)
        .pipe(take(1))
        .subscribe(
          (currentUser: CurrentUser) => {
            this.store.dispatch(login(currentUser));
          },
          (err: HttpErrorResponse) => { 
            this.error = true;
            console.log(err)
          }
        );
    }
  }
}
