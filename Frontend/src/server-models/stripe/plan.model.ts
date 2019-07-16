import { Metadata } from './metadata.model';

export interface Plan {
  id: string;
  currency: string;
  interval: string;
  livemode: boolean;
  nickname: string;
  metadata: Metadata;
  amount: number;
}
