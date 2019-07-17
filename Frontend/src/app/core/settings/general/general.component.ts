import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { take } from 'rxjs/operators';
import { UIService } from 'src/business/services/shared/notification.service';
import { ThemeService } from 'src/business/services/shared/theme.service';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UsersService } from './../../../../business/services/user.service';
import { CurrentUserStore } from './../../../../business/stores/current-user.store';
import { UserSettings } from './../../../../server-models/entities/user-settings.model';
import { AppState } from 'src/ngrx/global-reducers';
import { Store } from '@ngrx/store';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { updateUserSettings } from 'src/ngrx/auth/auth.actions';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.scss']
})
export class GeneralComponent implements OnInit {

  public userSettings: UserSettings;
  public currentUser: CurrentUser;
  @Output() loading = new EventEmitter<boolean>();

  constructor(
    private themeService: ThemeService,
    private store: Store<AppState>,
    private UIService: UIService,
    private usersService: UsersService,
  ) { }

  ngOnInit() {
    this.store.select(currentUser).pipe(take(1))
      .subscribe((user: CurrentUser) => {
        this.userSettings = { ...user.userSettings };
      });
  }

  ngOnDestroy(): void {
    // reset loading bars back
    this.loading.emit(false);
    this.UIService.showAppLoadingBar = true;
  }

  get themeButtonChecked(): boolean { return this.userSettings.theme == 'Dark'; }

  public onThemeChange(event: MatSlideToggleChange) {
    if (event.checked) this.userSettings.theme = 'Dark';
    if (!event.checked) this.userSettings.theme = 'Light';

    // dispatch action set new user settings
    this.store.dispatch(updateUserSettings(this.userSettings));
    // this.currentUserStore.setSettings(this.userSettings);
    this.themeService.setTheme(this.userSettings.theme);
    this.onSaveSettings(this.userSettings);
  }

  private onSaveSettings(userSettings: UserSettings) {

    this.UIService.showAppLoadingBar = false;
    this.loading.emit(true);

    this.usersService.saveSettings(userSettings)
      .pipe(take(1))
      .subscribe(
        () => { },
        err => console.log(err),
        () => {
          this.loading.emit(false);
          this.UIService.showAppLoadingBar = true;
        }
      );

  }
}
