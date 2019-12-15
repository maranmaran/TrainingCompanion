import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { getTestBarChartConfig, getTestLineChartConfig, getTestPieChartConfig } from 'src/app/shared/charts/chart-config.factory';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { AppState } from 'src/ngrx/app/app.state';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { currentUserId } from './../../../../ngrx/auth/auth.selectors';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.scss']
})
export class DashboardHomeComponent implements OnInit {

  pieChartConfig = getTestPieChartConfig();
  lineChartConfig = getTestLineChartConfig();
  barChartConfig = getTestBarChartConfig();

  private userId: string;

  constructor(
    private notificationService: NotificationSignalrService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.store.select(currentUserId).pipe(take(1)).subscribe(userId => this.userId = userId);
  }

  activateNotif() {
    this.notificationService.sendNotification(
      NotificationType.TrainingCreated,
      "Test notification " + Math.round(Math.random() * 10) + " from client",
      this.userId,
      this.userId);
  }

}
