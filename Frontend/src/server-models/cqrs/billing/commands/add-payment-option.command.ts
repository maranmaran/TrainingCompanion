import { Token } from 'ngx-stripe';

export class AddPaymentOptionCommand {
    customerId: string;
    token: string;

    constructor(customerId: string, token: string) {
        this.customerId = customerId;
        this.token = token;        
    }
}