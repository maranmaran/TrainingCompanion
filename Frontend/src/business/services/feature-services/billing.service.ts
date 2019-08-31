import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';
import { GetPlansResponse } from 'src/server-models/cqrs/billing/responses/get-plans.response';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { BaseService } from '../base.service';
import { SubscribeRequest } from 'src/server-models/cqrs/billing/requests/subscribe.request';
import { GetSubscriptionRequest } from 'src/server-models/cqrs/billing/requests/get-subscription.request';
import { AddPaymentOptionRequest } from 'src/server-models/cqrs/billing/requests/add-payment-option.request';

@Injectable()
export class BillingService extends BaseService {
  private url = '/Billing/';

  constructor(
    private http: HttpClient,
  ) {
    super();
  }

  public getSubscriptionInformation(query: GetSubscriptionRequest) {

    return this.http
      .get<Subscription>(
        this.url + 'GetSubscriptionForCustomer/' + query.customerId
      )
      .pipe(
        catchError(this.handleError)
      );
  }

  public cancelSubscription(subscriptionId: string) {
    return this.http.get(this.url + 'CancelSubscription/' + subscriptionId);
  }

  public getAvailablePlans() {
    return this.http.get<GetPlansResponse>(this.url + 'GetAvailablePlans/')
      .pipe(
        catchError(this.handleError)
      );
  }

  public subscribeCustomer(customerId: string, planId: string) {
    const command = new SubscribeRequest(customerId, planId);
    return this.http.post<Subscription>(this.url + 'SubscribeCustomer', command)
      .pipe(
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
