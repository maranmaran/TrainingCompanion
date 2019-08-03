import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { EMPTY, of } from 'rxjs';
import { catchError, concatMap, finalize, map, take } from 'rxjs/operators';
import { updateCurrentUser } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { disableErrorSnackbar, setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';
import { AuthService } from '../services/auth.service';
import { currentUser } from './../../ngrx/auth/auth.selectors';
import { UIService } from '../services/shared/ui.service';

@Injectable({ providedIn: 'root' })
export class CurrentUserResolver implements Resolve<CurrentUser | void> {

    constructor(
        private router: Router,
        private authService: AuthService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        
        console.log('resolve');

   
    }

  

}