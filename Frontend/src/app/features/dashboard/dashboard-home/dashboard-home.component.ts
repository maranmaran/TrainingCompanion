import { Component, OnInit } from '@angular/core';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.scss']
})
export class DashboardHomeComponent implements OnInit {

  constructor(
    private notificationService: NotificationSignalrService
  ) { }

  ngOnInit() {
  }

  activateNotif() {
    this.notificationService.sendNotification(
      NotificationType.TrainingCreated,
      "Test notification text from client",
      "E28EBA53-52E4-4FF9-AD02-FDA480BAFB67",
      "91FBE82A-9BA3-4BEA-A744-8766751F8357");
  }

}
