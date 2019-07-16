import { Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import * as moment from 'moment';
import { CookieService } from 'ngx-cookie-service';
import { SignInRequest } from 'src/server-models/cqrs/authorization/requests/sign-in.request';
import { CurrentUserStore } from '../stores/current-user.store';
import { BaseService } from './base.service';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';

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
    return this.http.get<CurrentUser>(this.url + 'CurrentUserInformation' + `/${userId}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  // public setSession(user: CurrentUser) {
  //   this.currentUserStore.setState(user);
  //   localStorage.setItem('id', user.id.toString());
  //   this.router.navigate(['']);
  // }

  // public signOut() {
  //   this.signOutEvent.next();
  //   this.currentUserStore.setState(undefined);
  //   localStorage.removeItem('id');
  //   this.cookieService.delete('jwt');
  //   this.router.navigate(['/auth/login']);
  // }

  public isAuthenticated() {
    const token = this.getToken();
    if (!token) { return false; } // get new token

    const date = this.getTokenExpirationDate(token);
    if (date === undefined) { return false; } // can't confirm -> get new token
    return (date.valueOf() > new Date().valueOf()); // expired or not
  }

  public getToken(): string {
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

  public setSplashDialogDate() {
    localStorage.setItem('splashDialogDate', moment(new Date()).utc().format('L'));
  }

  public get showSplashDialog(): boolean {
    const date = localStorage.getItem('splashDialogDate');
    return !date || date != moment(new Date()).utc().format('L');
  }

}
