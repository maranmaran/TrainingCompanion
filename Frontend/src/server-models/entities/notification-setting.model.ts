import { NotificationType } from '../enums/notification-type.enum';

export class NotificationSetting {
    id: string;
    notificationType: NotificationType;
    receiveMail: boolean;
    receiveNotification: boolean;
  }
