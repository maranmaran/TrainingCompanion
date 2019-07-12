import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { UserSettings } from './../../server-models/entities/user-settings.model';
import { BaseStore } from './base.store';
import { AccountType } from 'src/server-models/enums/account-type.enum';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class CurrentUserStore extends BaseStore<CurrentUser> {

    constructor() {
        super(undefined);
    }

    public get userFullName(): string {
        return this.state.fullName;
    }

    public get email(): string {
        return this.state.email;
    }

    public get isTrialing(): boolean {
        return this.trialDaysRemaining > 0 ? true : false;
    }

    public get isUser(): boolean {
        const accountType = AccountType[this.state.accountType];
        return  accountType == AccountType.User || accountType == AccountType.Admin;
    }

    public get trialDaysRemaining(): number {
        return this.state.trialDaysRemaining as unknown as number;
    }

    public get customerId(): string {
        return this.state.customerId;
    }

    public set subscriptionStatus(status: SubscriptionStatus) {
        this.state.subscriptionStatus = status;
        this.setState(this.state);
    }

    private isSubscriptionValid(status: SubscriptionStatus): boolean {
        if (this.trialDaysRemaining != 0) return true;

        switch (status) {
            case SubscriptionStatus.active:
                return true;
            default:
                return false;
        }
    }

    public get isSubscribed(): boolean {
        return this.isSubscriptionValid(this.state.subscriptionStatus);
    }

    public addSubscription(subscription: Subscription) {
        this.state.subscriptionInfo = subscription;
        this.state.subscriptionStatus = SubscriptionStatus[subscription.status];
        
        this.setState(this.state);
    }

    public cancelSubscription() {
        this.state.subscriptionInfo = undefined;
        this.state.subscriptionStatus = SubscriptionStatus.canceled;

        this.setState(this.state);
    }

    public setSettings(userSettings: UserSettings){
        this.state.userSettings = userSettings;
        this.setState(this.state);
    }

  
}
