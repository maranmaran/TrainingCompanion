import { Component, OnInit } from '@angular/core';
import { getTestBarChartConfig, getTestLineChartConfig, getTestPieChartConfig } from 'src/app/shared/charts/chart-config.factory';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.scss']
})
export class DashboardHomeComponent implements OnInit {

  pieChartConfig = getTestPieChartConfig();
  lineChartConfig = getTestLineChartConfig();
  barChartConfig = getTestBarChartConfig();

  constructor(
    private notificationService: NotificationSignalrService
  ) { }

  ngOnInit() {
  }

  activateNotif() {
    this.notificationService.sendNotification(
      NotificationType.TrainingCreated,
      "Test notification text from client",
      "FDD5335D-8FA5-4D10-8435-D4AEC7B6245A",
      "86C2222F-D07D-4540-A667-FBB663AAC40B");
  }

}
