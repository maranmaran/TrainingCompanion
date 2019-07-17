import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators, Form, NgForm } from '@angular/forms';
import { take } from 'rxjs/operators';
import { AuthService } from 'src/business/services/auth.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ThemeService } from 'src/business/services/shared/theme.service';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { SignInRequest } from 'src/server-models/cqrs/authorization/requests/sign-in.request';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { login } from 'src/ngrx/auth/auth.actions';
import { Router } from '@angular/router';
import { disableErrorSnackbar } from 'src/ngrx/user-interface/ui.actions';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {


  public loginForm: FormGroup;
  public loading$ = this.UIService.loading$;
  public hidePassword = true;
  public error = false;

  constructor(
    private themeService: ThemeService,
    private UIService: UIService,
    private authService: AuthService,
    private store: Store<AppState>,
  ) { }

  ngOnInit() {
    this.store.dispatch(disableErrorSnackbar);
    // this.UIService.showErrorSnackbar = !this.UIService.showErrorSnackbar;
    
    this.themeService.resetToDefault();
    this.createForm();
  }

  ngOnDestroy(): void {
    this.UIService.showErrorSnackbar = !this.UIService.showErrorSnackbar;
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
