import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { FeedResolver } from 'src/business/resolvers/feed.resolver';
import { DashboardEffects } from 'src/ngrx/dashboard/dashboard.effects';
import { ExerciseTypesResolver } from './../../../business/resolvers/exercise-types.resolver';
import { ExerciseTypeService } from './../../../business/services/feature-services/exercise-type.service';
import { dashboardReducer } from './../../../ngrx/dashboard/dashboard.reducers';
import { ExerciseTypeEffects } from './../../../ngrx/exercise-type/exercise-type.effects';
import { exerciseTypeReducer } from './../../../ngrx/exercise-type/exercise-type.reducers';
import { ActionsComponent } from './dashboard-home/actions/actions.component';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { BodyweightFeedItemComponent } from './dashboard-home/feed/feed-items/bodyweight-feed-item/bodyweight-feed-item.component';
import { MediaFeedItemComponent } from './dashboard-home/feed/feed-items/media-feed-item/media-feed-item.component';
import { PersonalBestFeedItemComponent } from './dashboard-home/feed/feed-items/personal-best-feed-item/personal-best-feed-item.component';
import { TrainingFeedItemComponent } from './dashboard-home/feed/feed-items/training-feed-item/training-feed-item.component';
import { FeedComponent } from './dashboard-home/feed/feed.component';
import { TrackItemsSidebarComponent } from './dashboard-home/tracks/track-items-sidebar/track-items-sidebar.component';
import { TracksComponent } from './dashboard-home/tracks/tracks.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardOutletDirective } from './directives/dashboard-outlet.directive';
import { TracksResolver } from 'src/business/resolvers/dashboard-tracks.resolver';


@NgModule({
    imports: [
        SharedModule,
        DashboardRoutingModule,
        StoreModule.forFeature('dashboard', dashboardReducer),
        StoreModule.forFeature('exerciseType', exerciseTypeReducer),
        EffectsModule.forFeature([DashboardEffects, ExerciseTypeEffects]),
    ],
    declarations: [
        DashboardHomeComponent,
        DashboardOutletDirective,
        ActionsComponent,
        TrackItemsSidebarComponent,
        TracksComponent,
        FeedComponent,
        MediaFeedItemComponent,
        TrainingFeedItemComponent,
        BodyweightFeedItemComponent,
        PersonalBestFeedItemComponent,
    ],
    exports: [
    ],
    providers: [
        FeedResolver,
        ExerciseTypesResolver,
        ExerciseTypeService,
        TracksResolver
    ],
    entryComponents: [
    ]
})
export class DashboardModule { }
