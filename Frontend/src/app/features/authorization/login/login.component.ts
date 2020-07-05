import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { FacebookLoginProvider, GoogleLoginProvider, SocialAuthService, SocialUser } from 'angularx-social-login';
import { from, Observable, of } from 'rxjs';
import { catchError, switchMap, take } from 'rxjs/operators';
import { UserService } from 'src/business/services/feature-services/user.service';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { externalLogin, login } from 'src/ngrx/auth/auth.actions';
import { loginError } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { disableErrorDialogs, setActiveProgressBar, switchTheme } from 'src/ngrx/user-interface/ui.actions';
import { getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { SignInRequest } from 'src/server-models/cqrs/authorization/sign-in.request';
import { UIService } from './../../../../business/services/shared/ui.service';
import { RegisterExternalComponent } from './../register-external/register-external.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  facebookProvider = FacebookLoginProvider.PROVIDER_ID
  googleProvider = GoogleLoginProvider.PROVIDER_ID

  public loginForm: FormGroup;
  public loading$: Observable<boolean>;
  public hidePassword: boolean;
  public error: Observable<Error>;

  constructor(
    private store: Store<AppState>,
    private socialAuthService: SocialAuthService,
    private userService: UserService,
    private router: Router,
    private UIService: UIService
  ) {
  }

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

  public externalLogin(provider: string) {

    from(this.socialAuthService.signIn(provider))
      .pipe(
        switchMap(data =>
          this.userService.getOne(null, data.email).pipe(catchError(_ => of(null))),
          (socialUser, applicationUser) => ({ socialUser, applicationUser })
        ),
        take(1)
      ).subscribe(userData => {
        if (!userData.applicationUser) {
          // this.router.navigate(['/auth/register-external'], { state: userData.socialUser })
          this.registerExternalUser(userData.socialUser);
        } else {
          this.store.dispatch(externalLogin({ user: userData.applicationUser }))
        }
      });
  }

  private registerExternalUser(user: SocialUser) {
    this.UIService.openDialogFromComponent(RegisterExternalComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { user },
      panelClass: ["position-relative"]
    })
  }
}
