import { UISidenavAction } from './../../../business/models/ui-sidenavs.enum';
import { UIService } from 'src/business/services/shared/ui.service';
import { Component, Inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { isUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UsersService } from './../../../business/services/user.service';
import { requestLoading, activeProgressBar } from 'src/ngrx/user-interface/ui.selectors';
import { UIProgressBar } from 'src/business/models/ui-progress-bars.enum';
import { map } from 'rxjs/operators';
import { UISidenav } from 'src/business/models/ui-sidenavs.enum';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
  providers: [UsersService]
})
export class SettingsComponent implements OnInit, OnDestroy {

  public activeTab: 'General' | 'Account' | 'Billing' = 'General'

  public loading$: Observable<boolean>;
  public activeProgressBar$: Observable<UIProgressBar>;
  public isUser: Observable<boolean>;


  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;

  constructor(
    private router: Router,
    private uiService: UIService,
    private store: Store<AppState>,
    protected dialogRef: MatDialogRef<SettingsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, section: 'General' | 'Account' | 'Billing' }
  ) {
  }

  ngOnInit() {
    // store state setup
    this.activeProgressBar$ = this.store.select(activeProgressBar);

    this.isUser = this.store.select(isUser);

    this.loading$ = combineLatest(
      this.store.select(requestLoading),
      this.store.select(activeProgressBar)
    ).pipe(map(([isLoading, progressBar]) => isLoading && progressBar == UIProgressBar.SettingsScreen));



    this.uiService.addOrUpdateSidenav(UISidenav.Settings, this.sidenav);

    // if there is any section wanted added open it
    this.data.section && this.openTab(this.data.section);
  }

  ngOnDestroy(): void {
    // route to root component path if section is given (means it came from some deeplink)
    this.data.section && this.router.navigate(['']);
  }

  public onClose = () => this.dialogRef.close('Closed');
  public openTab = (tab: 'General' | 'Account' | 'Billing') => this.activeTab = tab;
    // this.uiService.doSidenavAction(UISidenav.Settings, UISidenavAction.Toggle);
 

  public toggleSidenav = () => this.uiService.doSidenavAction(UISidenav.Settings, UISidenavAction.Toggle);
}
