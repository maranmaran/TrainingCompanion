import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { isCoach } from 'src/ngrx/auth/auth.selectors';

@Injectable({ providedIn: 'root' })
export class IsCoach implements CanActivate {

    constructor(
        private store: Store<AppState>
    ) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.store.select(isCoach).pipe(take(1))
    }

}
