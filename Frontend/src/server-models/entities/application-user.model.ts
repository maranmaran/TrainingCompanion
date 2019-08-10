import { AccountStatus } from '../enums/account-status.enum';
import { AccountType } from '../enums/account-type.enum';
import { SubscriptionStatus } from '../enums/subscription-status.enum';
import { UserSettings } from './user-settings.model';

export class ApplicationUser {
     id: string;
     customerId: string;
     username: string;
     email: string;
     passwordHash: string;
     fullName: string;
     firstName: string;
     lastName: string;
     
     createdOn: string;
     lastModified: string;
     
     active: boolean;
     accountStatus: AccountStatus;
     accountType: AccountType;
     subscriptionStatus: SubscriptionStatus;
     trialDaysRemaining: number;

     coachId?: string;
     coach: ApplicationUser;

     userSettingsId?: string;
     userSettings: UserSettings;

     athletes: ApplicationUser[];
}
