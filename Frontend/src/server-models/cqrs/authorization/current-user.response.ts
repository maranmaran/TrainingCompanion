import { AccountType } from 'src/server-models/enums/account-type.enum';
import { Gender } from 'src/server-models/enums/gender.enum';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { StripeList } from 'src/server-models/stripe/stripe-list.model';
import { UserSetting } from '../../../server-models/entities/user-settings.model';
import { Plan } from '../../../server-models/stripe/plan.model';
import { Subscription } from '../../../server-models/stripe/subscription.model';
import { Bodyweight } from './../../entities/bodyweight.model';

export interface CurrentUser {
    id: string;
    customerId: string;

    username: string;
    email: string;

    firstName: string;
    lastName: string;
    fullName: string;
    gender: Gender;

    avatar: string;

    accountType: AccountType;

    active: boolean;
    userSetting: UserSetting;

    splashDialogDate: string;

    latestBodyweight: Bodyweight;

    subscriptionStatus: SubscriptionStatus;
    subscriptionInfo: Subscription;
    plans: StripeList<Plan>;
    trialDaysRemaining: number;
}
