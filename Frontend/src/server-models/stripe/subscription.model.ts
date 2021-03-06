import { Metadata } from "./metadata.model";
import { Plan } from "./plan.model";

export interface Subscription {
  id: string;
  items: any;
  metadata: Metadata;
  start_date: Date;
  status: string;
  trial_end: Date;
  trial_start: Date;
}
