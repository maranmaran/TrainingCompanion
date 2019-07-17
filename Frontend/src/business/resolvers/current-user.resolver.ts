import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { forkJoin, Observable, of, EMPTY } from 'rxjs';
import { map, take, tap, finalize, catchError, concatMap } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-reducers';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { AuthService } from '../services/auth.service';
import { UIService } from '../services/shared/notification.service';
import { isSubscribed, isTrialing, trialDaysRemaining, currentUser } from './../../ngrx/auth/auth.selectors';
import { login, updateCurrentUser } from 'src/ngrx/auth/auth.actions';

@Injectable({ providedIn: 'root' })
export class CurrentUserResolver implements Resolve<void> {

    constructor(
        private router: Router,
        private authService: AuthService,
        private UIService: UIService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

       return this.store
        .select(currentUser)
        .pipe(
            take(1), 
            concatMap((currentUser: CurrentUser) => {
                if (!currentUser) {

                    this.UIService.showErrorSnackbar = !this.UIService.showErrorSnackbar;
                    this.UIService.showSplash = !this.UIService.showSplash;

                    return this.authService.getCurrentUserInfo()
                        .pipe(
                            take(1),
                            catchError(() => {
                                this.router.navigate(['/auth/login']);
                                return undefined;
                            }),
                            map((currentUser: CurrentUser) => {
                                this.store.dispatch(updateCurrentUser(currentUser));
                                //this.showDialog(); // effecT?
                            }),
                            finalize(
                                () => {
                                    this.UIService.showErrorSnackbar = !this.UIService.showErrorSnackbar;
                                    this.UIService.showSplash = !this.UIService.showSplash;
                                }
                            )
                        );
                    }

                this.showDialog();
            })
        );
    }

    trialMessageHtml = (trialDaysRemaining) => `
    <h4><b>Your trial has only ${trialDaysRemaining} days remaining</b></h4>
    <p> Use <a href="#" data-link="/settings/billing">Billing Settings</a> to 
    subscribe immediately or after the trial is over. </p>`;

    trialOverHtml = `
    <h4><b>Your trial has finished</b></h4>
    <p>Please choose a subscription in <a href="#" data-link="/settings/billing">Billing Settings</a> or 
    <a href="#" data-link="">Contact Us</a> if you need assistance.</p>`;

    invalidSubscriptionHtml = `
    <h4><b>Something is wrong with your subscription.</b></h4>
    <p>Please head over to <a href="#" data-link="/settings/billing">Billing Settings.</a> 
    and review your subscription status or <a href="#" data-link="">Contact Us</a>.</p>`;

    showDialog() {

        forkJoin(this.store.select(isTrialing),
            this.store.select(isSubscribed),
            of(this.authService.showSplashDialog),
            this.store.select(trialDaysRemaining))
            .pipe(take(1))
            .subscribe(([isTrialing, isSubscribed, showSplashDialog, trialDaysRemaining]) => {

                let message: string;
                let action: Function;

                if (isTrialing && showSplashDialog) {  // TRIALING
                    message = this.trialMessageHtml(trialDaysRemaining);
                    action = this.authService.setSplashDialogDate;
                }
                else if (!isSubscribed && !isTrialing) {  // MUST SUBSCRIBE
                    message = this.trialOverHtml;
                    action = () => { };
                }
                else if (isSubscribed && isTrialing) {   // SUBSCRIPTION IS INVALID
                    message = this.invalidSubscriptionHtml;
                    action = this.authService.setSplashDialogDate;
                }

                this.UIService.openConfirmDialog(message, action);
            })
    }

}
