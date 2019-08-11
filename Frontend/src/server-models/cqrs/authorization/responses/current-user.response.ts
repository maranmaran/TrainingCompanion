import { Subscription } from '../../../stripe/subscription.model';
import { Plan } from '../../../stripe/plan.model';
import { UserSettings } from '../../../entities/user-settings.model';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { StripeList } from 'src/server-models/stripe/stripe-list.model';

export interface CurrentUser {
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
    trialDaysRemaining: number;
    splashDialogDate: string;
    userSettings: UserSettings;
    subscriptionInfo: Subscription;
    plans: StripeList<Plan>;
}