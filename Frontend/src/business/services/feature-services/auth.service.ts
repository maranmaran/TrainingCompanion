import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { SocialUser } from 'angularx-social-login';
import * as jwt_decode from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { Subject, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { SetPasswordRequest } from 'src/server-models/cqrs/authorization/set-password.request';
import { SignInRequest } from 'src/server-models/cqrs/authorization/sign-in.request';
import { BaseService } from '../base.service';


@Injectable({ providedIn: 'root' })
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

  public externalLogin(provider: string) {
    return this.http.get(this.url + 'ExternalLogin')
      .pipe(
        catchError(this.handleError)
      );
  }

  public externalLoginCallback(data: SocialUser) {
    var request = {
      authToken: data.authToken,
      tokenId: data.idToken,
      userId: data.id
    }
    return this.http.post<CurrentUser>(this.url + 'ExternalLoginCallback/', request)
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
    const userId = this.getUserIdFromJWT();

    if (!userId) {
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
    return this.cookieService.get('Bearer');
  }

  private getUserIdFromJWT(): string {
    const token = this.getToken();
    const decoded = jwt_decode(token);

    return decoded.unique_name;
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
