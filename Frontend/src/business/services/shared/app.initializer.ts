import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { filter, take } from 'rxjs/operators';
import { fetchCurrentUser } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { startAppInitializer, stopAppInitializer, isAppInitialized } from 'src/ngrx/app-initialize.ngrx';

export const initApplication = (store: Store<AppState>, actions$: Actions): Function => {

    return () => new Promise(resolve => {

        store.dispatch(startAppInitializer());
        store.dispatch(fetchCurrentUser());

        store.select(isAppInitialized)
            .pipe(
                filter((fetched: boolean) => fetched), // filter when app is initialized
                take(1)
            )
            .subscribe(() => {
                store.dispatch(stopAppInitializer());
                resolve(true);
            });
    });
}