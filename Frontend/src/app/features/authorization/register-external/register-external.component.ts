import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
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

  constructor(
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<RegisterExternalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { user: SocialUser }) { }

  ngOnInit(): void {
  }

  register(type) {
    const user = new ApplicationUser({
      email: this.data.user.email,
      firstName: this.data.user.firstName,
      lastName: this.data.user.lastName,
      avatar: this.data.user.photoUrl,
      accountType: type
    });

    this.store.dispatch(externalLogin({ user }));
    this.onClose();
  }

  onClose() {
    this.dialogRef.close();
  }
}
