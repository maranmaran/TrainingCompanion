import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { take } from 'rxjs/operators';
import { NotificationService } from 'src/business/services/shared/notification.service';
import { ThemeService } from 'src/business/services/shared/theme.service';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UsersService } from './../../../../business/services/user.service';
import { CurrentUserStore } from './../../../../business/stores/current-user.store';
import { UserSettings } from './../../../../server-models/entities/user-settings.model';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.scss']
})
export class GeneralComponent implements OnInit {

  public userSettings: UserSettings;
  @Output() loading = new EventEmitter<boolean>();

  constructor(
    private themeService: ThemeService,
    private currentUserStore: CurrentUserStore,
    private notificationService: NotificationService,
    private usersService: UsersService,
  ) { }

  ngOnInit() {
    this.userSettings = this.currentUserStore.state.userSettings;
  }

  ngOnDestroy(): void {
    // reset loading bars back
    this.loading.emit(false);
    this.notificationService.showAppLoadingBar = true;
  }

  get themeButtonChecked(): boolean { return this.userSettings.theme == 'Dark'; }

  public onThemeChange(event: MatSlideToggleChange) {
    if (event.checked) this.userSettings.theme = 'Dark';
    if (!event.checked) this.userSettings.theme = 'Light';

    this.currentUserStore.setSettings(this.userSettings);
    this.themeService.setTheme(this.userSettings.theme);
    this.onSaveSettings(this.currentUserStore.state);
  }

  private onSaveSettings(currentUser: CurrentUser) {

    this.notificationService.showAppLoadingBar = false;
    this.loading.emit(true);

    this.usersService.saveSettings(currentUser)
      .pipe(take(1))
      .subscribe(
        () => { },
        err => console.log(err),
        () => {
          this.loading.emit(false);
          this.notificationService.showAppLoadingBar = true;
        }
      );

  }
}
