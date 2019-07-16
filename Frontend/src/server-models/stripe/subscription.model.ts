import { SubscriptionStatus } from './../enums/subscription-status.enum';
import { Expose } from "class-transformer";
import { Metadata } from "./metadata.model";
import { Plan } from "./plan.model";

export interface Subscription {
  id: string;
  plan: Plan;
  metadata: Metadata;
  // tslint:disable-next-line: variable-name
  start_date: Date;
  status: string;
  // tslint:disable-next-line: variable-name
  trial_end: Date;
  // tslint:disable-next-line: variable-name
  trial_start: Date;
}
