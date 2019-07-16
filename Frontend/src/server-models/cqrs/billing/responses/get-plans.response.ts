import { Plan } from 'src/server-models/stripe/plan.model';
import { StripeList } from 'src/server-models/stripe/stripe-list.model';

export interface GetPlansResponse {
    plans: StripeList<Plan>;
}