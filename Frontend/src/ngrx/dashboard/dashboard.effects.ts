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

    // dashboardUpdated$ = createEffect(() =>
    // this.actions$
    //     .pipe(
    //         ofType(DashboardActions.saveDashboard),
    //         withLatestFrom(this.store.select(dashboardUpdated)),
    //         filter(([action, value]) => value == true),
    //         switchMap(item => {
    //             return this.dashboardService.saveMainDashboard(action.tracks);
    //         })

    //     )
    // , { dispatch: false });


}
