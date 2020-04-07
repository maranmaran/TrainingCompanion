import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardEffects } from 'src/ngrx/dashboard/dashboard.effects';
import { dashboardReducer } from './../../../ngrx/dashboard/dashboard.reducers';
import { ActionsComponent } from './dashboard-home/actions/actions.component';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { FeedComponent } from './dashboard-home/feed/feed.component';
import { TrackItemsSidebarComponent } from './dashboard-home/track-items-sidebar/track-items-sidebar.component';
import { TracksComponent } from './dashboard-home/tracks/tracks.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardOutletDirective } from './directives/dashboard-outlet.directive';
import { FeedResolver } from 'src/business/resolvers/feed.resolver';
import { VolumeCardComponent } from './dashboard-home/track-items-sidebar/card-components/volume-card/volume-card.component';
import { MaxCardComponent } from './dashboard-home/track-items-sidebar/card-components/max-card/max-card.component';


@NgModule({
    imports: [
        SharedModule,
        DashboardRoutingModule,
        StoreModule.forFeature('dashboard', dashboardReducer),
        EffectsModule.forFeature([DashboardEffects]),
    ],
    declarations: [
        DashboardHomeComponent,
        DashboardOutletDirective,
        ActionsComponent,
        TrackItemsSidebarComponent,
        TracksComponent,
        FeedComponent,
        VolumeCardComponent,
        MaxCardComponent
    ],
    exports: [
    ],
    providers: [
        FeedResolver
    ],
    entryComponents: [
    ]
})
export class DashboardModule { }
