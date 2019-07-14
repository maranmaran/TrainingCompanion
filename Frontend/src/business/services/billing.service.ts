import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';
import { PlanAdapter } from 'src/business/adapters/plan.adapter';
import { GetPlansResponse } from 'src/server-models/cqrs/billing/responses/get-plans.response';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { SubscriptionAdapter } from '../adapters/subscription.adapter';
import { BaseService } from './base.service';
import { SubscribeRequest } from 'src/server-models/cqrs/billing/requests/subscribe.request';
import { GetSubscriptionRequest } from 'src/server-models/cqrs/billing/requests/get-subscription.request';
import { AddPaymentOptionRequest } from 'src/server-models/cqrs/billing/requests/add-payment-option.request';

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

  public getSubscriptionInformation(query: GetSubscriptionRequest) {

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
    const command = new SubscribeRequest(customerId, planId);
    return this.http.post<Subscription>(this.url + 'SubscribeCustomer', command)
      .pipe(
        map((res: Subscription) => this.subscriptionAdapter.adaptToModel(res)),
        catchError(this.handleError)
      );
  }

  public addPaymentOption(customerId: string, token) {
    const command = new AddPaymentOptionRequest(customerId, token.token.id);
    return this.http.post<void>(this.url + 'AddPaymentOption', command)
      .pipe(
        catchError(this.handleError)
      );
  }
}
