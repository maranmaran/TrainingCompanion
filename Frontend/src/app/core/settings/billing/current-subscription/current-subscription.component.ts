import { Subscription } from 'src/server-models/stripe/subscription.model';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SubscriptionStatus } from 'src/server-models/enums/subscription-status.enum';

@Component({
  selector: 'app-current-subscription',
  templateUrl: './current-subscription.component.html',
  styleUrls: ['./current-subscription.component.scss']
})
export class CurrentSubscriptionComponent implements OnInit {

  @Input() subscription: Subscription;
  SubscriptionStatus = SubscriptionStatus; // add enum as property to use it in html

  @Output() cancelSubscription = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
  }

}
