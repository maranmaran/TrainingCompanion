import { NotificationType } from '../enums/notification-type.enum';
import { ApplicationUser } from './application-user.model';

export class PushNotification {
  id: string;

  type: NotificationType;
  payload: string;

  read: boolean;
  redirectUrl: string;

  senderId: string;
  sender: ApplicationUser;

  systemNotification: boolean;

  receiverId: string;
  receiver: ApplicationUser;
}
