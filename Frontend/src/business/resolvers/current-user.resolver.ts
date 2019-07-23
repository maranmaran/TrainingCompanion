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
import { UIService } from '../services/shared/ui.service';
import { currentUser } from './../../ngrx/auth/auth.selectors';

@Injectable({ providedIn: 'root' })
export class CurrentUserResolver implements Resolve<CurrentUser | void> {

    constructor(
        private router: Router,
        private authService: AuthService,
        private uiService: UIService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

       return this.store
        .select(currentUser)
        .pipe(
            take(1), 
            concatMap((currentUser: CurrentUser) => {
                if (!currentUser) {

                    this.store.dispatch(disableErrorSnackbar());
                    this.store.dispatch(setActiveProgressBar({progressBar: UIProgressBar.SplashScreen}));

                    return this.authService.getCurrentUserInfo()
                        .pipe(
                            take(1),
                            catchError(() => {
                                this.router.navigate(['/auth/login']);
                                return EMPTY;
                            }),
                            map((currentUser: CurrentUser) => {
                                this.store.dispatch(updateCurrentUser(currentUser));
                                this.uiService.showSubscriptioninfoDialogOnLogin();
                                this.store.dispatch(setActiveProgressBar({progressBar: UIProgressBar.MainAppScreen}));
                            })
                        );
                    }

                this.uiService.showSubscriptioninfoDialogOnLogin();
                return of(currentUser);
            })
        );
    }

  

}