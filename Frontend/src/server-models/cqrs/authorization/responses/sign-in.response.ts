import { Subscription } from 'src/server-models/stripe/subscription.model';
import { SubscriptionStatus } from '../../../enums/subscription-status.enum';

export interface SignInResponse {
     id: string;
     customerId: string;
     username: string;
     firstName: string;
     lastName: string;
     fullName: string;
     email: string;
     accountType: string;
     active: boolean;
     subscriptionStatus: SubscriptionStatus;
     subscriptionInfo: Subscription;
     trialDaysRemaining: number;
}
