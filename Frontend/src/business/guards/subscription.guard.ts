import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild, UrlSegment } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';
import { UIService } from '../services/shared/ui.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { isTrialing, isSubscribed, trialDaysRemaining } from 'src/ngrx/auth/auth.selectors';
import { take, map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class SubscriptionGuard implements CanActivateChild {

  constructor(
    private UIService: UIService,
    private store: Store<AppState>
  ) {
  }


  canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    // In the next you have .url prop so you can check for it 
    const allowedToNavigate = next.url ? next.url.length > 0 ? next.url[0].path == 'settings' || next.url[0].path == 'billing' : false : false;

    return forkJoin(

      this.store.select(isTrialing).pipe(take(1)),
      this.store.select(isSubscribed).pipe(take(1)),
      this.store.select(trialDaysRemaining).pipe(take(1)))

      .pipe(map(([isTrialing, isSubscribed, trialDaysRemaining]) => {

        this.UIService.showSubscriptioninfoDialogOnLogin(isTrialing, isSubscribed, trialDaysRemaining);

        if (isTrialing || isSubscribed || allowedToNavigate) return true;

        return false;

      }));
  }

}
