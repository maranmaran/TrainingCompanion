import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { CurrentUserStore } from 'src/business/stores/current-user.store';
import { Component, Inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { SidebarService } from 'src/business/services/shared/sidebar.service';
import { UsersService } from './../../../business/services/user.service';
import { AppState } from 'src/ngrx/global-reducers';
import { Store } from '@ngrx/store';
import { isUser } from 'src/ngrx/auth/auth.selectors';
import { take } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
  providers: [UsersService]
})
export class SettingsComponent implements OnInit, OnDestroy {

  public activeTab: 'General' | 'Account' | 'Billing' = 'General'
  //public loading$ = this.UIService.loading$.pipe(delay(0));
  public isLoading: boolean = false;
  public isUser: Observable<boolean>;
   

  @ViewChild(MatSidenav, {static: true}) sidenav: MatSidenav;

  constructor(
    private router: Router,
    private store: Store<AppState>,
    protected sidebarService: SidebarService,
    protected dialogRef: MatDialogRef<SettingsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, section: 'General' | 'Account' | 'Billing' }
  ) { 
  }

  ngOnInit() {
    this.sidebarService.setSettingsSidenav(this.sidenav);
    this.isUser = this.store.select(isUser);
    // if there is any section wanted added open it
    this.data.section && this.openTab(this.data.section);
  }

  ngOnDestroy(): void {
    // route to root component path if section is given (means it came from some deeplink)
    this.data.section && this.router.navigate(['']);
  }
  
  public onClose = () => this.dialogRef.close('Closed');
  public openTab = (tab: 'General' | 'Account' | 'Billing') => {
    this.activeTab = tab;
    this.sidebarService.toggleSettings();
  };
  public toggleSidenav = () => this.sidebarService.toggleSettings();
  public setLoading = (loading: boolean) => this.isLoading = loading; 

}
