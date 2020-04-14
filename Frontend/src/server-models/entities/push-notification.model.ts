import { NotificationType } from '../enums/notification-type.enum';
import { ApplicationUser } from './application-user.model';

export class PushNotification {
  id: string;

  type: NotificationType;
  jsonEntity: string;
  entity: any;
  payload: string;

  read: boolean;
  redirectUrl: string;

  senderId: string;
  sender: ApplicationUser;

  systemNotification: boolean;

  sentAt: Date;

  receiverId: string;
  receiver: ApplicationUser;
}
