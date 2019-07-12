import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { NotificationService } from '../services/shared/notification.service';

@Injectable()
export class SubscriptionGuard implements CanActivate {

  constructor(
    private authService: AuthService,
    private notificationService: NotificationService
  ) {
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    if (this.authService.isAuthenticated()) {
      return true;
    }

    this.notificationService.warning('Please review your subscription in account setting billing section.')
  }

}
