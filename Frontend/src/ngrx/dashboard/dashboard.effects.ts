import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { DashboardService } from './../../app/features/dashboard/services/dashboard.service';

@Injectable()
export class DashboardEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private dashboardService: DashboardService
    ) { }

    // dashboardParamsUpdated$ = createEffect(() =>
    // this.actions$
    //     .pipe(
    //         ofType(DashboardActions.updateTrackItem),
    //         switchMap(action => this.dashboardService.updateTrackItem(action.trackItem.id, action.trackItem.jsonParams)
    //         .pipe(
    //           take(1),
    //           tap(_ => console.log(_)),
    //           map((trackItem: TrackItem) => this.store.dispatch(DashboardActions.trackItemUpdated( { trackItem} )))
    //         )
    //       )
    //     )
    // , { dispatch: false });


}
