import { cancelSubscription } from './../../../../ngrx/auth/auth.actions';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Token } from 'ngx-stripe';
import { concatMap, take } from 'rxjs/operators';
import { BillingService } from 'src/business/services/billing.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { CurrentUserStore } from 'src/business/stores/current-user.store';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { StripeCheckoutComponent } from './stripe-checkout/stripe-checkout.component';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { Plan } from 'src/server-models/stripe/plan.model';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Store } from '@ngrx/store';
import { currentUser, isSubscribed } from 'src/ngrx/auth/auth.selectors';
import { addSubscription } from 'src/ngrx/auth/auth.actions';
import { forkJoin } from 'rxjs/internal/observable/forkJoin';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { SubSink } from 'subsink';

@Component({
  selector: "app-billing",
  templateUrl: "./billing.component.html",
  styleUrls: ["./billing.component.scss"],
  providers: [BillingService]
})
export class BillingComponent implements OnInit, OnDestroy {

  protected currentUser: CurrentUser;
  protected subscriptionValid: boolean;
  protected plans: Plan[];
  private subs = new SubSink();

  constructor(
    private dialog: MatDialog,
    private billingService: BillingService,
    private store: Store<AppState>,
  ) { }

  ngOnInit() {

    this.subs.add(
      combineLatest(
        this.store.select(currentUser), 
        this.store.select(isSubscribed)
        )
        .subscribe(([user, isSubscribed]) => {
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
      height: 'auto',
      width: '25rem',
      maxWidth: '100%',
      autoFocus: false,
      panelClass: 'stripe-checkout-container'
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

  private subscribe(customerId: string, planId: string, token: Token) {

    this.billingService.addPaymentOption(customerId, token)
      .pipe(
        take(1),
        concatMap(() => this.billingService.subscribeCustomer(customerId, planId).pipe(take(1)))
      )
      .subscribe(
        (res: Subscription) => {
          this.store.dispatch(addSubscription(res));
        },
        err => console.log(err),
      );
  }
}
