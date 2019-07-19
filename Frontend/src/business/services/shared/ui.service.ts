import { UISidenav, UISidenavAction } from './../../models/ui-sidenavs.enum';
import { ComponentType } from '@angular/cdk/overlay/index';
import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { take } from 'rxjs/operators';
import { MessageDialogComponent } from 'src/app/shared/message-dialog/message-dialog.component';
import { ConfirmDialogComponent } from '../../../app/shared/confirm-dialog/confirm-dialog.component';
import { SnackBarConfig, snackBarDefaultConfig } from '../../models/snackbar-config.interface'
import { MatSidenav } from '@angular/material/sidenav';
import { Dictionary } from 'src/business/utils/dictionary';
import { DialogConfig } from 'src/business/models/dialog-config.interface';

@Injectable({ providedIn: 'root'})
export class UIService {


    constructor(
        private snackBar: MatSnackBar,
        private dialog: MatDialog,
    ) { }

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

    public openSnackbarFromComponent(component: ComponentType<any>, config?: SnackBarConfig) {
        const opts = Object.assign({}, snackBarDefaultConfig, config);
        this.snackBar.openFromComponent(component, opts);
    }

    public openDialogFromComponent(component: ComponentType<any>, config?: DialogConfig, callbackAction?: Function) {
        const opts = Object.assign({}, snackBarDefaultConfig, config);

        const dialogRef = this.dialog.open(component, opts);

        dialogRef.afterClosed()
            .pipe(take(1))
            .subscribe((params) => { 
                callbackAction && callbackAction.call(params) 
            });
    }

    public openConfirmDialog(message: string, action: Function) {
        this.openDialogFromComponent(ConfirmDialogComponent, {
            height: 'auto',
            maxWidth: '20rem',
            autoFocus: false,
            data: { message: message },
        }, action);
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

    // --------------------------------------- SIDENAV ---------------------------------------
    private sidenavs = new Dictionary<MatSidenav>();

    public addOrUpdateSidenav(name: UISidenav, sidenav: MatSidenav) {
        this.sidenavs.addOrUpdate(name, sidenav);
    }

    public doSidenavAction(name: UISidenav, actionType: UISidenavAction) {

        var sidenav = this.sidenavs.item(name);
        
        switch (actionType) {
            case UISidenavAction.Open:
                sidenav.mode = 'side';
                sidenav.open();
                //showMenuButton
                break;

            case UISidenavAction.Toggle:
                sidenav.toggle();
                //showMenuButton
                break;

            case UISidenavAction.Close:
                sidenav.mode = 'over';
                sidenav.close();
                //this.showSettingsMenuButton = true;
                break;
        
            default:
                break;
        }
    }
    
    public isSidenavOpened(name: string): Observable<boolean>  {
        return of(this.sidenavs.item(name).opened);
    }
}

