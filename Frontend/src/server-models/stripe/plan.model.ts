import { Metadata } from './metadata.model';
import { Expose } from 'class-transformer';

export interface Plan {
  id: string;
  currency: string;
  interval: string;
  livemode: boolean;
  nickname: string;
  metadata: Metadata;
  amount: number;
}
