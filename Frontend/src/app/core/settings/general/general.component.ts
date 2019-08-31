import { Component, OnInit } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { Theme } from 'src/business/shared/theme.enum';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { updateUserSettings } from 'src/ngrx/auth/auth.actions';
import { userSettings } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { UserService } from '../../../../business/services/feature-services/user.service';
import { UserSettings } from './../../../../server-models/entities/user-settings.model';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.scss']
})
export class GeneralComponent implements OnInit {

  public userSettings: UserSettings;

  constructor(
    private store: Store<AppState>,
    private usersService: UserService,
  ) { }

  ngOnInit() {
    this.store.select(userSettings).pipe(take(1))
      .subscribe((userSettings: UserSettings) => {
        this.userSettings = { ...userSettings };
      });
  }

  get themeButtonChecked(): boolean { return this.userSettings.theme == Theme.Dark; }

  public onThemeChange(event: MatSlideToggleChange) {
    if (event.checked) this.userSettings.theme = Theme.Dark;
    if (!event.checked) this.userSettings.theme = Theme.Light;

    this.store.dispatch(updateUserSettings(this.userSettings));
    this.onSaveSettings(this.userSettings);
  }

  private onSaveSettings(userSettings: UserSettings) {

    this.usersService.saveSettings(userSettings)
      .pipe(take(1))
      .subscribe(
        () => { },
        err => console.log(err),
      );

  }
}
