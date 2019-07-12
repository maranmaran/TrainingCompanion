import { SubscriptionStatus } from './../enums/subscription-status.enum';
import { Expose } from "class-transformer";
import { Metadata } from "./metadata.model";
import { Plan } from "./plan.model";

export class Subscription {
  @Expose() id: string;
  @Expose() plan: Plan;
  @Expose() metadata: Metadata;
  // tslint:disable-next-line: variable-name
  @Expose() start_date: Date;
  @Expose() status: string;
  // tslint:disable-next-line: variable-name
  @Expose() trial_end: Date;
  // tslint:disable-next-line: variable-name
  @Expose() trial_start: Date;
}
