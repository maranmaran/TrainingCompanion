import { Metadata } from './metadata.model';
import { Expose } from 'class-transformer';

export class Plan {
  @Expose() id: string;
  @Expose() currency: string;
  @Expose() interval: string;
  @Expose() livemode: boolean;
  @Expose() nickname: string;
  @Expose() metadata: Metadata;
  @Expose() amount: number;
}
