import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Store } from '@ngrx/store';
import * as _ from "lodash-es";
import { Observable } from 'rxjs';
import { map, skip, take } from 'rxjs/operators';
import { Country } from 'src/business/shared/models/country.model';
import { SupportedLanguages } from 'src/business/shared/supported-languages.enum';
import { Theme } from 'src/business/shared/theme.enum';
import { updateUserSetting } from 'src/ngrx/auth/auth.actions';
import { userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { NotificationSetting } from 'src/server-models/entities/notification-setting.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { SubSink } from 'subsink';
import { CountryService } from './../../../../business/services/feature-services/country.service';
import { setLanguage } from './../../../../ngrx/user-interface/ui.actions';
import { UserSetting } from './../../../../server-models/entities/user-settings.model';
import { UnitSystem } from './../../../../server-models/enums/unit-system.enum';
import { NotificationTypeLabel } from './notification-type-labels.enum';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.scss'],
  providers: [CountryService]
})
export class GeneralComponent implements OnInit {

  public userSetting: UserSetting;
  unitSystems = UnitSystem;
  rpeSystems = RpeSystem;

  notificationTypeLabels = NotificationTypeLabel;

  supportedLanguages = SupportedLanguages;
  supportedCountryLanguages: Observable<Country[]>;
  language = new FormControl('language');
  selectedCountryLanguageFlag: string;

  subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private countryService: CountryService
  ) { }

  ngOnInit() {
    this.getSupportedLanguages();

    this.subs.add(
      // skip(1) because of initial value
      // so we don't trigger save on every open of settings
      this.language.valueChanges.pipe(skip(1)).subscribe(value => {
        this.userSetting.language = value;
        this.getCountryFlag(value);
        this.store.dispatch(updateUserSetting(this.userSetting));
        this.store.dispatch(setLanguage({ language: this.userSetting.language }))
      })
    )

    this.store.select(userSetting).pipe(take(1))
      .subscribe((userSetting: UserSetting) => {
        this.userSetting = { ...userSetting };
        this.language.setValue(this.userSetting.language);
        this.getCountryFlag(this.userSetting.language);
      });
  }

  getSupportedLanguages() {
    this.supportedCountryLanguages = this.countryService.getCountriesByCodes('us', 'hr');
  }

  getCountryFlag(language: string) {
    this.supportedCountryLanguages.pipe(
      map(countries => {
        var country = countries.filter(c => c.languages[0].iso639_1 == language)[0];
        return country.flag;
      }
      )).subscribe(flag => this.selectedCountryLanguageFlag = flag);
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

  public onUsePercentagesChecked(event: MatCheckboxChange) {
    this.userSetting.usePercentages = event.checked;
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
