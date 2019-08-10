export class ConfirmDialogConfig {
    message: string;
    action: Function;
    actionParams: any[] = [];
    allowConfirm: boolean = true;
    allowCancel: boolean = true;
    confirmLabel: string = 'Proceed';
    title: string = null

    public constructor(init?:Partial<ConfirmDialogConfig>) {
        Object.assign(this, init);
    }
}

export enum ConfirmResult {
    Confirm = "Confirm",
    Reject = "Reject"
}