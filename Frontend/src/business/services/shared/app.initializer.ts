import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { loadCurrentUser, startAppInitializer, stopAppInitializer } from 'src/ngrx/run.effects';
import { CurrentUser } from './../../../server-models/cqrs/authorization/responses/current-user.response';

export const initApplication = (store: Store<AppState>, actions$: Actions): Function => {

    return () => new Promise(resolve => {

        store.dispatch(startAppInitializer());
        store.dispatch(loadCurrentUser());

        store.select(currentUser)
            .pipe(take(2))
            .subscribe(
                (currentUser: CurrentUser) => {
                    if (currentUser != undefined) {
                        store.dispatch(stopAppInitializer());
                        resolve(true);
                    }
                }
            );
        });
    }