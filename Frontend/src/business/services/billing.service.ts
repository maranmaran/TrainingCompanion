import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';
import { GetSubscriptionQuery } from 'src/server-models/cqrs/billing/queries/get-subscription.query';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { GetPlansResponse } from 'src/server-models/cqrs/billing/responses/get-plans.response';
import { PlanAdapter } from 'src/business/adapters/plan.adapter';
import { SubscribeCommand } from 'src/server-models/cqrs/billing/commands/subscribe.command';
import { BaseService } from './base.service';
import { SubscriptionAdapter } from '../adapters/subscription.adapter';
import { AddPaymentOptionCommand } from 'src/server-models/cqrs/billing/commands/add-payment-option.command';

@Injectable()
export class BillingService extends BaseService {
  private url = '/Billing/';

  constructor(
    private http: HttpClient,
    private subscriptionAdapter: SubscriptionAdapter,
    private planAdapter: PlanAdapter
  ) {
    super();
  }

  public getSubscriptionInformation(query: GetSubscriptionQuery) {

    return this.http
      .get<Subscription>(
        this.url + 'GetSubscriptionForCustomer/' + query.customerId
      )
      .pipe(
        map(
          (res: Subscription) => this.subscriptionAdapter.adaptToModel(res),
          catchError(this.handleError)
        )
      );
  }

  public cancelSubscription(subscriptionId: string) {
    return this.http.get(this.url + 'CancelSubscription/' + subscriptionId);
  }

  public getAvailablePlans() {
    return this.http.get<GetPlansResponse>(this.url + 'GetAvailablePlans/')
      .pipe(
        map((res: GetPlansResponse) => this.planAdapter.adaptToList(res.plans.data)),
        catchError(this.handleError)
      );
  }

  public subscribeCustomer(customerId: string, planId: string) {
    const command = new SubscribeCommand(customerId, planId);
    return this.http.post<Subscription>(this.url + 'SubscribeCustomer', command)
      .pipe(
        map((res: Subscription) => this.subscriptionAdapter.adaptToModel(res)),
        catchError(this.handleError)
      );
  }

  public addPaymentOption(customerId: string, token) {
    const command = new AddPaymentOptionCommand(customerId, token.token.id);
    return this.http.post<void>(this.url + 'AddPaymentOption', command)
      .pipe(
        catchError(this.handleError)
      );
  }
}
