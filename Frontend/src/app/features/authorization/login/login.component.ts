import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs/operators';
import { AuthService } from 'src/business/services/auth.service';
import { NotificationService } from 'src/business/services/shared/notification.service';
import { ThemeService } from 'src/business/services/shared/theme.service';
import { SignInCommand } from 'src/server-models/cqrs/authorization/commands/sign-in.command';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public loading$ = this.notificationService.loading$;

  constructor(
    private themeService: ThemeService,
    private notificationService: NotificationService,
    private authService: AuthService,
  ) { }

  
  ngOnInit() {
    this.themeService.resetToDefault();
    this.createForm();
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
      const signInCommand = new SignInCommand(username, password, rememberMe);

      this.authService.signIn(signInCommand)
        .pipe(take(1))
        .subscribe(
          (res: CurrentUser) => {
            this.authService.setSession(res);
          },
          (err: HttpErrorResponse) => console.log(err)
        );
    }
  }

}
