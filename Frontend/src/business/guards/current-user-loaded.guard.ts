import { AuthService } from '../services/feature-services/auth.service';
import { Store } from '@ngrx/store';
import { CanActivate, CanActivateChild, Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, take, catchError, finalize } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { of, Observable } from 'rxjs';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { updateCurrentUser } from 'src/ngrx/auth/auth.actions';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';

export class CurrentUserLoadedGuard implements CanActivate {


    constructor(
        private store: Store<AppState>,
        private authService: AuthService,
        private router: Router
    ) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.SplashScreen}));

        return new Promise(resolve => {
            this.authService.getCurrentUserInfo()
                .pipe(
                    take(1),
                    catchError(() => {
                        console.log('error');
                        this.router.navigate(['/auth/login']);
                        return of(null);
                    }),
                    map(((currentUser: CurrentUser) => {
                        if (!currentUser) return resolve(false);

                        currentUser && this.store.dispatch(updateCurrentUser(currentUser));

                        resolve(true);
                    }))
                ).subscribe();
        })
    }

}