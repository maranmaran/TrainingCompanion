import { Subscription } from '../../../stripe/subscription.model';
import { Plan } from '../../../stripe/plan.model';
import { UserSettings } from '../../../entities/user-settings.model';
import { AccountStatus } from 'src/server-models/enums/account-status.enum';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { StripeList } from 'src/server-models/stripe/stripe-list.model';

export class CurrentUser {
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
    userSettings: UserSettings;
    plans: StripeList<Plan>;
    splashDialogDate: string;
}