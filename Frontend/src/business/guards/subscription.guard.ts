import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { UIService } from '../services/shared/ui.service';

@Injectable()
export class SubscriptionGuard implements CanActivate {

  constructor(
    private authService: AuthService,
    private UIService: UIService
  ) {
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    if (this.authService.isAuthenticated()) {
      return true;
    }

    // this.UIService.warning('Please review your subscription in account setting billing section.')
  }

}
