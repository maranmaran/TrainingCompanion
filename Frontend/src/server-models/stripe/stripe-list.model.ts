export interface StripeList<T> {
    data: T[];
    object: string;
    url: string;
    has_more: boolean;
}