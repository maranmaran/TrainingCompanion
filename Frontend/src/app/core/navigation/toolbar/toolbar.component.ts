import { CurrentUserStore } from './../../../../business/stores/current-user.store';
import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SidebarService } from 'src/business/services/shared/sidebar.service';
import { UIService } from 'src/business/services/shared/notification.service';
import { delay, take } from 'rxjs/operators';
import { SettingsComponent } from '../../settings/settings.component';
import { AuthService } from 'src/business/services/auth.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit, OnDestroy {
  

  public fullName: string;
  public loadingIndicatorVisible = false;
  public loading$ = this.notificationService.loading$.pipe(delay(0));

  private subs = new SubSink();

  constructor(
    private dialog: MatDialog,
    private authService: AuthService,
    private sidebarService: SidebarService,
    protected notificationService: UIService,
    private currentUserStore: CurrentUserStore
  ) { }

  ngOnInit() {
    this.fullName = this.currentUserStore.userFullName;
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public logout() {
    this.authService.signOut();
  }

  public toggleSidebar() {
    this.sidebarService.toggleApp();
  }

  public openSettings(section: string) {
    const dialogRef = this.dialog.open(SettingsComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '58rem',
      autoFocus: false,
      data: { title: 'Settings', section },
      panelClass: 'settings-dialog-container'
    });

    dialogRef.afterClosed().pipe(take(1)).subscribe((result: string) => {
      if (result !== 'Closed') { 
        // do something
      }
    }
    );
  }
}
