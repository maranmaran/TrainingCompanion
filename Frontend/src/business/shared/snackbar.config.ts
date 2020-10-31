export interface SnackBarConfig {
    panelClass?: string[];
    duration?: number;
    data?: Object;
    height?: string,
    width?: string,
    maxWidth?: string,
    autoFocus?: false,
}

export const snackBarDefaultConfig = {
    duration: 5000,
    panelClass: ['warning-snackbar', "dialog-container"]
};
