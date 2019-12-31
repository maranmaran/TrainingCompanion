import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { Subject, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SetPasswordRequest } from 'src/server-models/cqrs/authorization/requests/set-password.request';
import { SignInRequest } from 'src/server-models/cqrs/authorization/requests/sign-in.request';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { BaseService } from '../base.service';

@Injectable({ providedIn: 'root'})
export class AuthService extends BaseService {

  public signOutEvent = new Subject();

  constructor(
    private httpDI: HttpClient,
    private router: Router,
    private cookieService: CookieService,
  ) {
    super(httpDI, 'Authorization');
  }

  public signIn(request: SignInRequest) {
    return this.http.post<CurrentUser>(this.url + 'SignIn', request)
      .pipe(
        catchError(this.handleError)
      );
  }

  public setPassword(request: SetPasswordRequest) {
    return this.http.post<CurrentUser>(this.url + 'SetPassword', request)
      .pipe(
        catchError(this.handleError)
      );
  }

  public resetPassword(email: string) {
    return this.http.get(this.url + 'ResetPassword/' + email)
      .pipe(
        catchError(this.handleError)
      );
  }

  public getCurrentUserInfo() {
    const userId = localStorage.getItem('id');

    if(!userId) {
      return throwError('Could not fetch user info');
    }

    return this.http.get<CurrentUser>(this.url + 'CurrentUserInformation' + `/${userId}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  public isAuthenticated() {
    const token = this.getToken();
    if (!token) { return false; } // get new token

    const date = this.getTokenExpirationDate(token);
    if (date === undefined) { return false; } // can't confirm -> get new token
    return (date.valueOf() > new Date().valueOf()); // expired or not
  }

  private getToken(): string {
    return this.cookieService.get('jwt');
  }

  private getTokenExpirationDate(token: string): Date {
    try {
      const decoded = jwt_decode(token);
      if (decoded.exp === undefined) { return null; }

      const date = new Date();
      date.setUTCSeconds(decoded.exp);

      return date;
    } catch (err) {
      return null;
    }
  }


}
