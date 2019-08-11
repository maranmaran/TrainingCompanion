export class ErrorDetails {
    exception: any;
    message: string;
    status: number;
}

export class ValidationErrors {
    status: number;
    title: string;
    traceId: string;
    errors: any;
}
