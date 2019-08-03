import { isSubscribed, trialDaysRemaining } from './../../../ngrx/auth/auth.selectors';
import { Injectable, HostListener } from '@angular/core';
import { MatDialog, MatDialogRef, MatDialogConfig } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, of, forkJoin } from 'rxjs';
import { take } from 'rxjs/operators';
import { MessageDialogComponent } from 'src/app/shared/message-dialog/message-dialog.component';
import { MatSidenav } from '@angular/material/sidenav';
import { Dictionary } from 'src/business/utils/dictionary';
import { Theme, getThemeClass } from 'src/business/shared/theme.enum';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { setMobileScreenFlag, setWebScreenFlag } from 'src/ngrx/user-interface/ui.actions';
import { OverlayContainer, ComponentType } from '@angular/cdk/overlay';
import { SnackBarConfig, snackBarDefaultConfig } from 'src/business/shared/snackbar-config.interface';
import { ConfirmDialogComponent } from 'src/app/shared/confirm-dialog/confirm-dialog.component';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { trialMessageHtml, trialOverHtml } from 'src/business/shared/popup-templates';
import * as moment from 'moment'

@Injectable({ providedIn: 'root' })
export class UIService {

    constructor(
        private store: Store<AppState>,
        private snackBar: MatSnackBar,
        private dialog: MatDialog,
        private overlayContainer: OverlayContainer,
    ) { }

    // #region ================ SNACKBARS ================ 

    public openSnackbarFromComponent(component: ComponentType<any>, config?: SnackBarConfig) {
        const opts = Object.assign({}, snackBarDefaultConfig, config);
        this.snackBar.openFromComponent(component, opts);
    }

    // #endregion  

    // #region ================ DIALOGS ================ 

    public openDialogFromComponent(component: ComponentType<any>, config?: MatDialogConfig, callbackAction?: Function) {
        const opts = Object.assign({}, snackBarDefaultConfig, config);

        const dialogRef = this.dialog.open(component, opts);

        dialogRef.afterClosed()
            .pipe(take(1))
            .subscribe((params) => {
                callbackAction && callbackAction.call(params)
            });

        return dialogRef;
    }

    confirmDialog: MatDialogRef<any, any>;
    public openConfirmDialog(message: string, action: Function, allowConfirm: boolean = true) {
       
        if(this.confirmDialog) this.confirmDialog.close();

        this.confirmDialog = this.openDialogFromComponent(ConfirmDialogComponent, {
            height: 'auto',
            maxWidth: '20rem',
            autoFocus: false,
            disableClose: !allowConfirm,
            closeOnNavigation: allowConfirm,
            data: { message: message, allowConfirm: allowConfirm },
        }, action);
    }

    private _fadeOutMessageDialog: MatDialogRef<MessageDialogComponent>;
    public fadeOutMessage(message: string, timeout: number = 1000) {

        console.log('This message has no if... if(ERROR SNACKBAR OR ANYTHING GOD DAMN ELSE');

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

    // #endregion  

    // #region ================ THEME ================ 

    public setupTheme(theme: Theme) {

        const overlayContainer = this.overlayContainer.getContainerElement();
        const documentBody = document.getElementsByTagName("BODY")[0];

        const overlayContainerClasses = overlayContainer.classList;
        const bodyClasses = documentBody.classList;

        const overlayThemeClassesToRemove = Array.from(overlayContainerClasses).filter((item: string) => item.includes('theme-'));
        const bodyThemeClassesToRemove = Array.from(bodyClasses).filter((item: string) => item.includes('theme-'));

        overlayThemeClassesToRemove.length && overlayContainerClasses.remove(...overlayThemeClassesToRemove);
        bodyThemeClassesToRemove.length && bodyClasses.remove(...bodyThemeClassesToRemove);

        var themeClass = getThemeClass(theme);
        overlayContainerClasses.add(themeClass);
        bodyClasses.add(themeClass);

    }

    // #endregion  

    // #region ================ SIDEBARS ================ 

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
 
     public isSidenavOpened(name: string): Observable<boolean> {
         return of(this.sidenavs.item(name).opened);
     }

    // #endregion  

    // #region ================ SCREEN RESIZE ================ 

    @HostListener('window:resize', ['$event'])
    protected onResize() {

        if (window.innerWidth <= 599) {

            // only dispatch if the value different
            this.store
                .select(isMobile)
                .pipe(take(1))
                .subscribe((isMobile: boolean) => !isMobile && this.store.dispatch(setMobileScreenFlag({ isMobile: true })))

            return;
        }

        // only dispatch if the value different
        this.store
            .select(isMobile)
            .pipe(take(1))
            .subscribe((isMobile: boolean) => isMobile && this.store.dispatch(setWebScreenFlag({ isWeb: true })))
    }

    // #endregion  

    // #region ================ CUSTOM POPUP MESSAGES ================ 

    public showSubscriptioninfoDialogOnLogin(isTrialing: boolean, isSubscribed: boolean, trialDaysRemaining: number) {

        let message: string;
        let action: Function;
        let allowConfirm: boolean = true;
        let showSplashDialog = this.showSplashDialog;

        if (isTrialing && showSplashDialog) {  // TRIALING
            message = trialMessageHtml(trialDaysRemaining);
            action = this.setSplashDialogDate; // set splash dialog date
        }
        else if (!isTrialing && !isSubscribed) {  // MUST SUBSCRIBE
            message = trialOverHtml;
            action = () => { };
            allowConfirm = false;
            showSplashDialog = true; // must show dialog for this
        }
        // else if (!isTrialing && isSubscribed) {   // SUBSCRIPTION IS INVALID
        //     message = invalidSubscriptionHtml;
        //     action = this.setSplashDialogDate;
        //     allowConfirm = false;
        //     showSplashDialog = true; // must show dialog for this
        // }

        showSplashDialog && message && this.openConfirmDialog(message, action, allowConfirm);
    }

    private setSplashDialogDate() {
        localStorage.setItem('splashDialogDate', moment(new Date()).utc().format('L'));
    }

    private get showSplashDialog(): boolean {
        const date = localStorage.getItem('splashDialogDate');
        return !date || date != moment(new Date()).utc().format('L');
    }

    // #endregion  
}
