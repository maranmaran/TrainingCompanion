import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Token } from 'ngx-stripe';
import { concatMap, take } from 'rxjs/operators';
import { BillingService } from 'src/business/services/billing.service';
import { NotificationService } from 'src/business/services/shared/notification.service';
import { CurrentUserStore } from 'src/business/stores/current-user.store';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { Plan } from 'src/server-models/stripe/plan.model';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { StripeCheckoutComponent } from './stripe-checkout/stripe-checkout.component';

@Component({
  selector: "app-billing",
  templateUrl: "./billing.component.html",
  styleUrls: ["./billing.component.scss"],
  providers: [BillingService]
})
export class BillingComponent implements OnInit, OnDestroy {

  public currentUser: CurrentUser;
  public subscriptionValid: boolean;
  public plans: Plan[];

  // local loading bar which is inside dialog vs app loading bar which is below toolbar
  @Output() loading = new EventEmitter<boolean>(true);

  constructor(
    private dialog: MatDialog,
    private billingService: BillingService,
    private currentUserStore: CurrentUserStore,
    private notificationService: NotificationService
  ) { }

  ngOnInit() {
    this.currentUser = this.currentUserStore.state;
    this.plans = this.currentUser.plans.data;
    this.subscriptionValid = this.currentUserStore.isSubscribed;
  }

  ngOnDestroy(): void {
    // reset loading bars back
    this.loading.emit(false);
    this.notificationService.showAppLoadingBar = true;
  }

  public onCancelSubscription(subscriptionId: string) {

    this.notificationService.showAppLoadingBar = false;
    this.loading.emit(true);

    this.billingService.cancelSubscription(subscriptionId)
      .pipe(take(1))
      .subscribe(
        () => {
          this.currentUserStore.cancelSubscription();
        },
        (err: HttpErrorResponse) => {
          console.log(err);
        },
        () => {
          this.loading.emit(false);
          this.notificationService.showAppLoadingBar = true;
        }
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
          const customerId = this.currentUserStore.customerId;

          this.subscribe(customerId, planId, token);
        }
      });
  }

  private subscribe(customerId: string, planId: string, token: Token) {

    this.notificationService.showAppLoadingBar = false;
    this.loading.emit(true);

    this.billingService.addPaymentOption(customerId, token)
      .pipe(
        take(1),
        concatMap(() => this.billingService.subscribeCustomer(customerId, planId).pipe(take(1)))
      )
      .subscribe(
        (res: Subscription) => this.currentUserStore.addSubscription(res),
        err => console.log(err),
        () => {
          this.loading.emit(false);
          this.notificationService.showAppLoadingBar = true;
        }
      );
  }
}
