import { Component, OnInit } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Store } from '@ngrx/store';
import * as _ from "lodash";
import { take } from 'rxjs/operators';
import { Theme } from 'src/business/shared/theme.enum';
import { updateUserSetting } from 'src/ngrx/auth/auth.actions';
import { userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { NotificationSetting } from 'src/server-models/entities/notification-setting.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { UserService } from '../../../../business/services/feature-services/user.service';
import { UserSetting } from './../../../../server-models/entities/user-settings.model';
import { UnitSystem } from './../../../../server-models/enums/unit-system.enum';
import { NotificationTypeLabel } from './notification-type-labels.enum';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.scss']
})
export class GeneralComponent implements OnInit {

  public userSetting: UserSetting;
  protected unitSystems = UnitSystem;
  protected rpeSystems = RpeSystem;

  notificationTypeLabels = NotificationTypeLabel;

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
  get unitSystemButtonChecked(): boolean { return this.userSetting.unitSystem == UnitSystem.Metric; }
  get rpeSystemButtonChecked(): boolean { return this.userSetting.rpeSystem == RpeSystem.Rpe; }

  public onThemeChange(event: MatSlideToggleChange) {
    if (event.checked) this.userSetting.theme = Theme.Dark;
    if (!event.checked) this.userSetting.theme = Theme.Light;

    this.store.dispatch(updateUserSetting(this.userSetting));
  }

  public onUnitSystemChange(event: MatSlideToggleChange) {
    if (event.checked) this.userSetting.unitSystem = UnitSystem.Metric;
    if (!event.checked) this.userSetting.unitSystem = UnitSystem.Imperial;

    this.store.dispatch(updateUserSetting(this.userSetting));
  }

  public onRpeSystemChange(event: MatSlideToggleChange) {
    if (event.checked) this.userSetting.rpeSystem = RpeSystem.Rpe;
    if (!event.checked) this.userSetting.rpeSystem = RpeSystem.Rir;

    this.store.dispatch(updateUserSetting(this.userSetting));
  }

  public onUseRpeSystemChecked(event: MatCheckboxChange) {
    this.userSetting.useRpeSystem = event.checked;
    this.store.dispatch(updateUserSetting(this.userSetting));
  }

public onNotificationSettingCheckboxChecked(event: MatCheckboxChange, setting: NotificationSetting) {

    let settingCopy = _.cloneDeep(setting);
    switch (event.source.name) {
      case 'receiveMail':
        settingCopy.receiveMail = event.checked;
        break;
      case 'receiveNotification':
        settingCopy.receiveNotification = event.checked;
        break;
      default:
        throw new Error("No source like that defined");
    }

    this.userSetting.notificationSettings = this.userSetting.notificationSettings.map(x => x.id == settingCopy.id ? settingCopy : x);
    this.store.dispatch(updateUserSetting(this.userSetting));
  }


}
