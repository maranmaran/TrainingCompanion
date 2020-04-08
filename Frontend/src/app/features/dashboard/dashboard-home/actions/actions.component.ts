import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { DashboardService } from 'src/app/features/dashboard/services/dashboard.service';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { NotificationSignalrService } from './../../../../../business/services/feature-services/notification-signalr.service';
import { UIService } from './../../../../../business/services/shared/ui.service';
import { currentUserId } from './../../../../../ngrx/auth/auth.selectors';
import { setTrackEditMode } from './../../../../../ngrx/dashboard/dashboard.actions';
import { trackEditMode } from './../../../../../ngrx/dashboard/dashboard.selectors';

@Component({
  selector: 'app-actions',
  templateUrl: './actions.component.html',
  styleUrls: ['./actions.component.scss']
})
export class ActionsComponent implements OnInit {

  editMode: Observable<boolean>;

  constructor(
    private store: Store<AppState>,
    private UIService: UIService,
    private notificationService: NotificationSignalrService,
    private dashboardService: DashboardService
  ) { }

  ngOnInit(): void {
    this.editMode = this.store.select(trackEditMode);
  }

  toggleSidenav() {
    this.store.dispatch(setTrackEditMode());
    this.UIService.doSidenavAction(UISidenav.DashboardComponents, UISidenavAction.Toggle);
  }

  //TODO: TEST
  sendNotification() {

    this.store.select(currentUserId).pipe(take(1)).subscribe(id => {
      this.notificationService.sendNotification(
        NotificationType.TrainingCreated,
        "Test notification " + Math.round(Math.random() * 10) + " from client",
        id,
        id)
    });
  }

  saveCardParams() {
    this.dashboardService.saveTrackItemParams.next();
  }



}
