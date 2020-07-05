import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { SocialUser } from 'angularx-social-login';
import { externalLogin } from './../../../../ngrx/auth/auth.actions';
import { AppState } from './../../../../ngrx/global-setup.ngrx';
import { ApplicationUser } from './../../../../server-models/entities/application-user.model';
import { AccountType } from './../../../../server-models/enums/account-type.enum';

@Component({
  selector: 'app-register-external',
  templateUrl: './register-external.component.html',
  styleUrls: ['./register-external.component.scss']
})
export class RegisterExternalComponent implements OnInit {

  accountType = AccountType;
  user: SocialUser;

  constructor(
    private router: Router,
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this.user = history.state;
    if (!this.user)
      this.router.navigate(['/auth/login']);
  }

  register(type) {
    const user = new ApplicationUser({
      email: this.user.email,
      firstName: this.user.firstName,
      lastName: this.user.lastName,
      avatar: this.user.photoUrl,
      accountType: type
    });

    this.store.dispatch(externalLogin({ user }));
  }

}
