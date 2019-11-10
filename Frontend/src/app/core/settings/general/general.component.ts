import { Component, OnInit } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { Theme } from 'src/business/shared/theme.enum';
import { updateuserSetting } from 'src/ngrx/auth/auth.actions';
import { userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UserService } from '../../../../business/services/feature-services/user.service';
import { UserSetting } from './../../../../server-models/entities/user-settings.model';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.scss']
})
export class GeneralComponent implements OnInit {

  public userSetting: UserSetting;

  constructor(
    private store: Store<AppState>,
    private usersService: UserService,
  ) { }

  ngOnInit() {
    this.store.select(userSetting).pipe(take(1))
      .subscribe((userSetting: UserSetting) => {
        this.userSetting = { ...userSetting };
      });
  }

  get themeButtonChecked(): boolean { return this.userSetting.theme == Theme.Dark; }

  public onThemeChange(event: MatSlideToggleChange) {
    if (event.checked) this.userSetting.theme = Theme.Dark;
    if (!event.checked) this.userSetting.theme = Theme.Light;

    this.store.dispatch(updateuserSetting(this.userSetting));
    this.onSaveSettings(this.userSetting);
  }

  private onSaveSettings(userSetting: UserSetting) {

    this.usersService.saveSettings(userSetting)
      .pipe(take(1))
      .subscribe(
        () => { },
        err => console.log(err),
      );

  }
}
