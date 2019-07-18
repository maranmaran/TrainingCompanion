import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';
import { AuthService } from 'src/business/services/auth.service';
import { ThemeService } from 'src/business/services/shared/theme.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { login } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { disableErrorSnackbar, enableErrorSnackbar, setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { SignInRequest } from 'src/server-models/cqrs/authorization/requests/sign-in.request';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { Observable } from 'rxjs';
import { requestLoading } from 'src/ngrx/user-interface/ui.selectors';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {


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
    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.LoginScreen}))
    this.store.dispatch(disableErrorSnackbar());
    this.loading$ = this.store.select(requestLoading);

    // form logic flags
    this.hidePassword = true;
    this.error = false;
    
    this.createForm();
  }

  ngOnDestroy(): void {
    this.store.dispatch(enableErrorSnackbar());
  }

  private createForm() {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      rememberMe: new FormControl(true)
    });
  }

  public onSubmit() {
    if (this.loginForm.valid) {

      const username = this.loginForm.get('username').value;
      const password = this.loginForm.get('password').value;
      const rememberMe = this.loginForm.get('rememberMe').value;
      const signInRequest = new SignInRequest(username, password, rememberMe);

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
