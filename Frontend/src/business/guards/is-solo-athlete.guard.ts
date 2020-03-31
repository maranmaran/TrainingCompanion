import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { isSoloAthlete } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
@Injectable({ providedIn: 'root' })
export class IsSoloAthlete implements CanActivate {
    constructor(private store: Store<AppState>) {
    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.store.select(isSoloAthlete).pipe(take(1));
    }
}
