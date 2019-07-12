import { Subscription } from 'src/server-models/stripe/subscription.model';
import { AccountStatus } from '../../../enums/account-status.enum';
import { SubscriptionStatus } from '../../../enums/subscription-status.enum';

export class SignInResponse {
     id: string;
     customerId: string;
     username: string;
     firstName: string;
     lastName: string;
     fullName: string;
     email: string;
     accountType: string;
     accountStatus: AccountStatus;
     subscriptionStatus: SubscriptionStatus;
     subscriptionInfo: Subscription;
     trialDaysRemaining: number;
}
