import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs';
import { concatMap, take } from 'rxjs/operators';
import { BillingService } from 'src/business/services/feature-services/billing.service';
import { addSubscription } from 'src/ngrx/auth/auth.actions';
import { currentUser, isSubscribed } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { Plan } from 'src/server-models/stripe/plan.model';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { SubSink } from 'subsink';
import { cancelSubscription } from './../../../../ngrx/auth/auth.actions';
import { StripeCheckoutComponent } from './stripe-checkout/stripe-checkout.component';

@Component({
  selector: "app-billing",
  templateUrl: "./billing.component.html",
  styleUrls: ["./billing.component.scss"],
  providers: [BillingService]
})
export class BillingComponent implements OnInit, OnDestroy {

  currentUser: CurrentUser;
  subscriptionValid: boolean;
  plans: Plan[];
  private subs = new SubSink();

  constructor(
    private dialog: MatDialog,
    private billingService: BillingService,
    private store: Store<AppState>,
  ) { }

  ngOnInit() {

    this.subs.add(
      combineLatest([
        this.store.select(currentUser),
        this.store.select(isSubscribed)
      ]).subscribe(([user, isSubscribed]) => {
        this.currentUser = user;
        this.plans = this.currentUser.plans.data;
        this.subscriptionValid = isSubscribed;
      })
    );
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public onCancelSubscription(subscriptionId: string) {

    this.billingService.cancelSubscription(subscriptionId)
      .pipe(take(1))
      .subscribe(
        () => {
          console.log('cancel subscription')
          this.store.dispatch(cancelSubscription());
        },
        (err: HttpErrorResponse) => {
          console.log(err);
        },
      );
  }

  public onSubscribe(planId: string) {

    // open setup
    const dialogRef = this.dialog.open(StripeCheckoutComponent, {
      height: '36.3rem',
      width: '25rem',
      maxWidth: '100%',
      autoFocus: false,
      panelClass: ['stripe-checkout-container', 'dialog-container']
    });

    // handle close
    dialogRef
      .afterClosed().pipe(take(1))
      .subscribe((token: any) => {
        if (token && token !== 'Closed') {
          const customerId = this.currentUser.customerId;

          this.subscribe(customerId, planId, token);
        }
      });
  }

  private subscribe(customerId: string, planId: string, token) {

    this.billingService.addPaymentOption(customerId, token)
      .pipe(
        take(1),
        concatMap(() => this.billingService.subscribeCustomer(customerId, planId).pipe(take(1)))
      )
      .subscribe(
        (res: Subscription) => {
          console.log('add subscription')
          this.store.dispatch(addSubscription(res));
        },
        err => console.log(err),
      );
  }
}
