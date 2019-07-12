import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { ReplaySubject } from 'rxjs';
import { distinctUntilChanged, shareReplay, take } from 'rxjs/operators';
import { SubSink } from 'subsink';

@Injectable({ providedIn: 'root'})
export class SidebarService {

  private subs = new SubSink();

  private appSidenav: MatSidenav;
  private settingsSidenav: MatSidenav;

  public isMobile = new ReplaySubject<boolean>(1);
  private _isMobile: boolean;
  public showSettingsMenuButton: boolean;

  constructor() {
    this.subs.add(
      this.isMobile
        .pipe(distinctUntilChanged(), shareReplay(1))
        .subscribe(
          (value: boolean) => {
            this._isMobile = value;
            this.adjustSettingsSidenav(value);
          }));
  }

  private adjustSettingsSidenav(isMobile: boolean) {
    this.settingsSidenav && (isMobile ? this.closeSettings() : this.openSettings());
  }

  public setAppSidenav(sidenav: MatSidenav) {
    if (!this.appSidenav) this.appSidenav = sidenav;
  }
  public setSettingsSidenav(sidenav: MatSidenav) {
    this.settingsSidenav = sidenav;
    this.isMobile.pipe(take(1)).subscribe((value: boolean) => this.adjustSettingsSidenav(value));
  }

  public toggleApp(): void {
    this.appSidenav.toggle();
  }
  public toggleSettings(): void {
    if(this._isMobile) {
      this.settingsSidenav.toggle();
      this.showSettingsMenuButton = !this.showSettingsMenuButton;
    }
  }

  public closeApp(): void {
    this.appSidenav.mode = 'over';
    this.appSidenav.close();
  }
  public closeSettings(): void {
    this.settingsSidenav.mode = 'over';
    this.settingsSidenav.close();
    this.showSettingsMenuButton = true;
  }

  public openSettings(): void {
    this.settingsSidenav.mode = 'side';
    this.settingsSidenav.open();
    this.showSettingsMenuButton = false;
  }

  
  public get settingsToggled() : boolean {
    return this.settingsSidenav.opened;
  }
  public get appToggled(): boolean {
    return this.appSidenav.opened;
  }
  

}