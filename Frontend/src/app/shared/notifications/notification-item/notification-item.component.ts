import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { PushNotification } from 'src/server-models/entities/push-notification.model';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-notification-item',
  templateUrl: './notification-item.component.html',
  styleUrls: ['./notification-item.component.scss']
})
export class NotificationItemComponent {

  @Input() model: PushNotification;
  @Input() unitSystem: UnitSystem;
  notificationType = NotificationType;

  constructor(
    private router: Router,
  ) { }

  

  navigate() {

    switch(this.model.type) {
      case NotificationType.TrainingCreated: 
        this.navigateTraining();
        break;
    }
  }
  
  navigateTraining() {
    
    const queryParams = {
      viewAs: this.model.entity.applicationUserId,
      trainingId: this.model.entity.id
    };
    
    this.router.navigate(["/app/training-log/training-details"], { queryParams })
  }


}
