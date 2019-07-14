
export class AddPaymentOptionRequest {
    customerId: string;
    token: string;

    constructor(customerId: string, token: string) {
        this.customerId = customerId;
        this.token = token;        
    }
}