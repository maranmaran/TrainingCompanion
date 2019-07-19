import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SignInRequest } from 'src/server-models/cqrs/authorization/requests/sign-in.request';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { CurrentUserStore } from '../stores/current-user.store';
import { BaseService } from './base.service';

@Injectable({ providedIn: 'root'})
export class AuthService extends BaseService {

  private url = `/Authorization/`;
  public signOutEvent = new Subject();

  constructor(
    private http: HttpClient,
    private router: Router,
    private cookieService: CookieService,
    private currentUserStore: CurrentUserStore,
  ) {
    super();
  }

  public signIn(command: SignInRequest) {
    return this.http.post<CurrentUser>(this.url + 'SignIn', command)
      .pipe(
        catchError(this.handleError)
      );
  }

  public getCurrentUserInfo() {
    const userId = localStorage.getItem('id');
    if(!userId) this.router.navigate(['/auth/login']);
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
