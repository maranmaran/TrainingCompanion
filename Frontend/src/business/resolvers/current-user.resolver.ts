import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { EMPTY, Observable, of } from 'rxjs';
import { catchError, map, take, finalize } from 'rxjs/operators';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { AuthService } from '../services/auth.service';
import { NotificationService } from '../services/shared/notification.service';
import { CurrentUserStore } from '../stores/current-user.store';

@Injectable({ providedIn: 'root'})
export class CurrentUserResolver implements Resolve<CurrentUser> {

    constructor(
        private authService: AuthService,
        private currentUserStore: CurrentUserStore,
        private router: Router,
        private notificationService: NotificationService
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<CurrentUser> | Observable<never> {
        
        if(!this.currentUserStore.state) {
            
            this.notificationService.showErrorSnackbar = !this.notificationService.showErrorSnackbar;
            this.notificationService.showSplash = !this.notificationService.showSplash;

            return this.authService.getCurrentUserInfo()
                .pipe(
                    take(1),
                    catchError(() => {
                        this.router.navigate(['/login']);
                        return EMPTY;
                    }),
                    map((res: CurrentUser) => {
                        this.currentUserStore.setState(res);
                        this.showDialog();
                        return res;
                    }),
                    finalize(
                        () => {
                            this.notificationService.showErrorSnackbar = !this.notificationService.showErrorSnackbar;
                            this.notificationService.showSplash = !this.notificationService.showSplash;
                        }
                    )
                );
        } 

        this.showDialog();
        return of(this.currentUserStore.state);
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
        this.currentUserStore.isSubscribed && this.currentUserStore.isTrialing && this.authService.showSplashDialog && this.notificationService.openConfirmDialog(this.trialMessageHtml(this.currentUserStore.trialDaysRemaining), this.authService.setSplashDialogDate); // Trialing
        !this.currentUserStore.isSubscribed && !this.currentUserStore.isTrialing && this.notificationService.openConfirmDialog(this.trialOverHtml, () => { }); // Must subscribe
        this.currentUserStore.isSubscribed && !this.currentUserStore.isTrialing && this.authService.showSplashDialog && this.notificationService.openConfirmDialog(this.invalidSubscriptionHtml, this.authService.setSplashDialogDate); // Subscribed but something is wrong with subscription
    }

}