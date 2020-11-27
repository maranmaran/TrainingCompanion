import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { SubscriptionStatusTranslation } from './../../../../../server-models/enums/subscription-status.enum';

@Component({
  selector: 'app-current-subscription',
  templateUrl: './current-subscription.component.html',
  styleUrls: ['./current-subscription.component.scss']
})
export class CurrentSubscriptionComponent implements OnInit {

  @Input() subscription: Subscription;
  SubscriptionStatus = SubscriptionStatus;
  SubscriptionStatusTranslation = SubscriptionStatusTranslation;
  subscriptionItem: any


  @Output() cancelSubscription = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
    this.subscriptionItem = this.subscription.items.data[0]
  }

}
