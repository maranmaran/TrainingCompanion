import { ComponentType } from '@angular/cdk/overlay/index';
import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject, Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { MessageDialogComponent } from 'src/app/shared/message-dialog/message-dialog.component';
import { ConfirmDialogComponent } from '../../../app/shared/confirm-dialog/confirm-dialog.component';

const snackBarDefaultConfig = {
    duration: 5000,
    panelClass: ['warning-snackbar']
};

interface SnackBarConfig {
    panelClass?: string[];
    duration?: number;
    data?: Object;
}

@Injectable({ providedIn: 'root'})
export class UIService {

    private _loading$: BehaviorSubject<boolean>;
    public loading$ = new Observable<boolean>();

    public showAppLoadingBar = true;
    public showSplash = false;
    public showErrorSnackbar = true;

    constructor(
        private snackBar: MatSnackBar,
        private dialog: MatDialog,
    ) {
        this._loading$ = new BehaviorSubject<boolean>(false);
        this.loading$ = this._loading$.asObservable();
    }

    public setLoading(loading: boolean) {
        this._loading$.next(loading);
    }

    public success(message: string) {
        this.showSnackBar(message, {
            panelClass: ['accent-snackbar']
        });
    }

    public warning(message: string) {
        this.showSnackBar(message, {
            panelClass: ['warning-snackbar']
        });
    }

    public error(message: string) {
        this.showSnackBar(message, {
            panelClass: ['error-snackbar']
        });
    }

    public info(message: string) {
        this.showSnackBar(message);
    }

    private showSnackBar(message: string, config?: SnackBarConfig) {
        const opts = Object.assign({}, snackBarDefaultConfig, config);
        this.snackBar.open(message, null, opts);
    }

    public openFromComponent(component: ComponentType<any>, config?: SnackBarConfig) {
        const opts = Object.assign({}, snackBarDefaultConfig, config);
        this.snackBar.openFromComponent(component, opts);
    }

    public openConfirmDialog(message: string, action: Function) {
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            height: 'auto',
            maxWidth: '20rem',
            autoFocus: false,
            data: { message: message },
        });

        dialogRef.afterClosed().pipe(take(1)).subscribe(() => { action.call([]) });
    }

    private _fadeOutMessageDialog: MatDialogRef<MessageDialogComponent>;
    public fadeOutMessage(message: string, timeout: number = 1000) {

        this._fadeOutMessageDialog && this._fadeOutMessageDialog.close();

        this._fadeOutMessageDialog = this.dialog.open(MessageDialogComponent, {
            height: 'auto',
            maxWidth: '20rem',
            autoFocus: false,
            disableClose: true,
            data: { message: message },
        });

        setTimeout(() => {
            this._fadeOutMessageDialog.close();
        }, timeout);
    }
}

