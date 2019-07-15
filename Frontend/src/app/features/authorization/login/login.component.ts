import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators, Form, NgForm } from '@angular/forms';
import { take } from 'rxjs/operators';
import { AuthService } from 'src/business/services/auth.service';
import { UIService } from 'src/business/services/shared/notification.service';
import { ThemeService } from 'src/business/services/shared/theme.service';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { SignInRequest } from 'src/server-models/cqrs/authorization/requests/sign-in.request';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {


  public loginForm: FormGroup;
  public loading$ = this.notificationService.loading$;
  public hidePassword = true;
  public error = false;

  constructor(
    private themeService: ThemeService,
    private notificationService: UIService,
    private authService: AuthService,
  ) { }

  
  ngOnInit() {
    this.notificationService.showErrorSnackbar = !this.notificationService.showErrorSnackbar;
    this.themeService.resetToDefault();
    this.createForm();
  }

  ngOnDestroy(): void {
    this.notificationService.showErrorSnackbar = !this.notificationService.showErrorSnackbar;
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
          (res: CurrentUser) => {
            this.authService.setSession(res);
          },
          (err: HttpErrorResponse) => { 
            this.error = true;
            console.log(err)
          }
        );
    }
  }

}
