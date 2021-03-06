import { Component, Inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { UIService } from 'src/business/services/shared/ui.service';
import { UIProgressBar } from 'src/business/shared/ui-progress-bars.enum';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { isCoachOrSoloAthlete } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { getLoadingState } from 'src/ngrx/user-interface/ui.selectors';
import { UserService } from '../../../business/services/feature-services/user.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
  providers: [UserService]
})
export class SettingsComponent implements OnInit, OnDestroy {

  public activeTab: 'General' | 'Account' | 'Billing' = 'General'

  public loading$: Observable<boolean>;
  public isCoach: Observable<boolean>;

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;

  constructor(
    private router: Router,
    public uiService: UIService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<SettingsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, section: 'General' | 'Account' | 'Billing' }
  ) {
  }

  ngOnInit() {
    // store state setup
    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.SettingsScreen }));
    this.isCoach = this.store.select(isCoachOrSoloAthlete);

    this.loading$ = getLoadingState(this.store, UIProgressBar.SettingsScreen);;

    this.uiService.addOrUpdateSidenav(UISidenav.Settings, this.sidenav);

    // if there is any section wanted added open it
    this.data.section && this.openTab(this.data.section);
  }

  ngOnDestroy(): void {
    this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.MainAppScreen }));

    // route to root component path if section is given (means it came from some deeplink)
    this.data.section && this.router.navigate(['']);
  }

  public onClose = () => {
    this.dialogRef.close();
  };

  public openTab = (tab: 'General' | 'Account' | 'Billing') => {
    this.activeTab = tab;

    (this.uiService.isSidenavOpened(UISidenav.Settings) as Observable<boolean>)
      .pipe(take(1))
      .subscribe(isOpened => {
        isOpened && this.uiService.doSidenavAction(UISidenav.Settings, UISidenavAction.Toggle)
      }
      );
  }

  public toggleSidenav = () => this.uiService.doSidenavAction(UISidenav.Settings, UISidenavAction.Toggle);
}
