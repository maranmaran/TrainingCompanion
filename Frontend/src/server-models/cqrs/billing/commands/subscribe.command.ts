export class SubscribeCommand {
    customerId: string;
    planId: string;

    /**
     *
     */
    constructor(customerId: string, planId: string) {
        this.customerId = customerId;
        this.planId = planId;
    }
}