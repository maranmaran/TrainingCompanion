import { Plan } from 'src/server-models/stripe/plan.model';
import { StripeList } from 'src/server-models/stripe/stripe-list.model';

export class GetPlansResponse {
    plans: StripeList<Plan>;
}