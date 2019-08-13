import { AccountType } from 'src/server-models/enums/account-type.enum';
import { Gender } from 'src/server-models/enums/gender.enum';
import { Subscription } from '../../../stripe/subscription.model';
import { Plan } from '../../../stripe/plan.model';
import { UserSettings } from '../../../entities/user-settings.model';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { StripeList } from 'src/server-models/stripe/stripe-list.model';

export interface CurrentUser {
    id: string;
    customerId: string;

    username: string;
    email: string;

    firstName: string;
    lastName: string;
    fullName: string;
    gender: Gender;

    accountType: AccountType;

    active: boolean;
    userSettings: UserSettings;
    
    splashDialogDate: string;
    
    subscriptionStatus: SubscriptionStatus;
    subscriptionInfo: Subscription;
    plans: StripeList<Plan>;
    trialDaysRemaining: number;
}