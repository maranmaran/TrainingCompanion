import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { map, switchMap, take, tap } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { DashboardService } from './../../app/features/dashboard/services/dashboard.service';
import * as DashboardActions from './dashboard.actions';

@Injectable()
export class DashboardEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private dashboardService: DashboardService
    ) { }

    dashboardParamsUpdated$ = createEffect(() =>
    this.actions$
        .pipe(
            ofType(DashboardActions.updateTrackItemParams),
            switchMap(action => this.dashboardService.updateTrackItem(action.trackItemId, action.jsonParams)
            .pipe(
              take(1),
              tap(_ => console.log(_)),
              map((trackItem: TrackItem) => this.store.dispatch(DashboardActions.trackItemParamsUpdated( { trackItemId: trackItem.id, jsonParams: trackItem.jsonParams } )))
            )
          )
        )
    , { dispatch: false });


}
